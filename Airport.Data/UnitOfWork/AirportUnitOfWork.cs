using Airport.Data.Implementation;
using Airport.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Data.UnitOfWork
{
    public class AirportUnitOfWork : IUnitOfWork
    {
        AirportContext context;

        public AirportUnitOfWork(AirportContext context)
        {
            this.context = context;
            Airplane = new RepositoryAirplane(context);
            Passanger = new RepositoryPassanger(context);
            Reservation = new RepositoryReservation(context);
            Seat = new RepositorySeat(context);
            Flight = new RepositoryFlight(context);
            User = new RepositoryUser(context);
        }

        public IRepositoryAirplane Airplane { get; set; }
        public IRepositoryPassanger Passanger { get; set; }
        public IRepositoryReservation Reservation { get; set; }
        public IRepositoryFlight Flight { get; set; }
        public IRepositorySeat Seat { get; set; }
        public IRepositroyUser User { get; set; }

        public void Commit()
        {
            context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
