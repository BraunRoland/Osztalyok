using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osztalyok
{
    internal class Cicaaa
    {
        private string nev;
        private int kor;
        private int suly;
        private string faj;
        private string szin;
        private int rendetlensegSzint;
        private int fogyasztas;
        private bool ehes;
        private string nem;
        private int maxRend;

        public Cicaaa(string nev, int kor, int suly, string faj, string szin, int rendetlensegSzint, int fogyasztas, string nem)
        {
            this.nev = nev;
            this.kor = kor;
            this.suly = suly;
            this.faj = faj;
            this.szin = szin;
            this.rendetlensegSzint = rendetlensegSzint;
            this.fogyasztas = fogyasztas;
            this.nem = nem;
            ehes = true;
            maxRend = 100;
        }
        Random rnd = new Random();

        public void Eves(double kajaSuly)
        {
            int esely = rnd.Next(101);

            ehes = false;

            if (esely <= 4)
            {
                szin = "zold";
                suly -= (int)(suly * (esely / 100.0));
                rendetlensegSzint *=(int) 0.5;
                Eletkor();
            }
            suly += (int)Math.Ceiling(fogyasztas * kajaSuly);
            
        }

        public void Alvas()
        {
            rendetlensegSzint = 0;
            if (szin == "zöld")
            {
                szin = "Eredeti";
            }
        }

        public void Ebredes()
        {
            rendetlensegSzint = 100;
            Eletkor();
            ehes = true;
        }

        public void Jatek()
        {
            List<string> jatekok = ["labdázott", "karmolászott", "harapdált", "romlott kaját evett", "egeret kergetett"];
            List<string> eztCsinalta = [];
            if (rendetlensegSzint == 0)
            {
                Alvas();
            }
            else if (rendetlensegSzint < 31)
            {
                Console.WriteLine("Rendetlenségszint: Elfogadható");
                eztCsinalta.Append(jatekok[rnd.Next(0, jatekok.Count)]);
            }
            else if (rendetlensegSzint < 61)
            {
                Console.WriteLine("Rendetlenségszint: átlagos");
                for (int i = 0; i < 2; i++)
                {
                    eztCsinalta.Append(jatekok[rnd.Next(0, jatekok.Count)]);
                }
            }
            else
            {
                Console.WriteLine("Rendetlenségszint: Veszélyes!");
                for ( int i = 0; i < 3; ++i )
                {
                    eztCsinalta.Append(jatekok[rnd.Next(0, jatekok.Count)]);
                }
            }
            Console.Write("A cica: ");
            foreach (var item in eztCsinalta)
            {
                Console.Write(item + ", ");
                if (item == "romlott kaját evett")
                {
                    Eves(rnd.Next(5));
                }
            }
            Console.WriteLine();
        }

        public void Eletkor()
        {
            if (kor < 3)
            {
                maxRend = 100;
            }
            else if (kor < 6)
            {
                maxRend = 75;
            }
            else if (kor < 9)
            {
                maxRend = 50;
            }
            else
            {
                maxRend = 35;
            }
            Rendetlenseg();
        }

        public void Rendetlenseg()
        {
            if ( rendetlensegSzint > maxRend)
            {
                rendetlensegSzint = maxRend;
            }
        }
    }
}
