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
            this.Contacts = new List<Pointofcontact>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Overview { get; set; }

        // Contain issue to impact or any other text related to solution
        public string DetailedDescription { get; set; }

        public List<Pointofcontact> Contacts { get; private set; }

        public string InfoCardUrl { get; set; }

        public string PagerUrl { get; set; }

        public List<EVDItem> EVDCollection { get; private set; }
    }

    public class Pointofcontact
    {
        public string Name { get; set; }

        public string Designation { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        // Image URL ???
    }
}
