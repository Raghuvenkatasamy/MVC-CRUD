﻿using System;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace DataAccessLayer
{
    public class MobileDetail
    {
        
        public long MobileId { get; set; }

        [Required(ErrorMessage = "Please enter your name"), MaxLength(50)]
        [StringLength(50, ErrorMessage = "Please do not enter values over 50 characters")]
        [RegularExpression("[A-Z]+[a-z]*",ErrorMessage = "Please enter correct formate 1-Caps is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your name"), MaxLength(50)]
        [StringLength(100, ErrorMessage = "Please do not enter values over 100 characters")]
        [RegularExpression("[A-Z]+[a-z]*", ErrorMessage = "Please enter correct formate")]
        public string ManufactureName { get; set; }
        [Required]
        public DateTime DateofMaufacture { get; set; }
        [Required]
        [RegularExpression("[0-9]{4}",ErrorMessage = "Please enter correct formate")]
        public long YearofMaufacture { get; set; }
        [Required]
        [Range(0, 20, ErrorMessage = "Please enter the correct value it should in b/w 0-20")]
        public int Quantity { get; set; }
    }
}
