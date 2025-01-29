using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFRelayCommandTest.Data;

namespace WPFRelayCommandTest.Controller
{
    internal class LoadButton
    {        
        TextWrapper textWrapper;
        public LoadButton(TextWrapper textWrapper)
        {
            this.textWrapper = textWrapper;
        }
        public void setLoad(object parameter)
        {
            textWrapper.ShowedText = "Load";            
        }
    }
}
