using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Practice.App_Start.Attributes.Validation;

namespace Practice.ViewModels
{
    public class TestModel
    {
        [Required(ErrorMessage = "名称必填")]
        [MinLength(5, ErrorMessage = "名称太短")]
        public string Name { get; set; }
        public string Address { get; set; }
        [MobilePhoneNumber(ErrorMessage = "手机号码格式错误")]
        public string Phone { get; set; }
        public string OrderNO { get; set; }
        public string ProductNO { get; set; }

        public int ProductNum { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductName { get; set; }
    }
}