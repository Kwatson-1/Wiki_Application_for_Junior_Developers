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
using System.Diagnostics;

namespace Windows_Application_FJP
{
    public partial class Application : Form
    {
        public Application()
        {
            InitializeComponent();
        }
        //Default file name.
        static String saveFileName = "Information.bin";
        //List instantiation
        List<Information> infoCollection = new List<Information>();
        //Array for populating the combo box.

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
                    ListViewItem lvi = new ListViewItem(infoCollection[i].GetName());
                    lvi.SubItems.Add(infoCollection[i].GetCategory());
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
                textBoxName.Text = infoCollection[selectedRecord].GetName();
                CheckRadioType(selectedRecord);
                CheckCategoryType(selectedRecord);
                textBoxDefinition.Text = infoCollection[selectedRecord].GetDefinition();
            }
            catch (System.ArgumentOutOfRangeException)
            {

            }
        }
        #endregion
        #region List View Double-Click -  Delete
        //Calls the delete method when an item is double clicked on in the listBox.
        private void listViewDisplay_DoubleClick(object sender, EventArgs e)
        {
            DeleteMethod();
        }
        #endregion
        #region Method Check Name Validity
        //If the textBoxName exists in the infoCollection List<Information> then function will return false meaning the name is not valid
        private Boolean ValidName(String textBoxName)
        {
            for (int i = 0; i<infoCollection.Count; i++)
            {
                if (infoCollection[i].GetName().Equals(textBoxName))
                {

                    return false;
                }
            }
            return true;
            //return !infoCollection.Exists(info => info.GetName().Equals(textBoxName));
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
                if (infoCollection[var].GetCategory().Equals(categoryArray[i]))
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
                    toolStatusStrip.Text = String.Format("Item name: '{0}' deleted successfully.", infoCollection[selectedRecord].GetName());
                    infoCollection.Remove(infoCollection[selectedRecord]);
                    ClearAllFields();
                    textBoxName.Focus();

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
            if (infoCollection[var].GetStructure().Equals("Linear"))
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
        //Uses a save file dialog box to enter the file name and choose the file save location. Writes to the file using a binary writer.
        private void MethodSave()
        {
            SaveFileDialog saveFileBox = new SaveFileDialog
            {
                InitialDirectory = Environment.CurrentDirectory,
                Filter = "Binary files(*.bin)|*.bin|All files(*.*)|*.*",
            };
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
                        bw.Write(i.GetName());
                        bw.Write(i.GetCategory());
                        bw.Write(i.GetStructure());
                        bw.Write(i.GetDefinition());
                    }
                    toolStatusStrip.Text = String.Format("File saved successfully.");
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
        //Method for clearing the text boxes, combo box and radio buttons.
        private void ClearAllFields()
        {
            textBoxName.Clear();
            radioButtonLinear.Checked = false;
            radioButtonNonLinear.Checked = false;
            comboBoxCategory.SelectedIndex = -1;
            textBoxDefinition.Clear();
            toolStatusStrip.Text = "All fields cleared.";
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
        //Button for adding items to the List<Information>.
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (CheckFieldsFilled())
            {
                if (ValidName(textBoxName.Text))
                {
                    Information info = new Information();
                    //Set name to text box input and capitalize it
                    info.SetName(textBoxName.Text.Trim().Substring(0, 1).ToUpper() + textBoxName.Text.Substring(1));
                    //Returns structure type string equal to the checked radio button.
                    info.SetStructure(CheckStructureType());
                    //Set category to selected item in combobox
                    info.SetCategory(comboBoxCategory.Text);
                    //Set definition to text box input.
                    info.SetDefinition(textBoxDefinition.Text.Trim());
                    //Add object to List
                    infoCollection.Add(info);
                    DisplayList();
                    ClearAllFields();
                    textBoxName.Focus();
                    toolStatusStrip.Text = String.Format("Item name: '{0}' added successfully.", info.GetName());
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
        //Calls the save method when the save button is clicked.
        private void buttonSave_Click(object sender, EventArgs e)
        {
            MethodSave();
        }
        #endregion
        #region Button Open
        //Uses an OpenFileDialog box for selecting a bin file to open and loads the contents into the List<Information> collection via a BinaryReader. 
        private void buttonOpen_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileBox = new OpenFileDialog
            {
                Title = "Open a bin file.",
                Filter = "Binary files(*.bin)|*.bin|All files(*.*)|*.*",
                InitialDirectory = Environment.CurrentDirectory
            };

            DialogResult dr = openFileBox.ShowDialog();
            if (dr == DialogResult.OK)
            {
                listViewDisplay.Items.Clear();
                //Gets the directory path of the file selected in the openFileBox.
                string directoryPath = System.IO.Path.GetDirectoryName(openFileBox.FileName);
                //Gets the filename of the item selected in the openFileBox.
                string fileName = System.IO.Path.GetFileName(openFileBox.FileName);
                string pathToFile = directoryPath + "\\" + fileName;
                Console.WriteLine("File name is " + fileName);
                Console.WriteLine("file path is " + directoryPath);
                Console.WriteLine(pathToFile);

                using (var stream = File.Open(pathToFile, FileMode.Open))
                {
                    using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                    {
                        while (reader.BaseStream.Position != reader.BaseStream.Length)
                        {
                            Information info = new Information();
                            info.SetName(reader.ReadString());
                            info.SetCategory(reader.ReadString());
                            info.SetStructure(reader.ReadString());
                            info.SetDefinition(reader.ReadString());
                            infoCollection.Add(info);
                        }
                    }
                    stream.Close();
                    DisplayList();
                    toolStatusStrip.Text = String.Format("File: '{0}' opened successfully.", fileName.Remove(fileName.Length - 4), 4);
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
        //Overrites the edited record of the currently selected item in the ListView.
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
                            infoCollection[selectedRecord].SetName(textBoxName.Text.Trim());
                            infoCollection[selectedRecord].SetCategory(comboBoxCategory.Text);
                            infoCollection[selectedRecord].SetStructure(CheckStructureType());
                            infoCollection[selectedRecord].SetDefinition(textBoxDefinition.Text.Trim());
                            DisplayList();
                            toolStatusStrip.Text = "Item edited successfully.";
                            ClearAllFields();
                            textBoxName.Focus();
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
            if (listViewDisplay.SelectedItems.Count != 0)
            {
                listViewDisplay.SelectedItems[0].Selected = false;
            }

            if (!textBoxSearch.Equals(""))
            {
                //infoCollection.Sort();
                Information info = new Information();
                info.SetName(textBoxSearch.Text);
                int index = infoCollection.BinarySearch(info);
                Console.WriteLine(index);
                if (index >= 0)
                {
                    listViewDisplay.Items[index].Selected = true; ;
                    toolStatusStrip.Text = "Item found at index " + index + ".";
                    textBoxName.Text = infoCollection[index].GetName();
                    CheckRadioType(index);
                    CheckCategoryType(index);
                    textBoxDefinition.Text = infoCollection[index].GetDefinition();
                }
                else if (infoCollection.Count == 0)
                {
                    toolStatusStrip.Text = "Error: there is nothing to search.";
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
        //Calls the delete method for removing the item selected in the listBox.
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteMethod();
        }
        #endregion
        #region Unused Methods
        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void ListViewDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void TextBoxInput_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion
        #region Text Box Name - Double Click
        //When double clicking the name text box will clear all fields.
        private void TextBoxName_DoubleClick(object sender, EventArgs e)
        {
            ClearAllFields();
        }
        #endregion

    }
}