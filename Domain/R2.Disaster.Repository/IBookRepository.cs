using R2.Disaster.CoreEntities;
using R2.Disaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.Repository
{
    public interface IBookRepository:IRepository<Book>
    {
        string GetByName(string name);
    }
}
