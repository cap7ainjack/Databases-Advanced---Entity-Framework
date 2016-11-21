using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2CreateUser
{
    public static class TagTransormer
    {
        public static string Transform(string tag)
        {
            tag = tag.Replace(" ", "");

            if (tag.First() == '#')
            {
                tag = "#" + tag;
            }

            return tag.Substring(0, Math.Min(20, tag.Length));
        }
    }
}
