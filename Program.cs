using System;

namespace ConvertireBaza
{
    class Program
    {
        static string convertireInBaza10(string n, int baza)
        {
            double rezultat = 0;
            int putere, lungime;
            if(n.IndexOf('.') == -1)
            {
                putere = n.Length - 1;
                lungime = n.Length;
            }
            else
            {
                putere = n.IndexOf('.') - 1;
                lungime = n.IndexOf('.');
            }
            for(int i = 0; i < lungime; i++)
            {
                if(char.IsDigit(n[i]))
                    rezultat += (n[i] - '0') * Math.Pow(baza, putere);
                else
                    rezultat += (n[i] - '7') * Math.Pow(baza, putere);
                putere -= 1;
            }

            if(n.IndexOf('.') != -1)
            {
                putere = 1;
                for(int i = n.IndexOf('.') + 1; i < n.Length; i++)
                {
                    if (char.IsDigit(n[i]))
                        rezultat += (n[i] - '0') * 1 / Math.Pow(baza, putere);
                    else
                        rezultat += (n[i] - '7') * 1 / Math.Pow(baza, putere);
                
                    putere += 1;
                }

                rezultat = Math.Round(rezultat, n.Length - n.IndexOf('.'));
            }
            //Console.WriteLine(rezultat);
            return rezultat.ToString();
        }
        static string reverse(string x)
        {
            char[] sirchar = x.ToCharArray();
            Array.Reverse(sirchar);
            return new string(sirchar);
        }

        static void convertireInBazaX(string n, int baza)
        {
            int precizia = 0;
            string rezultat;
            if (n.IndexOf('.') == -1)
            {
                precizia = 0;
                rezultat = "";
            }
            else
            {
                precizia = n.Length - n.IndexOf('.') - 1;
                rezultat = ".";
            }
            double nr = double.Parse(n);
            int zecimal = (int)nr;
            double fractionar = Math.Round(nr - zecimal, precizia);
            while(zecimal > 0)
            {
                if(zecimal % baza < 10)
                {
                    rezultat += (zecimal % baza).ToString();
                    zecimal /= baza;
                }
                else
                {
                    rezultat += Char.ToString((char)(zecimal % baza + '7'));
                    zecimal /= baza;
                }
            }
            rezultat = reverse(rezultat);
            for(int i = 0; i < (precizia + 1) && fractionar > 0; i++)
            {
                if(fractionar * baza < 10)
                {
                    rezultat += ((int)(fractionar * baza)).ToString();
                    fractionar = Math.Round(fractionar * baza - (int)(fractionar * baza), precizia);
                }
                else
                {
                    rezultat += Char.ToString((char)((int)(fractionar * baza) + '7'));
                    fractionar = Math.Round(fractionar * baza - (int)(fractionar * baza), precizia);
                }
            }
            Console.WriteLine(rezultat);

        }

        static void Main(string[] args)
        {
            while (true)
            {
                string n;
                int baza, baza2;

                Console.Write("Introduceti numarul de convertit: ");
                n = Console.ReadLine();

                try
                {
                    System.ArgumentException argEx = new System.ArgumentException();
                    Console.Write("Introduceti baza numarului: ");
                    baza = int.Parse(Console.ReadLine());
                    if (baza > 16)
                    {
                        throw argEx;
                    }
                    Console.Write("Introduceti baza in care doriti sa convertiti: ");
                    baza2 = int.Parse(Console.ReadLine());
                    if(baza2 > 16)
                    {
                        throw argEx;
                    }
                }
                catch(FormatException)
                {
                    Console.WriteLine("Baza numarului este gresita!");
                    continue;
                }
                catch(OverflowException)
                {
                    Console.WriteLine("Baza numarului este mai mare de 16!");
                    continue;
                }
                catch(ArgumentException)
                {
                    Console.WriteLine("Baza numarului trebuie sa fie mai mica de 16!");
                    continue;
                }

               

                //convertireInBazaX(convertireInBaza10(n, baza), baza2);

            }


        }
    }
}
