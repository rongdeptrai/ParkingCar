using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCore.Models
{
    public class ParkingSlot
    {
        [Key]
        [Required(ErrorMessage = "Khong duoc de trong.")]
        public string PkSlotID { get; set; }

        [Required(ErrorMessage = "Khong duoc de trong.")]
        public string PkID { get; set; }

        [Required(ErrorMessage = "SlotNo is requier.")]
        [StringLength(200)]
        [Display(Name = "SlotvNo")]
        public string SlotNo { get; set; }


        [Display(Name = "Status")]
        public bool Status { get; set; } = false;

        [Required(ErrorMessage = "floor is requier.")]
        [Display(Name = "paking floors")]
        public int Floor { get; set; }

        [Required(ErrorMessage = "parking address is requier.")]
        [StringLength(200)]
        [Display(Name = "paking type")]
        public string PkTID { get; set; }
        public IList<Booking> Bookings { get; set; }

    }
}
