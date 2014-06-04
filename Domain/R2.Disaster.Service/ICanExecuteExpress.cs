using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.Service
{
    public interface ICanExecuteExpress<T>
    {
        IQueryable<T> ExecuteConditions(Expression<Func<T, bool>> condition);
    }
}
