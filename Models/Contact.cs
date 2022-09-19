using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
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
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public string? AppUserId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} but no more than {1} characters in length.", MinimumLength = 2)]
        public string? FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} but no more than {1} characters in length.", MinimumLength = 2)]
        public string? LastName { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string? EmailAddress { get; set; }
        [NotMapped]
        public string? FullName { get { return $"{FirstName} {LastName}"; } }
        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string? Address1 { get; set; }
        [Display(Name = "Address, line 2")]
        public string? Address2 { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public States State { get; set; }
        [Required]
        [Display(Name = "Zip Code")]
        [DataType(DataType.PostalCode)]
        public int ZipCode { get; set; }
        [Required]
        [Display(Name ="Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }
        //Image properties
        public byte[]? ImageData { get; set; }
        public string? ImageType { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        //Virtuals
        public virtual AppUser? AppUser { get; set; }
        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();





    }
}
