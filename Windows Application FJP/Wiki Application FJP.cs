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

        private void buttonAdd_Click(object sender, EventArgs e)
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
        }

        #region Useless Methods
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        #endregion

        private void Application_Load(object sender, EventArgs e)
        {
            comboBoxCategory.Items.AddRange(categoryArray);
        }
    }
}
