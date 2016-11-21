using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2CreateUser.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TagAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string stringFieldValue = value as string;

            if (!stringFieldValue.StartsWith("#"))
            {
                return false;
            }

            if (stringFieldValue.Contains(" "))
            {
                return false;
            }

            if (stringFieldValue.Length > 20)
            {
                return false;
            }

            return true;
        }
    }
}
