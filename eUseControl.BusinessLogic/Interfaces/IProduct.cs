using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities.Product;

namespace eUseControl.BusinessLogic.Interfaces
{
    public class IProduct
    {
        ProductDetail GetDetailProduct(int id);
    }
}
