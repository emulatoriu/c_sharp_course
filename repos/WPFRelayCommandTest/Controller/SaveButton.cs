using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFRelayCommandTest.Data;

namespace WPFRelayCommandTest.Controller
{
    internal class SaveButton
    {
        TextWrapper textWrapper;
        public SaveButton(TextWrapper textWrapper)
        {
            this.textWrapper = textWrapper;
        }
        public void setSave(object parameter)
        {
            textWrapper.ShowedText = "Save";
        }
    }
}
