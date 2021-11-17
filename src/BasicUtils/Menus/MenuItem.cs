using System;
using System.Collections.Generic;
using System.Text;

namespace BasicUtils.Menus
{
    public class MenuItem
    {
        public string id { get; set; }
        public string title { get; set; }

        public override string ToString()
        {
            return $"{id}\t{ title}";
        }
    }
}
