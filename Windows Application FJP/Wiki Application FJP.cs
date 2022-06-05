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
        static String[] categoryArray = new String[6]{ "Array", "List", "Tree", "Graph", "Abstract", "Hash" };

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            Information info = new Information();
            //Set name to text box input.
            info.Name = textBoxName.Text.Trim();
            //Set name to checked radio button.
            if (radioButtonLinear.Checked)
            {
                info.Category = "Linear";
            }
            else
            {
                info.Category = "Non-Linear";
            }
            //Set category to selected item in combobox
            info.Category = comboBoxCategory.Text;
            //Set definition to text box input.
            info.Definition = textBoxDefinition.Text.Trim();
            //Add object to List
            infoCollection.Add(info);

            DisplayList();
        }

        #region Useless Methods
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
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

    }
}
