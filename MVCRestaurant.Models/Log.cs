using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRestaurant.Models
{
    public class Log
    {
        [Key]
        public ulong Id { get; set; }

        [Required]
        public string UserId {get; set;}

        [Required]
        public string Description { get; set; }

        [Required]
        public bool ErrorEncountered { get; set; }

        [Required]
        public DateTime SubmitDate { get; set; }
    }
}
