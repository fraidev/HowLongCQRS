using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HowLong.Models.Write.Commands
{
    public class Votar
    {
        // public int Id { get; set; }
        public SerieWrite SerieId { get; set; }
        public int Nota { get; set; }
        
    }
}