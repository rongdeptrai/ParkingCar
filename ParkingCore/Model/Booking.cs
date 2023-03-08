using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCore.Models
{
    public class Booking
    {
        [Key]
        public string BookingID { get; set; }

        [Display(Name = "id khách hàng")]
        [Required(ErrorMessage = "Khong duoc de trong.")]
        public string CusID { get; set; }

        [Display(Name = "Teen khách hàng")]
        public string CusName { get; set; }

        [Required(ErrorMessage = "So dien thoai khong duoc de trong.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "So dien thoai khong hop le.")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "CarNo")]
        [Required(ErrorMessage = "Khong duoc de trong.")]
        public string CarNo { get; set; }


        [Display(Name = "SlotNo")]
        [Required(ErrorMessage = "Khong duoc de trong.")]
        public string SlotNo { get; set; }

        [Display(Name = "DateIn")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateIn { get; set; }

        [Display(Name = "ExpOut")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime ExpOut { get; set; }

        [Display(Name = "Status")]
        public bool? Status { get; set; } = false;

        [Display(Name = "paking ExpPrice")]
        public Decimal ExpTotalPrice { get; set; }

        [Display(Name = "Payment Status")]
        [Required(ErrorMessage = "PaymentStatus is requier.")]
        public bool PaymentStatus { get; set; }
        [Required(ErrorMessage = "Khong duoc de trong.")]
        public string PkID { get; set; }
        [Required(ErrorMessage = "Khong duoc de trong.")]
        public string PkSlotID { get; set; }
        [Display(Name = "PutTime")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime PutTime { get; set; } = DateTime.Now;
        public IList<OrderInvoid> OrderInvoids { get; set; } 
    }
}
