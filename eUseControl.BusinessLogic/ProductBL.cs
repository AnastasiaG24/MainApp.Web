using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Product;

namespace eUseControl.BusinessLogic
{
    class ProductBL: UserApi, IProduct
    {
        public ProductDetail GetDetailProduct(int id)
        {
            return GetProdUser(id);
        }

    }
}
