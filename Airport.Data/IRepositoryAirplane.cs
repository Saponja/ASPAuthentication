using Airport.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Data
{
    public interface IRepositoryAirplane : IRepository<Airplane>
    {
        List<string> GetDestinations(int id);
        Airplane FindByName(string name);
        void Update(Airplane airplane, int id);
        Task AddAsync(Airplane airplane);
        Task<Airplane> FindByNameAsync(string name);
        Task<List<Airplane>> GetAllAsync();
        Task<Airplane> FindByIdAsync(int id);
        Task UpdateAsync(Airplane airplane, int id);

        Task<List<Airplane>> GetAirplanesPerPageAsync(int pageNum, int numOfRows);


    }
}
