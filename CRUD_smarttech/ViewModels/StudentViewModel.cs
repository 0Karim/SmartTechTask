using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OA.DomainEntities.Entities;

namespace CRUD_smarttech.ViewModels
{
    public class StudentViewModel
    {

        [HiddenInput]
        public int ID { set; get; }

        [Required(ErrorMessage = "Name is Required Field...!!")]
        [MinLength(3, ErrorMessage = "Name must not less than 3 char...!")]
        [MaxLength(50, ErrorMessage = "Name must not exceed 50 char....!")]
        [Display(Name="Student Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Date of Birth is Required Field...!!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Birth")]
        public Nullable<System.DateTime> DateOfBirth { get; set; }

        [Required(ErrorMessage = "Image is Required Field...!!")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Phone number is Required Field...!!")]
        [MaxLength(11, ErrorMessage = "Phone Number not greater than 11 chars ..!!")]
        [RegularExpression(@"^(\d{11})$", ErrorMessage = "Wrong mobile must be 11 number")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name="Mobile No")]
        public string Phone { get; set; }

        public string Address { set; get; }

        [Required(ErrorMessage = "Faculty is Required Field...!!")]
        public Nullable<int> FacultyID { get; set; }

        //public Students student { set; get; }
        [Display(Name="Select Faculty")]
        public List<Faculties> faculties { set; get; }
    }
}