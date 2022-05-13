using Microsoft.AspNetCore.Http;

namespace CoreLayer.Dtos
{
    public class VitrinDto
    {
        public int Id { get; set; }
        public string Resim { get; set; }
        public string UrunAdi { get; set; }
        public double Ucret { get; set; }
    }
}
