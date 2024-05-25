using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RZD
{
    public static class DbControl
    {
        public static void AddUser(User user)
        {
            using (var ctx = new ApplicationContext())
            {
                ctx.Users.Add(user);
                ctx.SaveChanges();
            }
        }
        public static void AddTrain(Train train)
        {
            using (var ctx = new ApplicationContext())
            {
                ctx.Trains.Add(train);
                ctx.SaveChanges();
            }
        }
        public static void EditTrain(Train train)
        {
            using (var ctx = new ApplicationContext())
            {
                ctx.Trains.Update(train);
                ctx.SaveChanges();
            }
        }
        public static void AddRailwayEngineerInspections(RailwayEngineerInspection way)
        {
            using (var ctx = new ApplicationContext())
            {
                ctx.RailwayEngineerInspections.Add(way);
                ctx.SaveChanges();
            }
        }
        public static void EditRailwayEngineerInspections(RailwayEngineerInspection way)
        {
            using (var ctx = new ApplicationContext())
            {
               ctx.RailwayEngineerInspections.Update(way);
               ctx.SaveChanges();
            }
        }
        public static void AddInspectionsAuditorTrains(InspectionsAuditorTrain inspectionsAuditorTrains)
        {
            using (var ctx = new ApplicationContext())
            {
                ctx.InspectionsAuditorTrains.Add(inspectionsAuditorTrains);
                ctx.SaveChanges();
            }
        }
        public static void EditInspectionsAuditorTrains(InspectionsAuditorTrain inspectionsAuditorTrains)
        {
            using (var ctx = new ApplicationContext())
            {
                ctx.InspectionsAuditorTrains.Update(inspectionsAuditorTrains);
                ctx.SaveChanges();
            }
        }
        public static void AddInspectionsAuditorWays(InspectionsAuditorWay inspectionsAuditorWays)
        {
            using (var ctx = new ApplicationContext())
            {
                ctx.InspectionsAuditorWays.Add(inspectionsAuditorWays);
                ctx.SaveChanges();
            }
        }
        public static void EditInspectionsAuditorWays(InspectionsAuditorWay inspectionsAuditorWays)
        {
            using (var ctx = new ApplicationContext())
            {
                ctx.InspectionsAuditorWays.Update(inspectionsAuditorWays);
                ctx.SaveChanges();
            }
        }
        public static bool LoginVerification(string username)
        {
            using (var ctx = new ApplicationContext())
            {
                return ctx.Users.Any(u => u.Username == username);
            }
        }

        public static bool Authorize(string username, string password, out User? user)
        {
            bool isAuthorize;
            using (var ctx = new ApplicationContext())
            {
                user = null;
                isAuthorize = ctx.Users.Any(u => u.Username == username && u.Password == password);
                if (isAuthorize)
                {
                    user = ctx.Users.Include(u => u.PositionNavigation).FirstOrDefault(u => u.Username == username && u.Password == password);
                }
            }
            return isAuthorize;
        }

        public static User UserFind(User user)
        {
            using (var ctx = new ApplicationContext())
            {
                return ctx.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password)!;
            }
        }

        public static int FindPositionByUsername(string username)
        {
            using (var ctx = new ApplicationContext())
            {
                return ctx.Users.FirstOrDefault(u => u.Username == username)!.PositionId;
            }
        }

        public static List<Way> GetWays()
        {
            List<Way> ways = new List<Way>();
            using (var context = new ApplicationContext())
            {
                ways = context.Ways.Include(p => p.ViewWaysNavigation).ToList();
            }
            return ways;
        }

        public static List<Train> GetTrains()
        {
            List<Train> trains = new List<Train>();
            using (var context = new ApplicationContext())
            {
                trains = context.Trains.Include(p => p.UserNavigation).ToList();
            }
            return trains;
        }

        public static List<RailwayEngineerInspection> GetRailwayEngineerInspections()
        {
            List<RailwayEngineerInspection> railwayEngineerInspections;
            using (var context = new ApplicationContext())
            {
                railwayEngineerInspections = context.RailwayEngineerInspections.Include(p => p.VwaysNavigation.ViewWaysNavigation).Include(p => p.RailwayEngineer).ToList();
            }
            return railwayEngineerInspections;
        }

        public static List<InspectionsAuditorTrain> GetInspectionsAuditorTrains()
        {
            List<InspectionsAuditorTrain> inspectionsAuditorTrains;
            using (var context = new ApplicationContext())
            {
                inspectionsAuditorTrains = context.InspectionsAuditorTrains.ToList();
            }
            return inspectionsAuditorTrains;
        }

        public static List<InspectionsAuditorWay> GetInspectionsAuditorWays()
        {
            List<InspectionsAuditorWay> inspectionsAuditorWays;
            using (var context = new ApplicationContext())
            {
                inspectionsAuditorWays = context.InspectionsAuditorWays.Include(p => p.NwaysNavigation).ToList();
            }
            return inspectionsAuditorWays;
        }

        public static void RemoveTrains(Train train)
        {
            using (ApplicationContext ctx = new ApplicationContext())
            {
                ctx.Trains.Remove(train);
                ctx.SaveChanges();
            }
        }

        public static void RemoveRailwayEngineerInspections(RailwayEngineerInspection railwayEngineerInspections)
        {
            using (ApplicationContext ctx = new ApplicationContext())
            {
                ctx.RailwayEngineerInspections.Remove(railwayEngineerInspections);
                ctx.SaveChanges();
            }
        }

        public static void RemoveInspectionsAuditorTrains(InspectionsAuditorTrain inspectionsAuditorTrains)
        {
            using (ApplicationContext ctx = new ApplicationContext())
            {
                ctx.InspectionsAuditorTrains.Remove(inspectionsAuditorTrains);
                ctx.SaveChanges();
            }
        }

        public static void RemoveInspectionsAuditorWays(InspectionsAuditorWay inspectionsAuditorWays)
        {
            using (ApplicationContext ctx = new ApplicationContext())
            {
                ctx.InspectionsAuditorWays.Remove(inspectionsAuditorWays);
                ctx.SaveChanges();
            }
        }

        public static List<Floor> GetGenderStatus()
        {
            using (ApplicationContext ctx = new ApplicationContext())
            {
                return ctx.Floors.ToList();
            }
        }

        public static List<Position> GetPositionStatus()
        {
            using (ApplicationContext ctx = new ApplicationContext())
            {
                return ctx.Positions.ToList();
            }
        }
    }
}