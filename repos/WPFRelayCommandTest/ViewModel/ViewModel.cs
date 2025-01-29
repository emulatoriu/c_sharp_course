using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFRelayCommandTest.Controller;
using WPFRelayCommandTest.Data;

namespace WPFRelayCommandTest.ViewModel
{
    public class ViewModel
    {
        public ICommand Save { get; set; }
        public ICommand Load { get; set; }
        public TextWrapper TW { get; set; }                
        
        public ViewModel()
        {
            TW = new TextWrapper();
            Save = new RelayCommand(new SaveButton(TW).setSave);
            Load = new RelayCommand(new LoadButton(TW).setLoad);
        }        
    }
}
