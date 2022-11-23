using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kahveciUygulaması
{
    abstract class Gida
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public double Fiyat { get; set; }

    }
}
