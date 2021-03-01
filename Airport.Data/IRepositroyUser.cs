using Airport.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Airport.Data
{
    public interface IRepositroyUser : IRepository<User>
    {
        User FindByEmail(string email);
        User GetOne(Expression<Func<User, bool>> func);
    }
}
