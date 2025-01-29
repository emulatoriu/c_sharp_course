using Consul.Filtering;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PixelFormat = System.Drawing.Imaging.PixelFormat;

namespace WPF_Pixelator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[,] SobelHorizontal = new int[3,3];
        int[,] SobelVertical = new int[3, 3];

        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject([In] IntPtr hObject);
        public MainWindow()
        {
            InitializeComponent();
            SobelHorizontal[0,0] = -1;
            SobelHorizontal[0, 1] = 0;
            SobelHorizontal[0, 2] = 1;
            SobelHorizontal[1, 0] = -2;
            SobelHorizontal[1, 1] = 0;
            SobelHorizontal[1, 2] = 2;
            SobelHorizontal[2, 0] = -1;
            SobelHorizontal[2, 1] = 0;
            SobelHorizontal[2, 2] = 1;

            SobelVertical = SobelHorizontal;
        }

        public async Task<Bitmap>Superpixels(Bitmap image, int nsp)
        {
            int w = image.Width;
            int h = image.Height;

            BitmapData image_data = image.LockBits(
                new System.Drawing.Rectangle(0, 0, w, h),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);

            int bytes = image_data.Stride * image_data.Height;
            byte[] buffer = new byte[bytes];

            Marshal.Copy(image_data.Scan0, buffer, 0, bytes);
            image.UnlockBits(image_data);

            int ntp = buffer.Length / 3;
            int s = (int)Math.Floor(Math.Sqrt((double)ntp / nsp));

            int[][] means = new int[nsp][];
            byte[] result = new byte[bytes];
            int sp = 0;

            //compute initial superpixel cluster centers
            for (int x = s / 2; x < w; x += s)
            {
                for (int y = s / 2; y < h; y += s)
                {
                    int position = x * 3 + y * image_data.Stride;

                    //compute lowest gradient
                    int lowest_grad = 99999;
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            int n_pos = position + i * 3 + j * image_data.Stride;
                            int grad = 0;
                            for (int k = -1; k <= 1; k++)
                            {
                                for (int l = -1; l <= 1; l++)
                                {
                                    int g_pos = n_pos + k * 3 + l * image_data.Stride;
                                    grad += buffer[g_pos] * (SobelHorizontal[k + 1, l + 1] + SobelVertical[k + 1, l + 1]);
                                }
                            }
                            if (lowest_grad > grad)
                            {
                                lowest_grad = grad;
                                means[sp] = new int[] { buffer[n_pos], x + i, y + j };
                            }
                        }
                    }

                    for (int c = 0; c < 3; c++)
                    {
                        result[means[sp][1] * 3 + means[sp][2] * image_data.Stride + c] = 255;
                    }
                    if (sp < nsp - 1)
                    {
                        sp++;
                    }
                }
            }

            int[] labels = new int[bytes];
            double[] distances = new double[bytes];
            for (int i = 0; i < bytes; i += 3)
            {
                labels[i] = -1;
                distances[i] = buffer.Length;
            }

            double error = new double();
            double cc = 20;
            while (true)
            {
                int[][] new_means = new int[nsp][];

                //assign samples to clusters
                for (int i = 0; i < nsp; i++)
                {
                    int m_pos = means[i][1] * 3 + means[i][2] * image_data.Stride;
                    int xe = 2 * s + means[i][1];
                    int xs = means[i][1] - 2 * s;
                    int ye = 2 * s + means[i][2];
                    int ys = means[i][2] - 2 * s;

                    for (int x = (xs < 0 ? 0 : xs); x < ((xe < w) ? xe : w); x++)
                    {
                        for (int y = (ys < 0 ? 0 : ys); y < (ye < h ? ye : h); y++)
                        {
                            int position = x * 3 + y * image_data.Stride;
                            double ds = Math.Sqrt(Math.Pow(x - means[i][1], 2) + Math.Pow(y - means[i][2], 2));
                            double dc = Math.Sqrt(Math.Pow(buffer[position] - means[i][0], 2)
                                + Math.Pow(buffer[position + 1] - means[i][0], 2)
                                + Math.Pow(buffer[position + 2] - means[i][0], 2));
                            double distance = dc + (cc / s) * ds;
                            if (distance < distances[position])
                            {
                                distances[position] = distance;
                                labels[position] = i;
                            }
                        }
                    }
                }

                //compute new means
                for (int i = 0; i < nsp; i++)
                {
                    new_means[i] = new int[3];
                    int samples = 0;
                    for (int x = 0; x < w; x++)
                    {
                        for (int y = 0; y < h; y++)
                        {
                            int position = x * 3 + y * image_data.Stride;
                            if (labels[position] == i)
                            {
                                new_means[i][0] += buffer[position];
                                new_means[i][1] += x;
                                new_means[i][2] += y;
                                samples++;
                            }
                        }
                    }

                    for (int j = 0; j < 3; j++)
                    {
                        new_means[i][j] /= samples;
                    }
                }

                //compute error
                double new_error = 0;
                for (int i = 0; i < nsp; i++)
                {
                    new_error += (int)Math.Sqrt(Math.Pow(means[i][0] - new_means[i][0], 2)
                        + Math.Pow(means[i][1] - new_means[i][1], 2)
                        + Math.Pow(means[i][2] - new_means[i][2], 2));
                    means[i] = new_means[i];
                }

                if (error < new_error)
                {
                    break;
                }
                else
                {
                    error = new_error;
                }
            }

            for (int i = 0; i < nsp; i++)
            {
                for (int j = 0; j < bytes; j += 3)
                {
                    if (labels[j] == i)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            result[j + c] = (byte)means[i][0];
                        }
                    }
                }
            }

            Bitmap res_img = new Bitmap(w, h);
            BitmapData res_data = res_img.LockBits(
                new System.Drawing.Rectangle(0, 0, w, h),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb);
            Marshal.Copy(result, 0, res_data.Scan0, bytes);
            res_img.UnlockBits(res_data);

            return res_img;
        }
        private Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        {
            // BitmapImage bitmapImage = new BitmapImage(new Uri("../Images/test.png", UriKind.Relative));

            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);

                return new Bitmap(bitmap);
            }
        }

        public ImageSource ImageSourceFromBitmap(Bitmap bmp)
        {
            var handle = bmp.GetHbitmap();
            try
            {
                return Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
            finally { DeleteObject(handle); }
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;
            if (dlg.ShowDialog() == true)
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(dlg.FileName);
                //bitmap.DecodePixelHeight = 200;
                bitmap.EndInit();
                //txtEditor.Text = File.ReadAllBytes(dlg.FileName);
                Task<Bitmap> bitmapTask = Superpixels(BitmapImage2Bitmap(bitmap), 10);
                Bitmap sp = await bitmapTask;
                LoadedImage.Source =  ImageSourceFromBitmap(sp); // source als property an den bitmapTask oder sp binden - dann gehts async
            }
        }

        private void sayHello(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello");
        }
    }

    
}
