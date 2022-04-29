﻿using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Repository
{
   public interface IUyeRepository:IRepository<Uye>
    {
        Task<Uye> UyeLogin(string mail, string sifre);
        Task Yetkilendir(bool yetki,int id);
        Task<Uye> uyeDetay(int UyeId);
    }
}
