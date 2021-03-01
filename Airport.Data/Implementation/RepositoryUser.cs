using Airport.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Airport.Data.Implementation
{
    public class RepositoryUser : IRepositroyUser
    {
        private AirportContext context;

        public RepositoryUser(AirportContext context)
        {
            this.context = context;
        }


        public void Add(User item)
        {
            context.Users.Add(item);
        }

        public User FindByEmail(string email)
        {
            List<User> users = context.Users.ToList();
            User user = users.SingleOrDefault(u => u.Email == email);
            return user;

        }

        public User FindById(int id)
        {
            return null;
        }

        public List<User> GetAll()
        {

            return context.Users.ToList();
        }

        public User GetOne(Expression<Func<User, bool>> func)
        {
            return context.Users.SingleOrDefault(func);
       
        }

        public void Remove(User item)
        {
            context.Users.Remove(item);
        }
    }
}
