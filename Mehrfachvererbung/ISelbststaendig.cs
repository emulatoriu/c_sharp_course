using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mehrfachvererbung
{
    interface ISelbststaendig : IPerson
    {
        public double JahresUmsatz { get; set; }
        public bool Umsatzsteuerpflichtig { get; set; }
        public double FAVorauszahlungMonatl { get; set; }

    }
}
