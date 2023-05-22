using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public  class Rentals
    {
        private string name;
        private char vIden;
        private int sHour;
        private int sMinute;
        private int eHour;
        private int eMinute;

        public int timeLength()
        {
            return (eHour * 60) + eMinute - (sHour * 60) + sMinute;
        }

        public Rentals(string Name, char VIden, int SHour, int SMinute, int EHour, int EMinute)
        {
            this.name = Name;
            this.vIden = VIden;
            this.sHour = SHour;
            this.sMinute = SMinute;
            this.eHour = EHour;
            this.eMinute = EMinute;
        }

        public string Name { get => name; set => name = value; }
        public char VIden { get => vIden; set => vIden = value; }
        public int SHour { get => sHour; set => sHour = value; }
        public int SMinute { get => sMinute; set => sMinute = value; }
        public int EHour { get => eHour; set => eHour = value; }
        public int EMinute { get => eMinute; set => eMinute = value; }
    }
}
