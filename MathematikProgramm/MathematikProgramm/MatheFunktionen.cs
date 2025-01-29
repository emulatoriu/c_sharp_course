using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematikProgramm
{
    class MatheFunktionen
    {
        public static float PI = 3.14f;

        public readonly static int druckerID = 5;

        static MatheFunktionen()
        {
            // lies ein File ein und initialisier damit den Parameter test einmalig

            // test dependency injection
        }

        public static int multi(int multiplikant, int multiplikator)
        {
            return multiplikant * multiplikator;            
        }
    }
}
