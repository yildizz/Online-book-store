using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje_1
{
    class Kullanıcı
    {
        private  int Id;
        private string rumuz;
        private string şifre;
        private string ad;
        private string soyad;
        private string meslek;
        private bool cinsiyet;

       
        public int Id1
        {
            get
            {
                return Id;
            }

            set
            {
                Id = value;
            }
        }

        public string Rumuz
        {
            get
            {
                return rumuz;
            }

            set
            {
                rumuz = value;
            }
        }

        public string Şifre
        {
            get
            {
                return şifre;
            }

            set
            {
                şifre = value;
            }
        }

        public string Ad
        {
            get
            {
                return ad;
            }

            set
            {
                ad = value;
            }
        }

        public string Soyad
        {
            get
            {
                return soyad;
            }

            set
            {
                soyad = value;
            }
        }

        public string Meslek
        {
            get
            {
                return meslek;
            }

            set
            {
                meslek = value;
            }
        }

        public bool Cinsiyet
        {
            get
            {
                return cinsiyet;
            }

            set
            {
                cinsiyet = value;
            }
        }
    }
}
