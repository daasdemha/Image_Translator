using System;
using System.Collections.Generic;
using System.Text;

namespace ImagesTranslator.Models
{
    public class Invoice
    {
        public double Total { get; set; } = 15.0;
        public DateTime TimeStamp { get; set; } 
        public string Photo { get; set; } 
    }
}
