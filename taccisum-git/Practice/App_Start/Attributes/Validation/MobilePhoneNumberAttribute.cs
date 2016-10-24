using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practice.App_Start.Attributes.Validation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class MobilePhoneNumberAttribute : RegularExpressionAttribute
    {
        public MobilePhoneNumberAttribute()
            : base(@"(^13[0-9]|15[7-9]|153|156|18[7-9])[0-9]{8}$")
        {

        }
    }
}