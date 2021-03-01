using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Domain
{
    public class AirportContext : DbContext
    {
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Passanger> Passangers { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=AirDatabase;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>(r =>
            {
                r.HasKey(r => new { r.SeatId, r.PassangerId, r.DateOfReservation });
                r.HasOne(r => r.Seat).WithMany(s => s.Passangers).OnDelete(DeleteBehavior.Restrict);
                r.HasOne(r => r.Passanger).WithMany(p => p.Seats).OnDelete(DeleteBehavior.Restrict);
                r.HasIndex(r => r.SeatId).IsUnique();
            });

            //modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            //modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();




            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airplane>().HasData(
                new Airplane
                {
                    AirplaneId = 1,
                    Name = "Airplane1",
                    Company = Company.Aeroflot,
                    Model = "Model1",
                },
                new Airplane
                {
                    AirplaneId = 2,
                    Name = "Airplane2",
                    Company = Company.AirSerbia,
                    Model = "Model2"
                },
                new Airplane
                {
                    AirplaneId = 3,
                    Name = "Airplane3",
                    Company = Company.Lufthansa,
                    Model = "Model1"
                },
                new Airplane
                {
                    AirplaneId = 4,
                    Name = "Airplane4",
                    Company = Company.BritishAirways,
                    Model = "Model3"
                },
                new Airplane
                {
                    AirplaneId = 5,
                    Name = "Airplane5",
                    Company = Company.Lufthansa,
                    Model = "Model2"
                },
                new Airplane
                {
                    AirplaneId = 6,
                    Name = "Airplane6",
                    Company = Company.TurkishAirlines,
                    Model = "Model6"
                }
            );

            modelBuilder.Entity<Seat>().HasData(
                new Seat
                {
                   SeatId = 1,
                   Class = "Business",
                   Price = 150,
                   AirplaneId = 1
                },
                new Seat
                {
                    SeatId = 2,
                    Class = "Business",
                    Price = 180,
                    AirplaneId = 1
                },
                new Seat
                {
                    SeatId = 3,
                    Class = "Economy",
                    Price = 100,
                    AirplaneId = 1
                },
                new Seat
                {
                    SeatId = 4,
                    Class = "FirstClass",
                    Price = 220,
                    AirplaneId = 1
                },
                new Seat
                {
                    SeatId = 5,
                    Class = "Business",
                    Price = 160,
                    AirplaneId = 2
                },
                new Seat
                {
                    SeatId = 6,
                    Class = "Economy",
                    Price = 90,
                    AirplaneId = 2
                },
                new Seat
                {
                    SeatId = 7,
                    Class = "Economy",
                    Price = 100,
                    AirplaneId = 2
                },
                new Seat
                {
                    SeatId = 8,
                    Class = "FirstClass",
                    Price = 250,
                    AirplaneId = 3
                },
                new Seat
                {
                    SeatId = 9,
                    Class = "Business",
                    Price = 190,
                    AirplaneId = 3
                },
                new Seat
                {
                    SeatId = 10,
                    Class = "Economy",
                    Price = 80,
                    AirplaneId = 4
                },
                new Seat
                {
                    SeatId = 11,
                    Class = "Economy",
                    Price = 110,
                    AirplaneId = 4
                },
                new Seat
                {
                    SeatId = 12,
                    Class = "Business",
                    Price = 175,
                    AirplaneId = 5
                },
                new Seat
                {
                    SeatId = 13,
                    Class = "Economy",
                    Price = 120,
                    AirplaneId = 5
                },
                new Seat
                {
                    SeatId = 14,
                    Class = "FirstClass",
                    Price = 225,
                    AirplaneId = 6
                },
                new Seat
                {
                    SeatId = 15,
                    Class = "FirstClass",
                    Price = 240,
                    AirplaneId = 6
                }
            );

            modelBuilder.Entity<Passanger>().HasData(
                new Passanger
                {
                    PassangerId = 1,
                    FirstName = "Jovan",
                    LastName = "Saponjic",
                    Age = 21
                },
                new Passanger
                {
                    PassangerId = 2,
                    FirstName = "Pera",
                    LastName = "Peric",
                    Age = 30

                },
                new Passanger
                {
                    PassangerId = 3,
                    FirstName = "Zika",
                    LastName = "Zikic",
                    Age = 45

                },
                new Passanger
                {
                    PassangerId = 4,
                    FirstName = "Milan",
                    LastName = "Jovanovic",
                    Age = 17

                }
            );

            modelBuilder.Entity<Reservation>().HasData(
                new Reservation 
                {
                    PassangerId = 1,
                    SeatId = 2,
                    DateOfReservation = DateTime.Now
                },
                new Reservation
                {
                    PassangerId = 1,
                    SeatId = 14,
                    DateOfReservation = DateTime.Now
                },
                new Reservation
                {
                    PassangerId = 2,
                    SeatId = 4,
                    DateOfReservation = DateTime.Now
                },
                new Reservation
                {
                    PassangerId = 3,
                    SeatId = 11,
                    DateOfReservation = DateTime.Now
                },
                new Reservation
                {
                    PassangerId = 4,
                    SeatId = 6,
                    DateOfReservation = DateTime.Now
                }
            );

            modelBuilder.Entity<Flight>().HasData(
                new Flight
                {
                    FlightId = 1,
                    AirplaneId = 1,
                    Destination = "Mexico City",
                    FlightDuration = 17

                },
                new Flight
                {
                    FlightId = 2,
                    AirplaneId = 1,
                    Destination = "New York",
                    FlightDuration = 21

                },
                new Flight
                {
                    FlightId = 3,
                    AirplaneId = 2,
                    Destination = "Mexico City",
                    FlightDuration = 14

                },
                new Flight
                {
                    FlightId = 4,
                    AirplaneId = 3,
                    Destination = "Madrid",
                    FlightDuration = 5

                },
                new Flight
                {
                    FlightId = 5,
                    AirplaneId = 4,
                    Destination = "Moscow",
                    FlightDuration = 6

                },
                new Flight
                {
                    FlightId = 6,
                    AirplaneId = 5,
                    Destination = "London",
                    FlightDuration = 8

                },
                new Flight
                {
                    FlightId = 7,
                    AirplaneId = 5,
                    Destination = "Melbourne",
                    FlightDuration = 25

                }
                );

            

        }

    }
}
