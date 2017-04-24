﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerPro.DataObjects
{
    public class RegisterViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Required]
        [RegularExpression(@"[0-9]{10}", ErrorMessage = "Not a valid Phone number")]
        public String Phone { get; set; }

        [Required]
        [Display(Name = "Address Line 1")]
        public string AddressLineOne { get; set; }

        [Required]
        [Display(Name = "Address Line 2")]
        public string AddressLineTwo { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Zip Code is Required")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip Code")]
        public string Zip { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public String EmailAddress { get; set; }

        [Required]
        public String UserName { get; set; }

        public bool Active { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public int JobPosition { get; set; }

        public string JobName { get; set; }

    }
}
