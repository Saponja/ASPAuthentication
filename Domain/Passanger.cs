using System.Collections.Generic;

namespace Airport.Domain
{
    public class Passanger
    {
        public int PassangerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public List<Reservation> Seats { get; set; }
    }
}