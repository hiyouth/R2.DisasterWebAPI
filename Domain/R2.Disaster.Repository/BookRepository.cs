using R2.Disaster.CoreEntities;
using R2.Disaster.Data;
using R2.Disaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.Repository
{
    public class BookRepository:EFRepository<Book>,IBookRepository
    {
        public BookRepository(IDbContext db):base(db)
        {
            
        }
        public string GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
