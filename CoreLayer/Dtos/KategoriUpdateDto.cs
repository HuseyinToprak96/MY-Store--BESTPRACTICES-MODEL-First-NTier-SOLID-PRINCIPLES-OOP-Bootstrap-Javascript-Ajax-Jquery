using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dtos
{
    public class KategoriUpdateDto
    {
        public int Id { get; set; }
        public string KategoriAdi { get; set; }
        public string Renk { get; set; }
    }
}
