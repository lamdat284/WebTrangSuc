using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Nhom04_Jewelry.Models
{
    public class KhachHang
    {
        [Key]
        public long MaKhachHang { get; set; }

        [Required]
        public string HoTen { get; set; }

        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        [Required]
        public string Email { get; set; }
    }
}