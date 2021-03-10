using Airport.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Airport.Data.Implementation
{
    public class RepositoryAirplane : IRepositoryAirplane
    {
        AirportContext context;

        public RepositoryAirplane(AirportContext context)
        {
            this.context = context;
        }

        public void Add(Airplane item)
        {
            context.Airplanes.Add(item);
        }

        public Airplane FindById(int id)
        {
            return context.Airplanes.Include(a => a.Seats).Include(a => a.Flights).ToList().Find(a => a.AirplaneId == id);
        }

        public List<Airplane> GetAll()
        {
            return context.Airplanes.Include(a => a.Seats).Include(a => a.Flights).ToList();
        }

        public void Remove(Airplane item)
        {
            context.Airplanes.Remove(item);
        }

        public List<string> GetDestinations(int id)
        {
            Airplane airplane = context.Airplanes.Include(a => a.Flights).Single(a => a.AirplaneId == id);
            List<Flight> flights = airplane.Flights;
            List<string> destinations = new List<string>();
            flights.ForEach(f => destinations.Add(f.Destination));
            return destinations;
        }

        public void Update(Airplane airplane, int id)
        {
            Airplane updated = context.Airplanes.Find(id);

            updated.Name = airplane.Name;
            updated.Model = airplane.Model;
            updated.Company = airplane.Company;

            context.Airplanes.Update(updated);
        }

        public Airplane FindByName(string name)
        {
            return context.Airplanes.Single(a => a.Name == name);
        }
    }
}
