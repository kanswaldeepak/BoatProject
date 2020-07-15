using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatProject.ViewModels
{
    public class BoatRentViewModel
    {
        public int Id { get; set; }
        public bool IsRented { get; set; }
        public string CustomerName { get; set; }
    }
}
