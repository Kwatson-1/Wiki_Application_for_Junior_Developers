using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki_Application_FJP
{
    [Serializable]
    class Information : IComparable<Information>
    {
        private String name;
        private String category;
        private String structure;
        private String definition;

        public Information()
        {

        }

        public Information(string name, string category, string structure, string definition)
        {
            this.name = name;
            this.category = category;
            this.structure = structure;
            this.definition = definition;
        }

        public string Name { get => name; set => name = value; }
        public string Category { get => category; set => category = value; }
        public string Structure { get => structure; set => structure = value; }
        public string Definition { get => definition; set => definition = value; }

        public int CompareTo(Information other)
        {
            return Name.CompareTo(other.name);
        }
    }
}
