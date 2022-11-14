using HotelOpgave.Interfaces;
using HotelOpgave.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            return context.Facilities;
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

        private Facility? GetFacility()
        {
            int index = 0;
            ConsoleKey ckey;
            Facility? facility = new Facility();
            List<Facility> facilities = Facilities().ToList();
            if (!facilities.IsNullOrEmpty())
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("List of Facilities\n");
                    for (int i = 0; i < facilities.Count(); i++)
                    {
                        if (i == index)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($">{facilities[i]}<");
                        }
                        else
                        {
                            Console.WriteLine($" {facilities[i]}");
                        }
                        Console.ResetColor();
                    }

                    ckey = Console.ReadKey(true).Key;

                    switch (ckey)
                    {
                        case ConsoleKey.UpArrow:
                            if (index != 0) { index--; }
                            break;
                        case ConsoleKey.DownArrow:
                            if (index != facilities.Count() - 1) { index++; }
                            break;
                        default:
                            break;
                    }

                    facility = facilities[index];

                } while (ckey != ConsoleKey.Enter);

                return facility;
            }
            return null;
        }

        public void CreateFacility()
        {
            bool done = false;
            string? name = null;
            ConsoleKeyInfo keyInfo;

            Console.Clear();
            Console.WriteLine("Create a Facility...\n");

            Console.WriteLine("Choose a name for the Facility");            
            Console.CursorVisible = true;
            do
            {
                Console.Write("Name:");
                name = Console.ReadLine();
            } while (string.IsNullOrEmpty(name));
            
            Console.CursorVisible = false;
            
            if (name is not null && name.Length >= 0)
            {
                do
                {
                    Console.WriteLine("\nPress Enter to Confirm or Escape to cancel");
                    keyInfo = Console.ReadKey(true);
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.Enter:
                            try
                            {
                                Console.WriteLine("\nCreating Facility...");
                                Facility? facility = new Facility { Name = name };
                                context.Facilities.Add(facility);
                                context.SaveChanges();
                                Console.WriteLine("\nFacility created");
                                Console.WriteLine(facility);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
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
            }            

            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }

        public void UpdateFacility()
        {
            string? name = null;
            Facility? facility = GetFacility();

            if (facility is not null)
            {
                bool done = false;
                ConsoleKeyInfo keyInfo;

                do
                {
                    Console.Clear();
                    Console.WriteLine("\nPress Enter to Confirm or Escape to cancel");
                    keyInfo = Console.ReadKey(true);
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.Enter:
                            Console.WriteLine("\nChoose a new name for the Facility");
                            Console.CursorVisible = true;
                            do
                            {
                                Console.Write("Name:");
                                name = Console.ReadLine();
                            } while (string.IsNullOrEmpty(name));
                            Console.CursorVisible = false;
                            try
                            {
                                Console.WriteLine("\nUdating Facility...");
                                facility.Name = name;
                                context.Facilities.Update(facility);
                                context.SaveChanges();
                                Console.WriteLine("\nFacility Updated");
                                Console.WriteLine(facility);
                            }
                            catch (Exception ex)
                            {
                                context.Entry(facility).State= EntityState.Detached;
                                context.SaveChanges();
                                Console.WriteLine(ex.Message);
                            }
                            done = true;
                            break;
                        case ConsoleKey.Escape:
                            Console.WriteLine("\nUpdate cancelled");
                            done = true;
                            break;
                        default:
                            break;
                    }

                } while (!done);
            }


            Thread.Sleep(1000);
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }

        public void DeleteFacility()
        {
            Facility? facility = GetFacility();

            if (facility is not null)
            {
                bool done = false;
                ConsoleKeyInfo keyInfo;

                do
                {
                    Console.Clear();
                    Console.WriteLine("\nPress Enter to Confirm or Escape to cancel");
                    keyInfo = Console.ReadKey(true);
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.Enter:
                            try
                            {
                                Console.WriteLine("\nDeleting Facility...");
                                context.Facilities.Remove(facility);
                                context.SaveChanges();
                                Console.WriteLine("\nFacility deleted");
                                Console.WriteLine(facility);
                            }
                            catch (Exception ex)
                            {
                                context.Entry(facility).State = EntityState.Detached;
                                context.SaveChanges();
                                Console.WriteLine(ex.Message);
                            }                            
                            done = true;
                            break;
                        case ConsoleKey.Escape:
                            Console.WriteLine("\nDeletion cancelled");
                            done = true;
                            break;
                        default:
                            break;
                    }

                } while (!done);
            }            

            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }
    }
}
