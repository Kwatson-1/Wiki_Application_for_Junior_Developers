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
using System.Text.RegularExpressions;

namespace Windows_Application_FJP
// Kyle Watson
// StudentID: 30048165
// An application that stores programming related data for educating junior programmers.

{
    public partial class Application : Form
    {
        public Application()
        {
            InitializeComponent();
        }

        // (1/15) 6.1 See Information class

        // (2/15) 6.2 Create a global List<T> of type Information called Wiki.
        // (3/15) 6.4 Create and initialise a global string array with the six categories as indicated in the Data Structure
        // Matrix. Create a custom method to populate the ComboBox when the Form Load method is called.
        #region Static Variables
        //Default file name.
        static String saveFileName = "Information.bin";

        //List instantiation
        static List<Information> Wiki = new List<Information>();

        //Array for populating the combo box.
        static String[] categoryArray = new String[] { "Abstract", "Array", "Graph", "Hash", "List", "Tree" };
        #endregion

        // (4/15) 6.9 Create a single custom method that will sort and then display the Name and Category from the wiki
        // information in the list.
        #region List View Display
        //Displays Wiki items in the list view
        private void DisplayList()
        {
            listViewDisplay.Items.Clear();
            Wiki.Sort();
            for (int i = 0; i < Wiki.Count; i++)
            {
                {
                    ListViewItem lvi = new ListViewItem(Wiki[i].GetName());
                    lvi.SubItems.Add(Wiki[i].GetCategory());
                    listViewDisplay.Items.Add(lvi);
                }
            }
        }
        #endregion

        // (5/15) 6.11 Create a ListView event so a user can select a Data Structure Name from the list of Names and the 
        // associated information will be displayed in the related text boxes combo box and radio button.
        #region List View Click - Select
        //Sets the text boxes, combo box and radio buttons to match the item selected in the list view display.
        private void listViewDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRecord = listViewDisplay.SelectedIndices[0];
                textBoxName.Text = Wiki[selectedRecord].GetName();
                CheckRadioType(selectedRecord);
                CheckCategoryType(selectedRecord);
                textBoxDefinition.Text = Wiki[selectedRecord].GetDefinition();
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

        // (6/15) 6.5 Create a custom ValidName method which will take a parameter string value from the Textbox Name
        // and returns a Boolean after checking for duplicates. Use the built in List<T> method “Exists” to answer this
        // requirement.
        #region Method Check Valid Name
        // If the textBoxName exists in the Wiki List<Information> then function will return false meaning the name is not valid
        private Boolean ValidName(String textBoxName)
        {
            return !Wiki.Exists(info => info.GetName().Equals(textBoxName));
        }
        #endregion

        // (7/15) 6.6a Create two methods to highlight and return the values from the Radio button GroupBox. The first
        // method must return a string value from the selected radio button (Linear or Non-Linear). 
        #region Method Get Structure
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

        // (7/15) 6.6b The second method must send an integer index which will highlight an appropriate radio button.
        #region Method Radio Button Select
        //Accepts the index of the item selected in the listView and returns it so that the appropriate structure radioButton is selected.
        private void CheckRadioType(int var)
        {
            if (Wiki[var].GetStructure().Equals("Linear"))
            {
                radioButtonLinear.Checked = true;
            }
            else
            {
                radioButtonNonLinear.Checked = true;
            }
        }
        #endregion
        #region Method Check Structure
        //Selects the combo box matching the structure of the selected item in the list box.
        private void CheckCategoryType(int var)
        {
            for (int i = 0; i < categoryArray.Length - 1; i++)
            {
                if (Wiki[var].GetCategory().Equals(categoryArray[i]))
                {
                    comboBoxCategory.SelectedIndex = i;
                }
            }
        }
        #endregion

        // (8/15) 6.7 Create a button method that will delete the currently selected record in the ListView. Ensure the user 
        // has the option to backout of this action by using a dialog box. Display an updated version of the sorted list 
        // at the end of this process.
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
                    toolStatusStrip.Text = String.Format("Item name: '{0}' deleted successfully.", Wiki[selectedRecord].GetName());
                    Wiki.Remove(Wiki[selectedRecord]);
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
                    foreach (var i in Wiki)
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

        // (9/15) 6.12 Create a custom method that will clear and reset the TextBboxes, ComboBox and Radio button
        #region Method Clear All
        //Method for clearing the text boxes, combo box and radio buttons.
        private void ClearAllFields()
        {
            textBoxName.Clear();
            radioButtonLinear.Checked = false;
            radioButtonNonLinear.Checked = false;
            comboBoxCategory.SelectedIndex = -1;
            textBoxDefinition.Clear();
            if (listViewDisplay.SelectedItems.Count != 0)
            {
                listViewDisplay.SelectedItems[0].Selected = false;
            }
        }
        #endregion

        #region Method Check Fields Filled
        //Returns true if all fields are filled or false if one is not
        public Boolean CheckFieldsFilled()
        {
            if (textBoxName.Text.Equals("")
                || comboBoxCategory.Text.Equals("")
                || (!radioButtonLinear.Checked && !radioButtonNonLinear.Checked)
                || textBoxDefinition.Text.Equals(""))
            {
                return false;
            }
            else return true;
        }
        #endregion

        // (10/15) 6.3 Create a button method to ADD a new item to the list. Use a TextBox for the Name input, ComboBox for
        // the Category, Radio group for the Structure and Multiline TextBox for the Definition.
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
                    Wiki.Add(info);
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

        // (11/15) 6.14a Create two buttons for the manual open and save option; this must use a dialog box to select a file or 
        // rename a saved file. All Wiki data is stored/retrieved using a binary file format.
        #region Button Save
        //Calls the save method when the save button is clicked.
        private void buttonSave_Click(object sender, EventArgs e)
        {
            MethodSave();
        }
        #endregion

        // (11/15) 6.14b
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
                Wiki.Clear();
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
                            Wiki.Add(info);
                        }
                    }
                    stream.Close();
                    DisplayList();
                    toolStatusStrip.Text = String.Format("File: '{0}' opened successfully.", fileName.Remove(fileName.Length - 4), 4);
                }
            }
        }
        #endregion

        // (12/15) 6.15 The Wiki application will save data when the form closes.
        #region Button Exit
        //Asks the user if they wish to save the changes made when closing the form.
        private void Application_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Wiki.Count != 0)
            {
                DialogResult dr = MessageBox.Show("Do you want to save changes you made to the document?", saveFileName, MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    MethodSave();
                }
                else if(dr == DialogResult.No){

                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
        #endregion

        // (13/15) 6.8 Create a button method that will save the edited record of the currently selected item in the ListView. 
        // All the changes in the input controls will be written back to the list. Display an updated version of the 
        // sorted list at the end of this process.
        #region Button Edit
        //Overrites the edited record of the currently selected item in the ListView.
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRecord = listViewDisplay.SelectedIndices[0];
                if (selectedRecord >= 0)
                {

                    if (CheckFieldsFilled() && ValidName(textBoxName.Text))
                    {
                        var result = MessageBox.Show("Proceed with update?", "Edit Record", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.OK)
                        {
                            Wiki[selectedRecord].SetName(textBoxName.Text.Trim());
                            Wiki[selectedRecord].SetCategory(comboBoxCategory.Text);
                            Wiki[selectedRecord].SetStructure(CheckStructureType());
                            Wiki[selectedRecord].SetDefinition(textBoxDefinition.Text.Trim());
                            DisplayList();
                            toolStatusStrip.Text = "Item edited successfully.";
                            ClearAllFields();
                        }
                    }
                    else if (!ValidName(textBoxName.Text))
                    {
                        toolStatusStrip.Text = "Error: that item already exists.";
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

        // (14/15) 6.10 Create a button method that will use the built in binary search to find a Data Structure name. If the 
        // record is found the associated details will populate the appropriate input controls and highlight the name in 
        // the ListView. At the end of the search process the search input TextBox must be cleared.
        #region Button Search
        //Utilises the inbuilt List<T>.BinarySearch function to search for the value entered into the search box and return the index of the List item where it is found.
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (listViewDisplay.SelectedItems.Count != 0)
            {
                listViewDisplay.SelectedItems[0].Selected = false;
            }
            try
            {
                if (!textBoxSearch.Equals(""))
                {
                    Wiki.Sort();
                    Information info = new Information();
                    info.SetName(textBoxSearch.Text.Trim().Substring(0, 1).ToUpper() + textBoxSearch.Text.Substring(1));
                    int index = Wiki.BinarySearch(info);
                    Console.WriteLine(index);
                    if (index >= 0)
                    {
                        listViewDisplay.Items[index].Selected = true; ;
                        toolStatusStrip.Text = "Item found at index " + index + ".";
                        textBoxName.Text = Wiki[index].GetName();
                        CheckRadioType(index);
                        CheckCategoryType(index);
                        textBoxDefinition.Text = Wiki[index].GetDefinition();
                    }
                    else if (Wiki.Count == 0)
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
            }catch (System.ArgumentOutOfRangeException)
            {
                MessageBox.Show("Error: there is nothing to search.");
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

        // (15/15) 6.13 Create a double click event on the Name TextBox to clear the TextBboxes, ComboBox and Radio button.
        #region Text Box Name - Double Click Clear
        //When double clicking the name text box will clear all fields.
        private void TextBoxName_DoubleClick(object sender, EventArgs e)
        {
            ClearAllFields();
        }
        #endregion
        #region Name Input Handling
        private void textBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z\s\b]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}