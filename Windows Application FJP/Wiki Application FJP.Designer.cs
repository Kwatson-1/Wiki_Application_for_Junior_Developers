
namespace Windows_Application_FJP
{
    partial class Application
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStripLabel = new System.Windows.Forms.StatusStrip();
            this.toolStatusStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.listViewDisplay = new System.Windows.Forms.ListView();
            this.listViewName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxDefinition = new System.Windows.Forms.TextBox();
            this.radioButtonLinear = new System.Windows.Forms.RadioButton();
            this.radioButtonNonLinear = new System.Windows.Forms.RadioButton();
            this.groupBoxRadioButtons = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStripLabel.SuspendLayout();
            this.groupBoxRadioButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStripLabel
            // 
            this.statusStripLabel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStatusStrip});
            this.statusStripLabel.Location = new System.Drawing.Point(0, 389);
            this.statusStripLabel.Name = "statusStripLabel";
            this.statusStripLabel.Size = new System.Drawing.Size(484, 22);
            this.statusStripLabel.TabIndex = 0;
            this.statusStripLabel.Text = "statusStripLabel";
            // 
            // toolStatusStrip
            // 
            this.toolStatusStrip.Name = "toolStatusStrip";
            this.toolStatusStrip.Size = new System.Drawing.Size(0, 17);
            // 
            // listViewDisplay
            // 
            this.listViewDisplay.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewName,
            this.listViewCategory});
            this.listViewDisplay.FullRowSelect = true;
            this.listViewDisplay.HideSelection = false;
            this.listViewDisplay.Location = new System.Drawing.Point(252, 37);
            this.listViewDisplay.Name = "listViewDisplay";
            this.listViewDisplay.Size = new System.Drawing.Size(225, 347);
            this.listViewDisplay.TabIndex = 13;
            this.listViewDisplay.Tag = "Items in the collection and their category are displayed here.";
            this.listViewDisplay.UseCompatibleStateImageBehavior = false;
            this.listViewDisplay.View = System.Windows.Forms.View.Details;
            this.listViewDisplay.SelectedIndexChanged += new System.EventHandler(this.ListViewDisplay_SelectedIndexChanged);
            this.listViewDisplay.Click += new System.EventHandler(this.listViewDisplay_Click);
            this.listViewDisplay.DoubleClick += new System.EventHandler(this.listViewDisplay_DoubleClick);
            // 
            // listViewName
            // 
            this.listViewName.Text = "Name";
            this.listViewName.Width = 111;
            // 
            // listViewCategory
            // 
            this.listViewCategory.Text = "Category";
            this.listViewCategory.Width = 110;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(403, 10);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(74, 23);
            this.buttonSearch.TabIndex = 12;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(252, 11);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(145, 20);
            this.textBoxSearch.TabIndex = 11;
            this.toolTip1.SetToolTip(this.textBoxSearch, "Enter item to search here.");
            this.textBoxSearch.TextChanged += new System.EventHandler(this.TextBoxInput_TextChanged);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(13, 10);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(74, 34);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Tag = "";
            this.buttonAdd.Text = "Add";
            this.toolTip1.SetToolTip(this.buttonAdd, "Adds  an item to the list.");
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(90, 10);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(74, 34);
            this.buttonEdit.TabIndex = 7;
            this.buttonEdit.Tag = "";
            this.buttonEdit.Text = "Edit";
            this.toolTip1.SetToolTip(this.buttonEdit, "Edits the item selected in the list.");
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(167, 10);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(74, 34);
            this.buttonDelete.TabIndex = 8;
            this.buttonDelete.Text = "Delete";
            this.toolTip1.SetToolTip(this.buttonDelete, "Deletes the item selected from the list.");
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(13, 90);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(150, 21);
            this.comboBoxCategory.TabIndex = 2;
            this.toolTip1.SetToolTip(this.comboBoxCategory, "Select item cateogry here.");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Name";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Category";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(13, 58);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(150, 20);
            this.textBoxName.TabIndex = 1;
            this.toolTip1.SetToolTip(this.textBoxName, "Enter item name here.");
            this.textBoxName.DoubleClick += new System.EventHandler(this.TextBoxName_DoubleClick);
            this.textBoxName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxName_KeyPress);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(136, 350);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(105, 34);
            this.buttonOpen.TabIndex = 10;
            this.buttonOpen.Text = "Open";
            this.toolTip1.SetToolTip(this.buttonOpen, "For opening an existing file.");
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(13, 350);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(105, 34);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Save";
            this.toolTip1.SetToolTip(this.buttonSave, "For saving the current list to file.");
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxDefinition
            // 
            this.textBoxDefinition.Location = new System.Drawing.Point(13, 208);
            this.textBoxDefinition.Multiline = true;
            this.textBoxDefinition.Name = "textBoxDefinition";
            this.textBoxDefinition.Size = new System.Drawing.Size(228, 136);
            this.textBoxDefinition.TabIndex = 5;
            this.toolTip1.SetToolTip(this.textBoxDefinition, "Enter item definition here.");
            // 
            // radioButtonLinear
            // 
            this.radioButtonLinear.AutoSize = true;
            this.radioButtonLinear.Location = new System.Drawing.Point(25, 24);
            this.radioButtonLinear.Name = "radioButtonLinear";
            this.radioButtonLinear.Size = new System.Drawing.Size(54, 17);
            this.radioButtonLinear.TabIndex = 3;
            this.radioButtonLinear.TabStop = true;
            this.radioButtonLinear.Text = "Linear";
            this.toolTip1.SetToolTip(this.radioButtonLinear, "Check to assign a linear structure type to the item.");
            this.radioButtonLinear.UseVisualStyleBackColor = true;
            // 
            // radioButtonNonLinear
            // 
            this.radioButtonNonLinear.AutoSize = true;
            this.radioButtonNonLinear.Location = new System.Drawing.Point(126, 24);
            this.radioButtonNonLinear.Name = "radioButtonNonLinear";
            this.radioButtonNonLinear.Size = new System.Drawing.Size(77, 17);
            this.radioButtonNonLinear.TabIndex = 4;
            this.radioButtonNonLinear.TabStop = true;
            this.radioButtonNonLinear.Text = "Non-Linear";
            this.toolTip1.SetToolTip(this.radioButtonNonLinear, "Check to assign a non-linear structure type to the item.");
            this.radioButtonNonLinear.UseVisualStyleBackColor = true;
            // 
            // groupBoxRadioButtons
            // 
            this.groupBoxRadioButtons.Controls.Add(this.radioButtonNonLinear);
            this.groupBoxRadioButtons.Controls.Add(this.radioButtonLinear);
            this.groupBoxRadioButtons.Location = new System.Drawing.Point(13, 121);
            this.groupBoxRadioButtons.Name = "groupBoxRadioButtons";
            this.groupBoxRadioButtons.Size = new System.Drawing.Size(228, 60);
            this.groupBoxRadioButtons.TabIndex = 16;
            this.groupBoxRadioButtons.TabStop = false;
            this.groupBoxRadioButtons.Text = "Structure";
            this.groupBoxRadioButtons.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Definition";
            // 
            // Application
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 411);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxDefinition);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.listViewDisplay);
            this.Controls.Add(this.statusStripLabel);
            this.Controls.Add(this.groupBoxRadioButtons);
            this.HelpButton = true;
            this.Name = "Application";
            this.Text = "Wiki Application FJP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Application_FormClosing);
            this.Load += new System.EventHandler(this.Application_Load);
            this.statusStripLabel.ResumeLayout(false);
            this.statusStripLabel.PerformLayout();
            this.groupBoxRadioButtons.ResumeLayout(false);
            this.groupBoxRadioButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStripLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStatusStrip;
        private System.Windows.Forms.ListView listViewDisplay;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxDefinition;
        private System.Windows.Forms.RadioButton radioButtonLinear;
        private System.Windows.Forms.RadioButton radioButtonNonLinear;
        private System.Windows.Forms.GroupBox groupBoxRadioButtons;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader listViewName;
        private System.Windows.Forms.ColumnHeader listViewCategory;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

