using HotelOpgave.Interfaces;
using HotelOpgave.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
            Facility? facility;
            List<Facility> facilities = Facilities().ToList();
            if (!facilities.IsNullOrEmpty())
            {
                do
                {
                    Console.Clear();
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
            Console.Write("Name:");
            Console.CursorVisible = true;
            do
            {
                name = Console.ReadLine();
            } while (string.IsNullOrEmpty(name));            
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
                                Facility? facility = new Facility(name);
                                context.Add(facility);
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
                                context.Remove(facility);
                                context.SaveChanges();
                                Console.WriteLine("\nFacility deleted");
                                Console.WriteLine(facility);
                            }
                            catch (Exception ex)
                            {
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
            //int id;
            //bool done = false;
            //ConsoleKeyInfo keyInfo;

            //Console.Clear();
            //Console.WriteLine("Delete a Facility...\n");
            //GetAllFacilities();

            //Console.WriteLine("\nChoose the Id of the Facility you want to delete");
            //Console.CursorVisible = true;
            //Console.Write("Id:");
            //string? input = Console.ReadLine();
            //while (!int.TryParse(input, out id))
            //{
            //    Console.Write("Id:");
            //    input = Console.ReadLine();
            //} 
            //Console.WriteLine("\nPress Enter to Confirm or Escape to cancel");
            //do
            //{
            //    keyInfo = Console.ReadKey(true);
            //    switch (keyInfo.Key)
            //    {
            //        case ConsoleKey.Enter:
            //            Console.WriteLine("Deleting Facility...\n");
            //            Facility? facility = GetFacilityById(id);
            //            context.Add(facility);
            //            context.SaveChanges();
            //            Console.WriteLine("Facility deleted");
            //            Console.WriteLine(facility);
            //            done = true;
            //            break;
            //        case ConsoleKey.Escape:
            //            Console.WriteLine("\nDeletion cancelled");
            //            done = true;
            //            break;
            //        default:
            //            break;
            //    }

            //} while (!done);

            Console.WriteLine("\nPress any key to continue");
            Console.Read();
        }
    }
}
