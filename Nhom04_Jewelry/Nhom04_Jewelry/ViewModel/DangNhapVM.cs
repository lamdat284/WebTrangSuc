using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Nhom04_Jewelry.ViewModel
{
    public class DangNhapVM
    {
        [Required(ErrorMessage = "Username không để trống! ")]
        [RegularExpression(@"^[A-Za-z 0-9]*$", ErrorMessage = "Tài khoản không chứa ký tự đặc biệt")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password không để trống! ")]
        public string Password { get; set; }
    }
}