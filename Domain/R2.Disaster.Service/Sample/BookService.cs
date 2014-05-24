using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2.Disaster.Repository;
using R2.Disaster.CoreEntities;

namespace R2.Disaster.Service
{
    public class BookService:IBookService
    {
        private IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            this._bookRepository =bookRepository;
        }
        public Book GetByName(string name)
        {
            
            return this._bookRepository.Table.Where(b => b.Name == name).FirstOrDefault();
        }

        public Book GetById(int id)
        {
            return null;
         //   return this._bookRepository.Table.Where(b => b.Id == id).FirstOrDefault();
        }

        public void Delete(Book book)
        {
            this._bookRepository.Delete(book);
        }
    }
}
