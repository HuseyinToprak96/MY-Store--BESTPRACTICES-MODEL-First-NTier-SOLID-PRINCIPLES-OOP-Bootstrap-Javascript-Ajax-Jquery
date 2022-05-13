using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWeb.Models
{
    public class Magaza
    {
        public string MagazaAdi { get; set; }
        public string Adres { get; set; }
        public string Resim { get; set; }
        List<Magaza> magazalar = new List<Magaza>();
    public List<Magaza> List()
    {
        for (int i = 1; i < 11; i++)
        {
                Magaza magaza = new Magaza();
                magaza.MagazaAdi = "Magaza" + i;
                magaza.Adres = i + ". il" + (i * 2) + ".ilçe" + i * 401 + ".Sokak" + (i + 3) + " Numara";
                magaza.Resim = "magaza_" + i + ".jpg";
                magazalar.Add(magaza);
        }
            return magazalar;
    }
}}
