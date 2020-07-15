using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatProject.Models
{
    public class BoatDetail
    {
        public int Id { get; set; }
        public string BoatName { get; set; }
        public string BoatImage { get; set; }
        public string BoatRate { get; set; }
        public string CustomerName { get; set; }
        public bool IsRented { get; set; }
        public bool IsReturned { get; set; }
        public DateTime RentStart { get; set; }
        public DateTime RentEnd { get; set; }
        public int RentTime { get; set; }
    }
}
