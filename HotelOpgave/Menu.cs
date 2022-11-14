using HotelOpgave.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOpgave
{
    public class Menu
    {
        private readonly IFacilityService facilityService;
        private List<string> options = new List<string>();
        private ConsoleKey cKey;
        public Menu(IFacilityService facilityService)
        {
            this.facilityService = facilityService;
        }

        public void Run(string[] args)
        {
            bool running = true;            

            options = new List<string>
            {
                new string("See All Facilities"),
                new string("Create Facility"),
                new string("Update Facility"),
                new string("Delete Facility"),
                new string("Exit Program")
            };

            while (running)
            {
                Console.CursorVisible = false;
                Console.Clear();
                int choice = PrintMenu(options);
                switch (choice)
                {
                    case 0:
                        facilityService.GetAllFacilities();
                        Console.WriteLine("\nPress any key to continue");
                        Console.ReadKey();
                        break;
                    case 1:
                        facilityService.CreateFacility();
                        break;
                    case 2:
                        facilityService.UpdateFacility();
                        break;
                    case 3:
                        facilityService.DeleteFacility();
                        break;
                    case 4:
                        running = false;
                        break;
                    default:
                        break;
                }
            }
            Environment.Exit(0);
        }
        private int PrintMenu(List<string> options)
        {
            int index = 0;
            do
            {
                Console.Clear();
                if (!options.IsNullOrEmpty())
                {
                    for (int i = 0; i < options?.Count; i++)
                    {
                        if (i == index)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($">{options[i]}<");
                        }
                        else
                        {
                            Console.WriteLine($" {options[i]}");
                        }
                        Console.ResetColor();
                    }
                }

                cKey = Console.ReadKey(true).Key;

                switch (cKey)
                {
                    case ConsoleKey.UpArrow:
                        if (index != 0) { index--; }
                        break;
                    case ConsoleKey.DownArrow:
                        if (index != options?.Count - 1) { index++; }
                        break;
                    default:
                        break;
                }
            } while (cKey != ConsoleKey.Enter);

            return index;
        }
    }
}
