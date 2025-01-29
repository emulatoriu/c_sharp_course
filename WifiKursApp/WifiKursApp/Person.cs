using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WifiKursApp
{
    public class Person
    {
        int iAge;
        string sName;
        string sPhone;
        string sAddress;

        public void setiAge(int iAge)
        {
            this.iAge = iAge;
        }

        public int getiAge()
        {
            return iAge;
        }

        public void setsName(string sName)
        {
            this.sName = sName;
        }

        public string getsName()
        {
            return sName;
        }

        public void setsPhone(string sPhone)
        {
            this.sPhone = sPhone;
        }

        public string getsPhone()
        {
            return sName;
        }

        public void setsAddress(string sAddress)
        {
            this.sAddress = sAddress;
        }

        public string getsAddress()
        {
            return sAddress;
        }

    }
}
