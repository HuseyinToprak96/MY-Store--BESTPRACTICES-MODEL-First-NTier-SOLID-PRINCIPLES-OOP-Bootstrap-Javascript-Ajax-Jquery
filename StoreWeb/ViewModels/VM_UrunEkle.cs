using CoreLayer.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWeb.ViewModels
{
    public class VM_UrunEkle
    {
        public IFormFile formFile { get; set; }
        public Urun urun { get; set; }
    }
}
