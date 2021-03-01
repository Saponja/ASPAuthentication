using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Domain
{
    public class Flight
    {
        public int FlightId { get; set; }
        public string Destination { get; set; }
        public double FlightDuration { get; set; }
        public int AirplaneId { get; set; }
        public Airplane Airplane { get; set; }
    }
}
