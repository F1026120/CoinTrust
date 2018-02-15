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

        public string Name { get; set; }

        public TestCarOwner TestCarOwner { get; set; }

        public ICollection<TestCarWheel> TestCarWheel { get; set; } //cascade
    }
}