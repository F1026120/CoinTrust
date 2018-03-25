using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoinTrust.Models
{
    public class RealCoinType
    {
        /*
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RealCoinTypeId { get; set; }
        */

        [Key]
        [Required]
        public string Name { get; set; }
    }
}