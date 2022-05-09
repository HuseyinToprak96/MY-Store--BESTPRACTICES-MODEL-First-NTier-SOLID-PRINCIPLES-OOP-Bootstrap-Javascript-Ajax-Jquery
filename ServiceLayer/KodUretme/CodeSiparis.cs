using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.KodUretme
{
   public static class CodeSiparis
    {
        public static string KodUret()
        {
            string kod = "";
            string harfler = "ABCDEFGHJKLMNOPRSTUVYZW";
            Random random = new Random();
            for (int i = 0; i < 2; i++)
                kod += harfler[random.Next(0, harfler.Length)];
            kod += "-";
            for (int i = 0; i < 5; i++)
                kod += random.Next(0, 9);
            return kod;
        }
    }
}
