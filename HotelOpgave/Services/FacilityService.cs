using HotelOpgave.Interfaces;
using HotelOpgave.Models;
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
            return context.Facilities;
        }

        public void GetAllFacilities()
        {
            IEnumerable<Facility> facilities = Facilities();
            foreach (Facility facility in facilities)
            {
                Console.WriteLine(facility);
            }
            Console.Read();
        }
    }
}
