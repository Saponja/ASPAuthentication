using Airport.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Data.Implementation
{
    public class RepositoryPassanger : IRepositoryPassanger
    {
        AirportContext context;

        public RepositoryPassanger(AirportContext context)
        {
            this.context = context;
        }
        public void Add(Passanger item)
        {
            throw new NotImplementedException();
        }

        public Passanger FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Passanger> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(Passanger item)
        {
            throw new NotImplementedException();
        }
    }
}
