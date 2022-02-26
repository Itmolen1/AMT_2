using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.ViewModels
{
    public class TransictionTrailBalance
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string AccountTitle { get; set; }
        [DataType(DataType.Currency)]
        public float? Dr { get; set; }
        [DataType(DataType.Currency)]
        public float? Cr { get; set; }
    }
}
