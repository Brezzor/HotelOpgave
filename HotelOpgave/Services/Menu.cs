using HotelOpgave.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOpgave.Services
{
    public class Menu
    {
        private readonly IFacilityService facilityService;
        private List<string> options = new List<string>();
        private int index;
        private ConsoleKeyInfo keyInfo;
        private ConsoleKey cKey;
        public Menu(IFacilityService facilityService)
        {
            this.facilityService = facilityService;
        }

        public void Run(string[] args)
        {
            bool running = true;
            Console.CursorVisible = false;

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
                Console.Clear();
                int choice = PrintMenu(options, options[index]);
                switch (choice)
                {
                    case 0:
                        facilityService.GetAllFacilities();
                        break;
                    case 5:
                        running = false;
                        break;                        
                    default:
                        break;
                }
            }
            Environment.Exit(0);
        }        
        private int PrintMenu(List<string> options, string selectedOption)
        {
            do
            {
                Console.Clear();
                if (!options.IsNullOrEmpty())
                {
                    foreach (string option in options)
                    {
                        if (option == selectedOption)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($">{option}<");
                        }
                        else
                        {
                            Console.WriteLine($" {option}");
                        }
                        Console.ResetColor();
                    }
                }

                cKey = Console.ReadKey(true).Key;

                switch (cKey)
                {
                    case ConsoleKey.UpArrow:
                        if (index != options?.Count - 1) { index--; }
                        break;
                    case ConsoleKey.DownArrow:
                        if (index != 0) { index++; }
                        break;
                    default:
                        break;
                }
            } while (cKey != ConsoleKey.Enter);

            return index;
        }
    }
}
