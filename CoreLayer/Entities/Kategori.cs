using System.Collections.Generic;

namespace CoreLayer.Entities
{
    public class Kategori
    {
        public int Id { get; set; }
        public string KategoriAdi { get; set; }
        public string Renk { get; set; }
        public bool Goster { get; set; }
        public List<AltKategori> altKategoriler { get; set; }
    }
}
