using Airport.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Data.Implementation
{
    public class RepositoryReservation : IRepositoryReservation
    {
        AirportContext context;

        public RepositoryReservation(AirportContext context)
        {
            this.context = context;
        }
        public void Add(Reservation item)
        {
            throw new NotImplementedException();
        }

        public Reservation FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(Reservation item)
        {
            throw new NotImplementedException();
        }
    }
}
