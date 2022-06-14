using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki_Application_FJP
{
    /*
     * 6.1 Create a separate class file to hold the four data items of the Data Structure (use the Data Structure 
     * Matrix as a guide). Use auto-implemented properties for the fields which must be of type “string”. Save the 
     * class as “Information.cs”.
    */
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
