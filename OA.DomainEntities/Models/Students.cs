using System;
using System.ComponentModel.DataAnnotations;

//namespace OA.DomainEntities.Models
namespace OA.DomainEntities.Entities
{
    [MetadataType(typeof(StudentsMetaData))]
    public partial class Students
    {

    }

    public class StudentsMetaData
    {
        [Required(ErrorMessage ="Name is Required Field...!!")]
        [MinLength(3 , ErrorMessage ="Name must not less than 3 char...!")]
        [MaxLength(50 , ErrorMessage ="Name must not exceed 50 char....!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Date of Birth is Required Field...!!")]
        [DataType(DataType.Date)]
        [Display(Name ="Date of Birth")]
        public Nullable<System.DateTime> DateOfBirth { get; set; }

        [Required(ErrorMessage = "Image is Required Field...!!")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Phone number is Required Field...!!")]
        [MaxLength(11 , ErrorMessage ="Phone Number not greater than 11 chars ..!!")]
        [RegularExpression(@"^(\d{11})$", ErrorMessage = "Wrong mobile must be 11 number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Faculty is Required Field...!!")]
        public Nullable<int> FacultyID { get; set; }
    }
}
