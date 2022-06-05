using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        static String[] categoryArray = new String[] { "Abstract", "Array", "Graph", "Hash", "List", "Tree", };

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
            listViewDisplay.Items.Clear();
            infoCollection.Sort();
            for (int i = 0; i < infoCollection.Count; i++)
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
        private void CheckRadioType(int var)
        {
            if (infoCollection[var].Structure.Equals("Linear"))
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
            textBoxDefinition.Text = infoCollection[selectedRecord].Definition;
        }
        //Sets the combo box item to that which matches the selected item in the list box.
        private void CheckCategoryType(int var)
        {
            for (int i = 0; i < categoryArray.Length - 1; i++)
            {
                if (infoCollection[var].Category.Equals(categoryArray[i]))
                {
                    comboBoxCategory.SelectedIndex = i;
                }
            }
        }
        #region Function Delete
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteMethod();
        }

        private void listViewDisplay_DoubleClick(object sender, EventArgs e)
        {
            DeleteMethod();

        }
        //Method for deleting items with a yes/no message box
        public void DeleteMethod()
        {
            try
            {
                int selectedRecord = listViewDisplay.SelectedIndices[0];
                DialogResult deleteOption = MessageBox.Show("Do you wish to delete this item?",
                    "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteOption == DialogResult.Yes)
                {

                    infoCollection.Remove(infoCollection[selectedRecord]);
                }
                else
                {

                }

            }
            catch (ArgumentOutOfRangeException)
            {
                {
                    MessageBox.Show("Error: please select a valid item.");
                }
            }
            DisplayList();
        }
        #endregion

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileBox = new SaveFileDialog();
            saveFileBox.Filter = "Bat Files (*.bat) | *.bat";
            if (saveFileBox.ShowDialog() == DialogResult.OK)
            {

                BinaryWriter bw;
                try
                {
                    bw = new BinaryWriter(new FileStream(saveFileBox.FileName, FileMode.Create));
                }
                catch (Exception fe)
                {
                    MessageBox.Show(fe.Message + "\n Cannot append to file.");
                    return;
                }
                try
                {
                    foreach (var i in infoCollection)
                    {
                        bw.Write(i.Name);
                        bw.Write(i.Category);
                        bw.Write(i.Structure);
                        bw.Write(i.Definition);
                    }
                    statusStripLabel.Text = "File saved successfully.";
                }
                catch (Exception fe)
                {
                    MessageBox.Show(fe.Message + "\n Cannot write data to file.");
                    return;
                }
                bw.Close();
            }
        }
        private void buttonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileBox = new OpenFileDialog();
            openFileBox.Title = "Open a bat file.";
            openFileBox.Filter = "Bat files(*.bat)|*.bat|All files(*.*)|*.*";
               DialogResult dr = openFileBox.ShowDialog();
            if (dr == DialogResult.OK)
            {
                BinaryReader br;
                infoCollection.Clear();
                listViewDisplay.Items.Clear();
                try
                {
                    br = new BinaryReader(new FileStream(openFileBox.FileName, FileMode.Open));
                }
                catch (Exception fe)
                {
                    MessageBox.Show(fe.Message + "\n Cannot open file for reading");
                    return;
                }
                while (br.BaseStream.Position != br.BaseStream.Length)
                {
                    try
                    {
                        Information info = new Information();
                        info.Name = br.ReadString();
                        info.Category = br.ReadString();
                        info.Structure = br.ReadString();
                        info.Definition = br.ReadString();
                        infoCollection.Add(info);

                        toolStatusStrip.Text = "File loaded successfully.";
                    }

                    catch (Exception fe)
                    {
                        MessageBox.Show("Cannot read data from file or EOF" + fe);
                        break;
                    }
                    DisplayList();
                }
                br.Close();
            }
        }
    }
}
