using Airport.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Data.Implementation
{
    public class RepositorySeat : IRepositorySeat
    {
        AirportContext context;

        public RepositorySeat(AirportContext context)
        {
            this.context = context;
        }
        public void Add(Seat item)
        {
            throw new NotImplementedException();
        }

        public Seat FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Seat> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(Seat item)
        {
            throw new NotImplementedException();
        }
    }
}
