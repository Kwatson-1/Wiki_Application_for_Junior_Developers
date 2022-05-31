using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Kyle Watson
// A List containing name, structure,category and defition of programming terms
//
//
namespace MyLists
{
    public partial class MyLists : Form
    {
        public MyLists()
        {
            InitializeComponent();
        }
        List<string> myList = new List<string>() { "Blue", "Red", "Yellow", "Green", "Orange", "Purple", "Cyan", "Pink", "White", "Black", "Peach", "Gold" };

        private void DisplayList()
        {
            listBoxDisplay.Items.Clear();
            foreach(string item in myList)
            {
                listBoxDisplay.Items.Add(item);
            }
        }

        private void ButtonDisplay_Click(object sender, EventArgs e)
        {
            DisplayList();
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            myList.Sort();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            myList.Sort();
            if (myList.BinarySearch(textBoxSearch.Text) >= 0)
            {
                MessageBox.Show("Found");
                textBoxSearch.Clear();
                textBoxSearch.Focus();
            }
            else
            {
                MessageBox.Show("Not Found");
                textBoxSearch.Clear();
                textBoxSearch.Focus();
            }
        }

        private void MyLists_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                listBoxDisplay.SetSelected(listBoxDisplay.SelectedIndex, true);
                textBoxSearch.Text = myList.ElementAt(listBoxDisplay.SelectedIndex);
            }
            catch
            {
                return;
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            myList.Add(textBoxSearch.Text);
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            listBoxDisplay.SetSelected(listBoxDisplay.SelectedIndex, true);
            myList.RemoveAt(listBoxDisplay.SelectedIndex);
            DisplayList();
            textBoxSearch.Clear();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            myList[listBoxDisplay.SelectedIndex] = textBoxSearch.Text;
            textBoxSearch.Clear();
            DisplayList();
        }
        private bool ValidName(string checkThisName)
        {
            if (checkThisName == null)  
        }
    }
}
