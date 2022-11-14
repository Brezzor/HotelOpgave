using HotelOpgave.Interfaces;
using HotelOpgave.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOpgave.Services
{
    public class FacilityService : IFacilityService
    {
        private readonly HotelDbContext context;

        public FacilityService(HotelDbContext context)
        {
            this.context = context;
        }

        private IEnumerable<Facility> Facilities()
        {
            return context.Facilities.AsNoTracking();
        }

        private Facility CreateNewFacility(string? name)
        {
            return new Facility
            {
                Name = name
            };
        }

        private Facility GetFacilityById(int id)
        {
            return context.Facilities.AsNoTracking().FirstOrDefault(f => f.Fac_Id == id);
        }

        public void GetAllFacilities()
        {
            Console.Clear();
            Console.WriteLine("Getting List Of Facilities...\n");

            IEnumerable<Facility> facilities = Facilities();
            foreach (Facility facility in facilities)
            {
                Console.WriteLine(facility);
            }            
        }

        public void CreateFacility()
        {
            bool done = false;
            ConsoleKeyInfo keyInfo;

            Console.Clear();
            Console.WriteLine("Create a New Facility...\n");

            Console.WriteLine("Choose a name for the Facility");
            Console.Write("Name:");
            Console.CursorVisible = true;
            string? name = Console.ReadLine();

            Console.WriteLine("\nPress Enter to Confirm or Escape to cancel");
            do
            {
                keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Enter:
                        Console.WriteLine("Creating Facility...\n");
                        Facility facility = CreateNewFacility(name);
                        context.Add(facility);
                        context.SaveChanges();
                        Console.WriteLine("Facility created");
                        Console.WriteLine(facility);
                        done = true;
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("\nCreation cancelled");
                        done = true;
                        break;
                    default:
                        break;
                }

            } while (!done);

            Console.WriteLine("\nPress any key to continue");
            Console.Read();
        }

        public void UpdateFacility()
        {
            bool done = false;
            ConsoleKeyInfo keyInfo;

            Console.Clear();
            Console.WriteLine("Update a Facility...\n");
            GetAllFacilities();

            Console.WriteLine("Choose the Id of the Facility you want to update");            
            Console.CursorVisible = true;
            string? input;
            do
            {
                Console.Write("Id:");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out int id));      

            //Console.WriteLine("\nPress Enter to Confirm or Escape to cancel");
            //do
            //{
            //    keyInfo = Console.ReadKey(true);
            //    switch (keyInfo.Key)
            //    {
            //        case ConsoleKey.Enter:
            //            Console.WriteLine("Udating Facility...\n");
            //            Facility facility = UpdateFacility(result);
            //            context.Add(facility);
            //            context.SaveChanges();
            //            Console.WriteLine("Facility created");
            //            Console.WriteLine(facility);
            //            done = true;
            //            break;
            //        case ConsoleKey.Escape:
            //            Console.WriteLine("\nCreation cancelled");
            //            done = true;
            //            break;
            //        default:
            //            break;
            //    }

            //} while (!done);

            Console.WriteLine("\nPress any key to continue");
            Console.Read();
        }

        public void DeleteFacility()
        {
            bool done = false;
            ConsoleKeyInfo keyInfo;

            Console.Clear();
            Console.WriteLine("Delete Facility...\n");

            Console.WriteLine("Choose a name for the Facility");
            Console.Write("Name:");
            Console.CursorVisible = true;
            string? name = Console.ReadLine();

            Console.WriteLine("\nPress Enter to Confirm or Escape to cancel");
            do
            {
                keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Enter:
                        Console.WriteLine("Creating Facility...\n");
                        Facility facility = CreateNewFacility(name);
                        context.Add(facility);
                        context.SaveChanges();
                        Console.WriteLine("Facility created");
                        Console.WriteLine(facility);
                        done = true;
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("\nCreation cancelled");
                        done = true;
                        break;
                    default:
                        break;
                }

            } while (!done);

            Console.WriteLine("\nPress any key to continue");
            Console.Read();
        }
    }
}
