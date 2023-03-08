using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCore.Models
{
    public class ParkingType
    {
        [Key]
        [Required(ErrorMessage = "Khong duoc de trong.")]
        public string PkTID { get; set; }

        [Required(ErrorMessage = "PkTName is requier.")]
        [StringLength(200)]
        [Display(Name = "PkTName")]
        public string PkTName { get; set; }

        [Required(ErrorMessage = "Price is requier.")]
        [Display(Name = "paking Price")]
        public Decimal Price { get; set; }
        public IList<ParkingSlot> PkSots { get; set; }
    }
}
