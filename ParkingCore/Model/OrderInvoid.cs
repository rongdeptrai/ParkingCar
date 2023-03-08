using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCore.Models
{
    public class OrderInvoid
    {
        [Key]
        public string OrdID { get; set; }

        [Display(Name = "BookingID")]
        [Required(ErrorMessage = "Khong duoc de trong.")]
        public string BookingID { get; set; }

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
        [Display(Name = "PkID")]
        [Required(ErrorMessage = "Khong duoc de trong.")]
        public string PkID { get; set; }

        [Display(Name = "PkName")]
        [Required(ErrorMessage = "Khong duoc de trong.")]
        public string PkName { get; set; }

        [Display(Name = "PkSlType")]
        [Required(ErrorMessage = "Khong duoc de trong.")]
        public string PkSlotID { get; set; }

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

        [Display(Name = "DateOut")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateOut { get; set; }

        [Display(Name = "Status")]
        public bool? Status { get; set; } = false;

        [Required(ErrorMessage = "ExpTotalPrice is requier.")]
        [Display(Name = "paking ExpPrice")]
        public Decimal ExpTotalPrice { get; set; }

        [Required(ErrorMessage = "Fine is requier.")]
        [Display(Name = "Fine")]
        public Decimal Fine { get; set; }

        [Required(ErrorMessage = "TotalPrice is requier.")]
        [Display(Name = "TotalPrice ")]
        public Decimal TotalPrice { get; set; }

        [Display(Name = "Payment Status")]
        [Required(ErrorMessage = "PaymentStatus is requier.")]

        public int PaymentStatus { get; set; }
    }
}
