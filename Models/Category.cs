using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;
using ContactsMVC6.Data;
using ContactsMVC6.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using ContactsMVC6.Enums;
using ContactsMVC6.Services;
using ContactsMVC6.Services.Interfaces;

namespace ContactsMVC6.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string? AppUserId { get; set; }
        [Required]
        [Display(Name = "Category Name")]
        public string? Name { get; set; }
        //virtual
        public virtual AppUser? AppUser { get; set; }
        //public string? GroupName { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; } = new HashSet<Contact>();
    }
}
