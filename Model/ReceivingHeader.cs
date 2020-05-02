using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uwprek.Model
{
    public class ReceivingHeader
    {
        public string ID { get; set; }
        public string DocNumber { get; set; }

        public Double DocDate { get; set; }
        public string Notes { get; set; }

        public Double Weight { get; set; }

        public string RFID { get; set; }

        public Species Species { get; set; }

        public Supplier Supplier { get; set; }
    }
}
