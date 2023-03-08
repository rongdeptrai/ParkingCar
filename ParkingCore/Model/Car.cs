using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCore.Models
{
    public class Car
    {
        [Key]
        [Required(ErrorMessage = "Khong duoc de trong.")]
        public string CarID { get; set; }
        [Required(ErrorMessage = "Khong duoc de trong.")]
        public string CusID { get; set; }

        [Required(ErrorMessage = "Ho ten khong duoc de trong.")]
        [StringLength(200)]
        [Display(Name = "Ho va Ten")]
        public string CusName { get; set; }


        [Display(Name = "CarNo")]
        [Required(ErrorMessage = "CarNo khong duoc de trong")]
        public string CarNo { get; set; }

        [Display(Name = "CarType     ")]
        [Required(ErrorMessage = "CarType      khong duoc de trong")]
        public string CarType { get; set; }
    }
}
