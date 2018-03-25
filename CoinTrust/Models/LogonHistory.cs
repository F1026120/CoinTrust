using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinTrust.Models
{
    public class LoginHistory
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoginHistoryId { get; set; }

        [Required]
        public Account User { get; set; }

        [Required]
        public string Ip { get; set; }

        
        public string Locale { get; set; }

        [Required]
        public DateTime LoginAt { get; set; }
    }
}