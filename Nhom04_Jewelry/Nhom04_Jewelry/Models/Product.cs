using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Nhom04_Jewelry.Validation;

namespace Nhom04_Jewelry.Models
{
    public class Product
    {
        [Key]
        public long ProductID { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage ="Tên sản phẩm không được để trống!")]
        [RegularExpression(@"^[A-Za-z 0-9]*$", ErrorMessage = "Không sử dụng ký tự đăc biệt")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Giá không được để trống ")]
        //[Range(0, 10000000, ErrorMessage = "Giá không hợp lệ!")]
        [LonHon0(ErrorMessage ="Giá phải lớn hơn 0")]
        public Nullable<double> Price { get; set; }

        [Display(Name = "Mô tả")]
        public string Descriptions { get; set; }
        public string Images { get; set; }
        public string Imagess { get; set; }

        [Required(ErrorMessage = "Loại không được để trống!")]
        public Nullable<long> CategoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}