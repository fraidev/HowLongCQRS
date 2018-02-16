using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HowLong.Models.Write.Commands;

namespace HowLong.Models.Write
{
    public class Voto
    {
        //public int Id { get; set; }
        public int Id { get; set; }
        public int SerieId { get; set; }
        public int Nota { get; set; }
        public int Data { get; set; }
        
    }
}