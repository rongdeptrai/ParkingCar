using System.ComponentModel.DataAnnotations;

namespace ParkingCore.Models
{
    public class Adminstrator
    {
        [Key]
        [Required(ErrorMessage = "Khong duoc de trong.")]
        public string AdminID { get; set; }


        [Display(Name = "PkID")]
        public string PkID { get; set; }


        [Display(Name = "Pass")]
        [Required(ErrorMessage = " khong duoc de trong")]
        public string Pass { get; set; }


        [Display(Name = "Pass")]
        [Required(ErrorMessage = " khong duoc de trong")]
        public string UserName { get; set; }

        [Display(Name = "Ten")]
        [Required(ErrorMessage = " khong duoc de trong")]
        public string Name { get; set; }

    }
}
