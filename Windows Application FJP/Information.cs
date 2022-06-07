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

        //public string Name { get => name; set => name = value; }
        //public string Category { get => category; set => category = value; }
        //public string Structure { get => structure; set => structure = value; }
        //public string Definition { get => definition; set => definition = value; }

        public string GetName()
        {
            return name;
        }
        public string GetCategory()
        {
            return category;
        }
        public string GetStructure()
        {
            return structure;
        }
        public string GetDefinition()
        {
            return definition;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetCategory(string category)
        {
            this.category = category;
        }
        public void SetStructure(string structure)
        {
            this.structure = structure;
        }
        public void SetDefinition(string definition)
        {
            this.definition = definition;
        }

        public int CompareTo(Information other)
        {
            return name.CompareTo(other.name);
        }

        public static String ToString(Information info)
        {
            String output = String.Format("Name: {0}\nCategory: {1}\nStructure: {2}\nDefinition: {3}", info.GetName(), info.GetCategory(), info.GetStructure(), info.GetDefinition());
            return output;
        }
    }
}
