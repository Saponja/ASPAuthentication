using Airport.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Data
{
    public interface IRepositoryAirplane : IRepository<Airplane>
    {
        List<string> GetDestinations(int id);
        Airplane FindByName(string name);
        void Update(Airplane airplane, int id);
    }
}
