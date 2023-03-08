using ParkingCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCore.Models
{
    public class Customer
    {
        [Key]
        [Required(ErrorMessage = "Khong duoc de trong.")]
        public string CusID { get; set; }

        [Required(ErrorMessage = "Ho ten khong duoc de trong.")]
        [StringLength(200)]
        [Display(Name = "Ho va Ten")]
        public string CusName { get; set; }

        [Required(ErrorMessage = "khong duoc de trong.")]
        [StringLength(200)]
        [Display(Name = "PassWord")]
        public string Pass { get; set; }

        [Required(ErrorMessage = "So dien thoai khong duoc de trong.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
           ErrorMessage = "So dien thoai khong hop le.")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email khong duoc de trong")]
        [EmailAddress(ErrorMessage = "Email khong dung dinh dang")]
        public string Email { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address khong duoc de trong")]
        public string Address { get; set; }
        public IList<Booking> Bookings { get; set; }
        public IList<Car> Cars { get; set; }
    }
}
