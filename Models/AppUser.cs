﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using ContactsMVC6.Data;
using ContactsMVC6.Models;
using Microsoft.AspNetCore.Authorization;
using ContactsMVC6.Enums;
using ContactsMVC6.Services;
using ContactsMVC6.Services.Interfaces;
namespace ContactsMVC6.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} but no more than {1} characters in length.", MinimumLength = 2)]
        public string? FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} but no more than {1} characters in length.", MinimumLength = 2)]
        public string? LastName { get; set; }
        [NotMapped]
        public string FullName { get { return $"{FirstName} {LastName}"; } }
        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();
        public virtual ICollection<Contact> Contacts { get; set; } = new HashSet<Contact>();
    }
}
