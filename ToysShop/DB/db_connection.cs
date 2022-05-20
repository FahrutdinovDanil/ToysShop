using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToysShop.DB;

namespace ToysShop
{
    class db_connection
    {
        public static ToysShopEntities connection = new ToysShopEntities();
    }
}
