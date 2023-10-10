using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class First_cascader
    {
        public string value { get; set; }
        public string label { get; set; }

        public List<Second_cascader> children { get; set; }
    }
}
