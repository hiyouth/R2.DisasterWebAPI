using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2.Disaster.CoreEntities;
using R2.Disaster.Repository;

namespace R2.Disaster.Service
{
    public class CategoryService:ICategoryService
    {
        private IRepository<Category> _repositoryCategory;
        private IRepository<Product> _repositoryProduct;
        public CategoryService(IRepository<Category> repositoryCategory,IRepository<Product> repositoryProduct)
        {
            this._repositoryCategory = repositoryCategory;
            this._repositoryProduct = repositoryProduct;
        }
        public Category FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Product> FindProductsById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
