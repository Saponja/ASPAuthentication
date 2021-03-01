using Airport.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Airport.Data.Implementation
{
    public class RepositoryFlight : IRepositoryFlight
    {
        AirportContext context;

        public RepositoryFlight(AirportContext context)
        {
            this.context = context;
        }
        public void Add(Flight item)
        {
            throw new NotImplementedException();
        }

        public Flight FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Flight> GetAll()
        {
            return context.Flights.ToList();
        }

        public void Remove(Flight item)
        {
            throw new NotImplementedException();
        }
    }
}
