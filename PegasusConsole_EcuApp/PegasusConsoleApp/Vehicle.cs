using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegasusConsoleApp
{
    class Vehicle
    {
        public long? Id { get; set; }
        public long? Device { get; set; }
        //public Double? Latitud { get; set; }
        //public Double? Longitud { get; set; }
        public DateTime? System_Time { get; set; }
        public DateTime? Event_Time { get; set; }
        public object EcuBattery { get; set; }
        public object EcuCoolLvl { get; set; }
        public object EcuBrakePedal { get; set; }

        //public Dictionary<string, int> dicCamposEcu = new Dictionary<string, int>();
    }
}
