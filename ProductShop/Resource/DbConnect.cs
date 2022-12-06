using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.Resource
{
   static class DbConnect
    {
        public static ProductShopEntities db { get; } = new ProductShopEntities();
    

        static DbConnect()
        {
            
        }
    }

}
