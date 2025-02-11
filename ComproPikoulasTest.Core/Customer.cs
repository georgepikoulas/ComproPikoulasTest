﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ComproPikoulasTest.Core
{
    public class Customer
    {
        public int ID { get; set; }


        [DisplayName("Name")]
        [Required(ErrorMessage = "The Name is required.")]
        [StringLength(50)]
        public string Name { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "The Last Name is required.")]
        [StringLength(70)]
        public string LastName { get; set; }

        [Display(Name = "Email address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
    ErrorMessage = "The email address is not entered in a correct format")]
        public string? Email { get; set; }

        [Phone]
        [StringLength(10) ]

        public string? Phone { get; set; }

        public virtual List<Order>? Orders { get; set; }

    }
}
