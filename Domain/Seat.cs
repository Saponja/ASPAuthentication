using System.Collections.Generic;

namespace Airport.Domain
{
    public class Seat
    {
        public int SeatId { get; set; }
        public string Class { get; set; }
        public double Price { get; set; }
        public int AirplaneId { get; set; }

        public List<Reservation> Passangers { get; set; }
    }
}