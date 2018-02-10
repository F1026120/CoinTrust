using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinTrust.Models
{
    public class LogonHistory
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public string user_id { get; set; }

        [ForeignKey("user_id")]
        public User User { get; set; }

        [Required]
        public string ip_address { get; set; }

        [Required]
        public string locale { get; set; }

        [Required]
        public DateTime logon_at { get; set; }
    }
}