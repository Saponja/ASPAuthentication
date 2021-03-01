using System;

namespace Airport.Domain
{
    public class Reservation
    {
        public int SeatId { get; set; }
        public Seat Seat { get; set; }
        public int PassangerId { get; set; }
        public Passanger Passanger { get; set; }
        public DateTime DateOfReservation { get; set; }
    }
}