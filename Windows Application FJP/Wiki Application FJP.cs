using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wiki_Application_FJP;

namespace Windows_Application_FJP
{
    public partial class Application : Form
    {
        public Application()
        {
            InitializeComponent();
        }

        List<Information> infoCollection = new List<Information>();
        static String[] categoryArray = new String[6]{ "Abstract", "Array", "Graph", "Hash", "List", "Tree",  };

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            Information info = new Information();
            //Set name to text box input.
            info.Name = textBoxName.Text.Trim();
            //Returns structure type string equal to the checked radio button.
            info.Structure = CheckStructureType();
            //Set category to selected item in combobox
            info.Category = comboBoxCategory.Text;
            //Set definition to text box input.
            info.Definition = textBoxDefinition.Text.Trim();
            //Add object to List
            infoCollection.Add(info);
            listViewDisplay.Items.Clear();
            DisplayList();
            Console.WriteLine(Information.ToString(info));
        }

        #region Useless Methods
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void listViewDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion
        //On load adds categoryArray of strings to the combobox

        private void Application_Load(object sender, EventArgs e)
        {
            comboBoxCategory.Items.AddRange(categoryArray);
        }
        //Displays infoCollection items in the list view
        private void DisplayList()
        {
            for(int i = 0; i<infoCollection.Count; i++)
            {
                {
                    ListViewItem lvi = new ListViewItem(infoCollection[i].Name);
                    lvi.SubItems.Add(infoCollection[i].Category);
                    listViewDisplay.Items.Add(lvi);
                }

            }

        }

        //If the textBoxName exists in the infoCollection List<Information> then function will return false meaning the name is not valid
        private Boolean ValidName(String textBoxName)
        {
            return !infoCollection.Exists(info => info.Name.Equals(textBoxName));
        }
        //Returns a string value dependent on which radio button is checked
        public String CheckStructureType()
        {
            if (radioButtonLinear.Checked)
            {
                return "Linear";
            }
            else
            {
                return "Non-Linear";
            }
        }
        //Accepts the index of the item selected in the listView and returns it so that the appropriate structure radioButton is selected.
        public void CheckRadioType(int i)
        {
            if (infoCollection[i].Structure.Equals("Linear"))
            {
                radioButtonLinear.Checked = true;
            }
            else
            {
                radioButtonNonLinear.Checked = true;
            }
        }
        //Returns the details of the selected Information item selected
        private void listViewDisplay_Click(object sender, EventArgs e)
        {
            int selectedRecord = listViewDisplay.SelectedIndices[0];
            textBoxName.Text = infoCollection[selectedRecord].Name;
            CheckRadioType(selectedRecord);
            CheckCategoryType(selectedRecord);
            


        }
        private void CheckCategoryType(int var)
        {
            for(int i = 0; i<categoryArray.Length-1; i++)
            {
                if (infoCollection[var].Category.Equals(categoryArray[i]))
                {
                    comboBoxCategory.SelectedIndex = i;
                }
            }
        }
    }
}
