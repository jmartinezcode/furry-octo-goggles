using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tmc.Models
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name="Profile Name")]
        public string ProfileName { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [ForeignKey("IdentityUser")]
        public string UserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

    }
}
