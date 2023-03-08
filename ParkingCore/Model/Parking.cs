using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCore.Models
{
    public class Parking
    {
        [Key]
        [Required(ErrorMessage = "Khong duoc de trong.")]
        public string PkID { get; set; }

        [Required(ErrorMessage = "parking name is requier.")]
        [StringLength(100)]
        [Display(Name = "paking name")]
        public string PkName { get; set; }

        [Required(ErrorMessage = "So dien thoai khong duoc de trong.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "So dien thoai khong hop le.")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "slot is requier.")]
        [Display(Name = "paking slots")]
        public int Slot { get; set; }

        [Required(ErrorMessage = "floor is requier.")]
        [Display(Name = "paking floors")]
        public int Floor { get; set; }

        [Required(ErrorMessage = "parking address is requier.")]
        [StringLength(200)]
        [Display(Name = "paking address")]
        public string PkAddress { get; set; }

        public IList<Booking> PkBookings { get; set; }
        public IList<Adminstrator> Adminstrators { get; set; }
    }
}
