﻿using CoreLayer.Entities;
using CoreLayer.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Repository
{
   public interface ISepetRepository:IService<Sepet>
    {
        Task SepeteEkle(SepetDetay sepetDetay,int UyeId);
        void SepettenCikar(int SepetDetayId, int UyeId);
    }
}
