using SportsAcademyDen.Data;
using SportsAcademyDen.Models;
using System;
using System.Linq;

namespace SportsAcademyDen.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SportContext context)
        {
            // Look for any players.
            if (context.Players.Any())
            {
                return;   // DB has been seeded
            }

            var players = new Player[]
            {
                new Player{FirstMidName="John",LastName="Doe",FixtureDate=DateTime.Parse("2024-01-01"),DateOfBirth=DateTime.Parse("1990-01-01"),ContactNumber="1234567890"},
                new Player{FirstMidName="Jane",LastName="Smith",FixtureDate=DateTime.Parse("2024-01-08"),DateOfBirth=DateTime.Parse("1992-02-02"),ContactNumber="0987654321"},
                new Player{FirstMidName="Bob",LastName="Johnson",FixtureDate = DateTime.Parse("2024-11-23"), DateOfBirth=DateTime.Parse("1988-03-03"),ContactNumber="1122334455"},
                new Player{FirstMidName="Alice",LastName="Williams",FixtureDate=DateTime.Parse("2024-05-07"),DateOfBirth=DateTime.Parse("1995-04-04"),ContactNumber="6677889900"}
            };

            context.Players.AddRange(players);
            context.SaveChanges();

            var sports = new Sport[]
            {
                new Sport{SportName="Football"},
                new Sport{SportName="Basketball"},
                new Sport{SportName="Tennis"},
                new Sport{SportName="Rugby"}
            };

            context.Sports.AddRange(sports);
            context.SaveChanges();

            var fixtures = new Fixture[]
            {
                new Fixture{FixtureTitle="Match 1", PlayerID=1,SportID=1,FixtureLocation="Stadium 1", FixtureStatus="Scheduled"},
                new Fixture{FixtureTitle="Match 2", PlayerID=2,SportID=2,FixtureLocation="Stadium 2", FixtureStatus="Completed"},
                new Fixture{FixtureTitle="Match 3", PlayerID=3,SportID=3,FixtureLocation="Stadium 3", FixtureStatus="Cancelled"},
                new Fixture{FixtureTitle="Match 4", PlayerID=4,SportID=4,FixtureLocation="Stadium 4", FixtureStatus="Postponed"}
            };

            context.Fixtures.AddRange(fixtures);
            context.SaveChanges();

            var coaches = new Coach[]
            {
                new Coach{FirstName="Michael", LastName="Brown", ContactNumber="4455667788", CoachAddress="123 Main St", SportID=1},
                new Coach{FirstName="Sarah", LastName="Davis", ContactNumber="9988776655", CoachAddress="456 Elm St", SportID=2},
                new Coach{FirstName="David", LastName="Wilson", ContactNumber="3344556677", CoachAddress="789 Oak St", SportID=3},
                new Coach{FirstName="Jojo", LastName="Bojo", ContactNumber="3344625467", CoachAddress="657 Bolu St", SportID=4}
            };

            context.Coaches.AddRange(coaches);
            context.SaveChanges();
        }
    }
}
