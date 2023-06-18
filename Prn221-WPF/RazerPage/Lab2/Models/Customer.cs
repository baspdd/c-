using Lab2.Biding;
using Lab2.Validation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models
{
    public class Customer
    {
        [Required(ErrorMessage = "Customer Name is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "The length of name is from 3 to 20")]
        [Display(Name = "Customer Name")]
        [ModelBinder(BinderType = typeof(CheckNameBiding))]
        public string CustomerName { get; set; }


        [Required(ErrorMessage = "Customer Email is required")]
        [EmailAddress]
        [Display(Name = "Customer Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Year of birth is required")]
        [Display(Name = "Year of birth")]
        [Range(1960,2000, ErrorMessage = "1960 - 2000")]
        [CustomerValidation]
        public string? Year { get; set; }


    }
}
