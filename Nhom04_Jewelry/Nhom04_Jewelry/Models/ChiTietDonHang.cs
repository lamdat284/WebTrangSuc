using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Nhom04_Jewelry.Models
{
    public class ChiTietDonHang
    {
        [Key]
        public long MaDonHang { get; set; }
        [Required]
        public string ProductName { get; set; }

        [Required]
        public Nullable<double> SoLuong { get; set; }
        public Nullable<double> DongGia { get; set; }
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public Nullable<System.DateTime> NgayThanhToan { get; set; }

        [Required]
        public Nullable<long> ProductID { get; set; }
        [Required]
        public Nullable<long> MaKhachHang { get; set; }

        public virtual Product Product { get; set; }
        public virtual KhachHang KhachHang { get; set; }
    }
}