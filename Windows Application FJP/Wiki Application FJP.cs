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
        string directoryPath;
        string fileName;
        static String saveFileName = "Information.bin";
        List<Information> infoCollection = new List<Information>();
        static String[] categoryArray = new String[] { "Abstract", "Array", "Graph", "Hash", "List", "Tree" };

        #region List View Display
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
        #endregion
        #region List View Click - Select
        //Sets the text boxes, combo box and radio buttons to match the item selected in the list view display.
        private void listViewDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRecord = listViewDisplay.SelectedIndices[0];
                textBoxName.Text = infoCollection[selectedRecord].Name;
                CheckRadioType(selectedRecord);
                CheckCategoryType(selectedRecord);
                textBoxDefinition.Text = infoCollection[selectedRecord].Definition;
            }
            catch (System.ArgumentOutOfRangeException)
            {

            }
        }
        #endregion
        #region List View Double-Click -  Delete
        private void listViewDisplay_DoubleClick(object sender, EventArgs e)
        {
            DeleteMethod();

        }
        #endregion
        #region Method Check Name Validity
        //If the textBoxName exists in the infoCollection List<Information> then function will return false meaning the name is not valid
        private Boolean ValidName(String textBoxName)
        {
            return !infoCollection.Exists(info => info.Name.Equals(textBoxName));
        }
        #endregion
        #region Method Add Structure
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
        #endregion
        #region Method Check Structure
        //Selects the combo box matching the structure of the selected item in the list box.
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
        #endregion
        #region Method Delete
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
        #region Method Radio Button Select
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
        #endregion
        #region Method Save
        private void MethodSave()
        {
            SaveFileDialog saveFileBox = new SaveFileDialog();
            saveFileBox.Filter = "Binary Files (*.bin) | *.bin";
            if (saveFileBox.ShowDialog() == DialogResult.OK)
            {

                BinaryWriter bw;
                try
                {
                    bw = new BinaryWriter(new FileStream(saveFileBox.FileName, FileMode.Create));
                    saveFileName.Equals(saveFileName);
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
        #endregion
        #region Method Application Load
        //On load adds categoryArray of strings to the combobox
        private void Application_Load(object sender, EventArgs e)
        {
            comboBoxCategory.Items.AddRange(categoryArray);
        }
        #endregion
        #region Method Clear All
        private void ClearAllFields()
        {
            textBoxName.Clear();
            radioButtonLinear.Checked = false;
            radioButtonNonLinear.Checked = false;
            comboBoxCategory.SelectedIndex = -1;
            textBoxDefinition.Clear();
        }
        #endregion
        #region Method Check Fields Filled
        //Returns true if all fields are filled or false if one is not
        public Boolean CheckFieldsFilled()
        {
            if (textBoxName.Text.Equals("")
                || comboBoxCategory.Text.Equals("")
                || CheckStructureType().Equals("")
                || textBoxDefinition.Text.Equals(""))
            {
                return false;
            }
            else return true;
        }
        #endregion
        #region Button Add
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (CheckFieldsFilled())
            {
                if (ValidName(textBoxName.Text))
                {
                    Information info = new Information();
                    //Set name to text box input
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
                else
                {
                    toolStatusStrip.Text = "Error: that item already exists.";
                }
            }
            else
            {
                toolStatusStrip.Text = "Error: check that all fields have values entered or selected.";
            }

        }
        #endregion
        #region Button Save
        private void buttonSave_Click(object sender, EventArgs e)
        {
            MethodSave();
        }
        #endregion
        #region Button Open
        private void buttonOpen_Click(object sender, EventArgs e)
        {
            //OpenFileDialog openFileBox = new OpenFileDialog();
            //openFileBox.Title = "Open a bin file.";
            //openFileBox.Filter = "Binary files(*.bin)|*.bin|All files(*.*)|*.*";
            //DialogResult dr = openFileBox.ShowDialog();
            //if (dr == DialogResult.OK)
            //{
            //    string directoryPath = System.IO.Path.GetDirectoryName(openFileBox.FileName);
            //    string fileName = System.IO.Path.GetFileName(openFileBox.FileName);
            //    BinaryReader br;
            //    infoCollection.Clear();
            //    listViewDisplay.Items.Clear();
            //    try
            //    {
            //        br = new BinaryReader(new FileStream(openFileBox.fileName, FileMode.Open));
            //    }
            //    catch (Exception fe)
            //    {
            //        MessageBox.Show(fe.Message + "\n Cannot open file for reading");
            //        return;
            //    }
            //    while (br.BaseStream.Position != br.BaseStream.Length)
            //    {
            //        try
            //        {
            //            Information info = new Information();
            //            info.Name = br.ReadString();
            //            info.Category = br.ReadString();
            //            info.Structure = br.ReadString();
            //            info.Definition = br.ReadString();
            //            infoCollection.Add(info);

            //            toolStatusStrip.Text = "File loaded successfully.";
            //        }

            //        catch (Exception fe)
            //        {
            //            MessageBox.Show("Cannot read data from file or EOF" + fe);
            //            break;
            //        }
            //        DisplayList();
            //    }
            //    br.Close();
            //}
            OpenFileDialog openFileBox = new OpenFileDialog();
            openFileBox.Title = "Open a bin file.";
            openFileBox.Filter = "Binary files(*.bin)|*.bin|All files(*.*)|*.*";
            DialogResult dr = openFileBox.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string directoryPath = System.IO.Path.GetDirectoryName(openFileBox.FileName);
                string fileName = System.IO.Path.GetFileName(openFileBox.FileName);
                Information info = new Information();
                try
                {
                    using (var stream = File.Open(directoryPath, FileMode.Open))
                {

                        using (var read = new BinaryReader(stream, Encoding.UTF8, false))
                        {
                            info.Name = read.ReadString();
                            info.Category = read.ReadString();
                            info.Structure = read.ReadString();
                            info.Definition = read.ReadString();
                            infoCollection.Add(info);
                        }
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion
        #region Button Exit
        //Asks the user if they wish to save the changes made when closing the form.
        private void Application_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (infoCollection.Count != 0)
            {
                DialogResult dr = MessageBox.Show("Do you want to save changes you made to the document?", saveFileName, MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    MethodSave();
                }
                else if (dr == DialogResult.No)
                {

                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
        #endregion
        #region Button Edit
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRecord = listViewDisplay.SelectedIndices[0];
                if (selectedRecord >= 0)
                {
                    if (CheckFieldsFilled())
                    {
                        var result = MessageBox.Show("Proceed with update?", "Edit Record", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.OK)
                        {
                            infoCollection[selectedRecord].Name = textBoxName.Text.Trim();
                            infoCollection[selectedRecord].Category = comboBoxCategory.Text;
                            infoCollection[selectedRecord].Structure = CheckStructureType();
                            infoCollection[selectedRecord].Definition = textBoxDefinition.Text.Trim();
                            DisplayList();
                        }

                    }
                    else
                    {
                        toolStatusStrip.Text = "Error: check that all fields have values entered or selected.";
                    }
                }
                else if (selectedRecord < 0)
                {
                    toolStatusStrip.Text = "Error: select a valid item to edit.";
                }
                else if (CheckFieldsFilled())
                {

                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Error: select a valid item to edit.");
            }

        }
        #endregion
        #region Button Search
        //Utilises the inbuilt List<T>.BinarySearch function to search for the value entered into the search box and return the index of the List item where it is found.
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (!textBoxSearch.Equals(""))
            {
                infoCollection.Sort();
                int index = infoCollection.BinarySearch(new Information() { Name = textBoxSearch.Text });
                Console.WriteLine(index);
                if (index >= 0)
                {
                    toolStatusStrip.Text = "Item found at index " + index + ".";
                    textBoxName.Text = infoCollection[index].Name;
                    CheckRadioType(index);
                    CheckCategoryType(index);
                    textBoxDefinition.Text = infoCollection[index].Definition;
                }
                else
                {
                    toolStatusStrip.Text = "Item not found.";
                }
            }
            else
            {
                toolStatusStrip.Text = "Error: enter the item name you want to search.";
            }
        }
        #endregion
        #region Button Delete
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteMethod();
        }
        #endregion
        #region Unused Methods
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void listViewDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void textBoxInput_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion
        #region Text Box Name - Double Click
        private void textBoxName_DoubleClick(object sender, EventArgs e)
        {
            ClearAllFields();
        }
        #endregion

    }
}