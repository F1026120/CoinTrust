using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinTrust.Models
{
    public class TestCarKey
    {
        [Key, ForeignKey("TestCar")]
        [Required]
        public int TestCarId { get; set; }
        
        public string Type { get; set; }

        public virtual TestCar TestCar { get; set; }
    }
}