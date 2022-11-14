using HotelOpgave.Interfaces;
using HotelOpgave.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOpgave
{
    public class App
    {
        private readonly Menu menu;

        public App(Menu menu)
        {
            this.menu = menu;
        }
        public void Run(string[] args)
        {
            menu.Run(args);
        }
    }
}
