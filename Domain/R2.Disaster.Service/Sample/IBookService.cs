using R2.Disaster.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace R2.Disaster.Service
{
    public interface IBookService
    {
        Book GetByName(string name);

        Book GetById(int id);

        void Delete(Book book);
    }
}
