using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "please Enter the Customer Name ")]

        [StringLength(200)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        
        public byte MembershipTypeId { get; set; }
        public MembershipTypeDto MembershipType { get; set; }

        
        //[Min18]
        public DateTime? BirthDate { get; set; }
    }
}