using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.Service.GeoDisaster
{
    public interface IDomainServiceBase<T> where T:class
    {

        void Update(T preplan);

         void Delete(T preplan);

         void Delete(int id);

        void New(T preplan);

         T Get(int id);
    }
}
