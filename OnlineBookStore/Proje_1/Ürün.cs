using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje_1
{
   public abstract class Ürün
    {
        public string ad;
        public int id;
        public double fiyat;
       
        public abstract string ÖzellikleriGöster(int id);
        public abstract double ÜrünFiyatınıÇek(int id);
    }
}
