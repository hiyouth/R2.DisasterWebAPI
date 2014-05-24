using R2.Disaster.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.Service
{
   public interface ICategoryService
    {
        Category FindById(int id);
        IList<Product> FindProductsById(int id);
    }
}
