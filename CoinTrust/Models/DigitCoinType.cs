using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoinTrust.Models
{
    public class DigitCoinType
    {
        //[Key]
        //[Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int DigitCoinTypeId { get; set; }
        [Key]
        [Required]
        public string Name { get; set; }

        [Required]
        public string AddressRegex { get; set; }
    }
}