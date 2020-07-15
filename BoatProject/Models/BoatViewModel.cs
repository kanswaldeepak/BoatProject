using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatProject.Models
{
    public class BoatViewModel
    {
        public string BoatName { get; set; }
        public string BoatRate { get; set; }
        public IFormFile BoatImage { get; set; }
    }
}
