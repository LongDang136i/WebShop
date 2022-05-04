using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShop.Models
{
    public class RegisterModel
    {
        [Key]
        public long ID { set; get; }
        [Display(Name="Tên đăng nhập")]
        [Required(ErrorMessage ="Yêu cầu tên đăng nhập.")]        
        public string UserName { set; get; }


        [Display(Name = "Mật khẩu")]
        [StringLength(20,MinimumLength =6,ErrorMessage ="Độ dài mật khẩu từ 6-20 kí tự.")]
        [Required(ErrorMessage = "Yêu cầu mật khẩu")]
        public string Password { set; get; }


        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password",ErrorMessage ="Xác nhận mật khẩu không đúng.")]
        public string ConfimPassword { set; get; }


        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Yêu cầu họ tên")]
        public string Name { set; get; }


        [Display(Name = "Địa chỉ")]
        public string Address { set; get; }


        public string Email { set; get; }
        
        
        [Display(Name = "Số điện thoại")]
        public string Phone { set; get; }


    }
}