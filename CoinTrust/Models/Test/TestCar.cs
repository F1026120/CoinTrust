using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinTrust.Models
{
    public class TestCar
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarId { get; set; }

        public string name { get; set; }

        public TestCarOwner test_car_owner { get; set; }

        public ICollection<TestCarWheel> test_car_wheel { get; set; } //cascade
    }
}