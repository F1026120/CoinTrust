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
        [Key, ForeignKey("test_car")]
        [Required]
        public int TestCarId { get; set; }
        
        public string type { get; set; }

        public TestCar test_car { get; set; }
    }
}