using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Lian
    {
        public string value { get; set; }
        public string label { get; set; }

        public List<Lian> children { get; set; }
    }
}
