using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMasters.FederalSI.Shared.Model
{
    public class Solution
    {
        public Solution()
        {
            this.EVDCollection = new List<EVDItem>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public List<EVDItem> EVDCollection {get; private set;}
    }
}
