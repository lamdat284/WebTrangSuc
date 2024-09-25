using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace Nhom04_Jewelry.ViewModel
{
    public class DangKyVM
    {
        [Display(Name = "Tài khoản")]
        [Required(ErrorMessage ="Username không để trống! ")]
        [RegularExpression(@"^[A-Za-z 0-9]*$", ErrorMessage = "Tài khoản không chứa ký tự đặc biệt")]
        public string Username { get; set; }
        [Display(Name = "Họ và tên")]
        
        public string Hoten { get; set; }
        [Required(ErrorMessage = "Password không để trống! ")]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password không để trống! ")]
        [Compare("Password",ErrorMessage ="Password không khớp!")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage ="Email không để trống! ")]
        [EmailAddress(ErrorMessage ="Email không chính xác")]
        public string Email { get; set; }     
        [Display(Name ="Ngày sinh")]
        public DateTime? NgaySinh { get; set; }
        [Display(Name = "Giới tính")]
        public string GioiTinh { get; set; }
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }
       
    }
}