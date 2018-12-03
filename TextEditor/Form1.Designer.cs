namespace TextEditor
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.buttonFormat = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonFile = new System.Windows.Forms.Button();
            this.contextMenuStripFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCtrlSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxEncrypt = new System.Windows.Forms.TextBox();
            this.textBoxDecrypt = new System.Windows.Forms.TextBox();
            this.contextMenuStripEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripFormat = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fontSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeDuplicatesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelFont = new System.Windows.Forms.Panel();
            this.domainUpDownFont = new System.Windows.Forms.DomainUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxBoldItalic = new System.Windows.Forms.CheckBox();
            this.checkBoxItalic = new System.Windows.Forms.CheckBox();
            this.checkBoxBold = new System.Windows.Forms.CheckBox();
            this.labelFontSize = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelTitelFont = new System.Windows.Forms.Label();
            this.buttonPanelFontExit = new System.Windows.Forms.Button();
            this.numericFontSize = new System.Windows.Forms.NumericUpDown();
            this.panelRemove = new System.Windows.Forms.Panel();
            this.labelSubsectionDupe = new System.Windows.Forms.Label();
            this.panelDupeLineWord = new System.Windows.Forms.Panel();
            this.radioButtonWords = new System.Windows.Forms.RadioButton();
            this.radioButtonLines = new System.Windows.Forms.RadioButton();
            this.panelTitelDupe = new System.Windows.Forms.Panel();
            this.labelTitleDupe = new System.Windows.Forms.Label();
            this.buttonDupeClose = new System.Windows.Forms.Button();
            this.labelWarning = new System.Windows.Forms.Label();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.listBoxNew = new System.Windows.Forms.ListBox();
            this.listBoxOld = new System.Windows.Forms.ListBox();
            this.backgroundWorkerDupes = new System.ComponentModel.BackgroundWorker();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.domainUpDownHighlightColor = new System.Windows.Forms.DomainUpDown();
            this.labelHighLightCol = new System.Windows.Forms.Label();
            this.labelSEarch = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.panelTitelSearch = new System.Windows.Forms.Panel();
            this.labelTitelSearch = new System.Windows.Forms.Label();
            this.buttonSearchExit = new System.Windows.Forms.Button();
            this.textBoxMain = new System.Windows.Forms.RichTextBox();
            this.contextMenuStripAbout = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Faq = new System.Windows.Forms.ToolStripMenuItem();
            this.Contact = new System.Windows.Forms.ToolStripMenuItem();
            this.About = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Changelog = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.contextMenuStripFile.SuspendLayout();
            this.contextMenuStripEdit.SuspendLayout();
            this.contextMenuStripFormat.SuspendLayout();
            this.panelFont.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericFontSize)).BeginInit();
            this.panelRemove.SuspendLayout();
            this.panelDupeLineWord.SuspendLayout();
            this.panelTitelDupe.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.panelTitelSearch.SuspendLayout();
            this.contextMenuStripAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonAbout);
            this.panel1.Controls.Add(this.buttonFormat);
            this.panel1.Controls.Add(this.buttonEdit);
            this.panel1.Controls.Add(this.buttonFile);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(613, 21);
            this.panel1.TabIndex = 0;
            // 
            // buttonAbout
            // 
            this.buttonAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAbout.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonAbout.FlatAppearance.BorderSize = 0;
            this.buttonAbout.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonAbout.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonAbout.Location = new System.Drawing.Point(158, -4);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(46, 25);
            this.buttonAbout.TabIndex = 3;
            this.buttonAbout.Text = "About";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // buttonFormat
            // 
            this.buttonFormat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFormat.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonFormat.FlatAppearance.BorderSize = 0;
            this.buttonFormat.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonFormat.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonFormat.Location = new System.Drawing.Point(90, -4);
            this.buttonFormat.Name = "buttonFormat";
            this.buttonFormat.Size = new System.Drawing.Size(64, 25);
            this.buttonFormat.TabIndex = 2;
            this.buttonFormat.Text = "Format";
            this.buttonFormat.UseVisualStyleBackColor = true;
            this.buttonFormat.Click += new System.EventHandler(this.buttonFormat_Click);
            this.buttonFormat.MouseHover += new System.EventHandler(this.buttonFormat_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEdit.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonEdit.FlatAppearance.BorderSize = 0;
            this.buttonEdit.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonEdit.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonEdit.Location = new System.Drawing.Point(44, -4);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(43, 25);
            this.buttonEdit.TabIndex = 1;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            this.buttonEdit.MouseHover += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonFile
            // 
            this.buttonFile.ContextMenuStrip = this.contextMenuStripFile;
            this.buttonFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFile.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonFile.FlatAppearance.BorderSize = 0;
            this.buttonFile.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonFile.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonFile.Location = new System.Drawing.Point(-1, -4);
            this.buttonFile.Name = "buttonFile";
            this.buttonFile.Size = new System.Drawing.Size(43, 25);
            this.buttonFile.TabIndex = 0;
            this.buttonFile.Text = "File";
            this.buttonFile.UseVisualStyleBackColor = true;
            this.buttonFile.Click += new System.EventHandler(this.buttonFile_Click);
            this.buttonFile.MouseHover += new System.EventHandler(this.buttonFile_Click);
            // 
            // contextMenuStripFile
            // 
            this.contextMenuStripFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveCtrlSToolStripMenuItem});
            this.contextMenuStripFile.Name = "contextMenuStripFile";
            this.contextMenuStripFile.Size = new System.Drawing.Size(221, 92);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.newToolStripMenuItem.Text = "New            (Ctrl + N)";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.openToolStripMenuItem.Text = "Open...       (Ctrl + O)";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.saveToolStripMenuItem.Text = "Save As...    (Ctrl + Shift + S)";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveCtrlSToolStripMenuItem
            // 
            this.saveCtrlSToolStripMenuItem.Name = "saveCtrlSToolStripMenuItem";
            this.saveCtrlSToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.saveCtrlSToolStripMenuItem.Text = "Save            (Ctrl + S)";
            this.saveCtrlSToolStripMenuItem.Click += new System.EventHandler(this.saveCtrlSToolStripMenuItem_Click);
            // 
            // textBoxEncrypt
            // 
            this.textBoxEncrypt.Location = new System.Drawing.Point(231, 107);
            this.textBoxEncrypt.Multiline = true;
            this.textBoxEncrypt.Name = "textBoxEncrypt";
            this.textBoxEncrypt.Size = new System.Drawing.Size(100, 10);
            this.textBoxEncrypt.TabIndex = 3;
            this.textBoxEncrypt.Visible = false;
            // 
            // textBoxDecrypt
            // 
            this.textBoxDecrypt.Location = new System.Drawing.Point(231, 107);
            this.textBoxDecrypt.Multiline = true;
            this.textBoxDecrypt.Name = "textBoxDecrypt";
            this.textBoxDecrypt.Size = new System.Drawing.Size(100, 10);
            this.textBoxDecrypt.TabIndex = 4;
            this.textBoxDecrypt.Visible = false;
            // 
            // contextMenuStripEdit
            // 
            this.contextMenuStripEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.contextMenuStripEdit.Name = "contextMenuStripEdit";
            this.contextMenuStripEdit.Size = new System.Drawing.Size(161, 70);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.copyToolStripMenuItem.Text = "Copy   (Ctrl + C)";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.cutToolStripMenuItem.Text = "Cut      (Ctrl + X)";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.pasteToolStripMenuItem.Text = "Paste   (Ctrl + V)";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // contextMenuStripFormat
            // 
            this.contextMenuStripFormat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontSizeToolStripMenuItem,
            this.removeDuplicatesToolStripMenuItem1,
            this.searchToolStripMenuItem});
            this.contextMenuStripFormat.Name = "contextMenuStripFormat";
            this.contextMenuStripFormat.Size = new System.Drawing.Size(176, 70);
            // 
            // fontSizeToolStripMenuItem
            // 
            this.fontSizeToolStripMenuItem.Name = "fontSizeToolStripMenuItem";
            this.fontSizeToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.fontSizeToolStripMenuItem.Text = "Font";
            this.fontSizeToolStripMenuItem.Click += new System.EventHandler(this.fontNameToolStripMenuItem_Click);
            // 
            // removeDuplicatesToolStripMenuItem1
            // 
            this.removeDuplicatesToolStripMenuItem1.Name = "removeDuplicatesToolStripMenuItem1";
            this.removeDuplicatesToolStripMenuItem1.Size = new System.Drawing.Size(175, 22);
            this.removeDuplicatesToolStripMenuItem1.Text = "Remove Duplicates";
            this.removeDuplicatesToolStripMenuItem1.Click += new System.EventHandler(this.removeDuplicatesToolStripMenuItem1_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.searchToolStripMenuItem.Text = "Search";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // panelFont
            // 
            this.panelFont.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFont.Controls.Add(this.domainUpDownFont);
            this.panelFont.Controls.Add(this.label1);
            this.panelFont.Controls.Add(this.checkBoxBoldItalic);
            this.panelFont.Controls.Add(this.checkBoxItalic);
            this.panelFont.Controls.Add(this.checkBoxBold);
            this.panelFont.Controls.Add(this.labelFontSize);
            this.panelFont.Controls.Add(this.panel2);
            this.panelFont.Controls.Add(this.numericFontSize);
            this.panelFont.Location = new System.Drawing.Point(535, 320);
            this.panelFont.Name = "panelFont";
            this.panelFont.Size = new System.Drawing.Size(253, 179);
            this.panelFont.TabIndex = 5;
            this.panelFont.Visible = false;
            // 
            // domainUpDownFont
            // 
            this.domainUpDownFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.domainUpDownFont.Items.Add("Papyrus");
            this.domainUpDownFont.Items.Add("Courier New");
            this.domainUpDownFont.Items.Add("Curlz MT");
            this.domainUpDownFont.Items.Add("Edwardian Script ITC");
            this.domainUpDownFont.Items.Add("Old English Text MT");
            this.domainUpDownFont.Items.Add("Magneto");
            this.domainUpDownFont.Items.Add("Kunstler Script");
            this.domainUpDownFont.Items.Add("Segoe Script");
            this.domainUpDownFont.Items.Add("Forte");
            this.domainUpDownFont.Items.Add("Mistral");
            this.domainUpDownFont.Items.Add("Century Gothic");
            this.domainUpDownFont.Items.Add("Microsoft Sans Serif");
            this.domainUpDownFont.Location = new System.Drawing.Point(120, 69);
            this.domainUpDownFont.Name = "domainUpDownFont";
            this.domainUpDownFont.Size = new System.Drawing.Size(112, 24);
            this.domainUpDownFont.TabIndex = 7;
            this.domainUpDownFont.SelectedItemChanged += new System.EventHandler(this.domainUpDownFont_SelectedItemChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label1.Location = new System.Drawing.Point(20, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "Font:";
            // 
            // checkBoxBoldItalic
            // 
            this.checkBoxBoldItalic.AutoSize = true;
            this.checkBoxBoldItalic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxBoldItalic.Location = new System.Drawing.Point(24, 154);
            this.checkBoxBoldItalic.Name = "checkBoxBoldItalic";
            this.checkBoxBoldItalic.Size = new System.Drawing.Size(108, 17);
            this.checkBoxBoldItalic.TabIndex = 5;
            this.checkBoxBoldItalic.Text = "Bold and Italic";
            this.checkBoxBoldItalic.UseVisualStyleBackColor = true;
            this.checkBoxBoldItalic.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBoxItalic
            // 
            this.checkBoxItalic.AutoSize = true;
            this.checkBoxItalic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxItalic.Location = new System.Drawing.Point(24, 131);
            this.checkBoxItalic.Name = "checkBoxItalic";
            this.checkBoxItalic.Size = new System.Drawing.Size(48, 17);
            this.checkBoxItalic.TabIndex = 4;
            this.checkBoxItalic.Text = "Italic";
            this.checkBoxItalic.UseVisualStyleBackColor = true;
            this.checkBoxItalic.CheckedChanged += new System.EventHandler(this.checkBoxItalic_CheckedChanged);
            // 
            // checkBoxBold
            // 
            this.checkBoxBold.AutoSize = true;
            this.checkBoxBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.checkBoxBold.Location = new System.Drawing.Point(24, 109);
            this.checkBoxBold.Name = "checkBoxBold";
            this.checkBoxBold.Size = new System.Drawing.Size(51, 17);
            this.checkBoxBold.TabIndex = 3;
            this.checkBoxBold.Text = "Bold";
            this.checkBoxBold.UseVisualStyleBackColor = true;
            this.checkBoxBold.CheckedChanged += new System.EventHandler(this.checkBoxBold_CheckedChanged);
            // 
            // labelFontSize
            // 
            this.labelFontSize.AutoSize = true;
            this.labelFontSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.labelFontSize.Location = new System.Drawing.Point(20, 37);
            this.labelFontSize.Name = "labelFontSize";
            this.labelFontSize.Size = new System.Drawing.Size(90, 22);
            this.labelFontSize.TabIndex = 2;
            this.labelFontSize.Text = "Font Size:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Controls.Add(this.labelTitelFont);
            this.panel2.Controls.Add(this.buttonPanelFontExit);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(253, 23);
            this.panel2.TabIndex = 1;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            // 
            // labelTitelFont
            // 
            this.labelTitelFont.AutoSize = true;
            this.labelTitelFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelTitelFont.Location = new System.Drawing.Point(15, 2);
            this.labelTitelFont.Name = "labelTitelFont";
            this.labelTitelFont.Size = new System.Drawing.Size(36, 17);
            this.labelTitelFont.TabIndex = 3;
            this.labelTitelFont.Text = "Font";
            this.labelTitelFont.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.labelTitelFont.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            // 
            // buttonPanelFontExit
            // 
            this.buttonPanelFontExit.BackColor = System.Drawing.Color.Red;
            this.buttonPanelFontExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPanelFontExit.FlatAppearance.BorderSize = 0;
            this.buttonPanelFontExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPanelFontExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.buttonPanelFontExit.Location = new System.Drawing.Point(224, -11);
            this.buttonPanelFontExit.Name = "buttonPanelFontExit";
            this.buttonPanelFontExit.Size = new System.Drawing.Size(31, 42);
            this.buttonPanelFontExit.TabIndex = 2;
            this.buttonPanelFontExit.Text = "x";
            this.buttonPanelFontExit.UseVisualStyleBackColor = false;
            this.buttonPanelFontExit.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericFontSize
            // 
            this.numericFontSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.numericFontSize.Location = new System.Drawing.Point(120, 38);
            this.numericFontSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericFontSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericFontSize.Name = "numericFontSize";
            this.numericFontSize.Size = new System.Drawing.Size(112, 24);
            this.numericFontSize.TabIndex = 0;
            this.numericFontSize.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.numericFontSize.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // panelRemove
            // 
            this.panelRemove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRemove.Controls.Add(this.labelSubsectionDupe);
            this.panelRemove.Controls.Add(this.panelDupeLineWord);
            this.panelRemove.Controls.Add(this.panelTitelDupe);
            this.panelRemove.Controls.Add(this.labelWarning);
            this.panelRemove.Controls.Add(this.buttonRemove);
            this.panelRemove.Location = new System.Drawing.Point(535, 107);
            this.panelRemove.Name = "panelRemove";
            this.panelRemove.Size = new System.Drawing.Size(281, 148);
            this.panelRemove.TabIndex = 6;
            this.panelRemove.Visible = false;
            // 
            // labelSubsectionDupe
            // 
            this.labelSubsectionDupe.AutoSize = true;
            this.labelSubsectionDupe.Location = new System.Drawing.Point(167, 42);
            this.labelSubsectionDupe.Name = "labelSubsectionDupe";
            this.labelSubsectionDupe.Size = new System.Drawing.Size(62, 13);
            this.labelSubsectionDupe.TabIndex = 8;
            this.labelSubsectionDupe.Text = "  Remove:  ";
            // 
            // panelDupeLineWord
            // 
            this.panelDupeLineWord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDupeLineWord.Controls.Add(this.radioButtonWords);
            this.panelDupeLineWord.Controls.Add(this.radioButtonLines);
            this.panelDupeLineWord.Location = new System.Drawing.Point(164, 49);
            this.panelDupeLineWord.Name = "panelDupeLineWord";
            this.panelDupeLineWord.Size = new System.Drawing.Size(86, 60);
            this.panelDupeLineWord.TabIndex = 7;
            // 
            // radioButtonWords
            // 
            this.radioButtonWords.AutoSize = true;
            this.radioButtonWords.Location = new System.Drawing.Point(9, 34);
            this.radioButtonWords.Name = "radioButtonWords";
            this.radioButtonWords.Size = new System.Drawing.Size(56, 17);
            this.radioButtonWords.TabIndex = 6;
            this.radioButtonWords.Text = "Words";
            this.radioButtonWords.UseVisualStyleBackColor = true;
            // 
            // radioButtonLines
            // 
            this.radioButtonLines.AutoSize = true;
            this.radioButtonLines.Checked = true;
            this.radioButtonLines.Location = new System.Drawing.Point(9, 13);
            this.radioButtonLines.Name = "radioButtonLines";
            this.radioButtonLines.Size = new System.Drawing.Size(50, 17);
            this.radioButtonLines.TabIndex = 5;
            this.radioButtonLines.TabStop = true;
            this.radioButtonLines.Text = "Lines";
            this.radioButtonLines.UseVisualStyleBackColor = true;
            // 
            // panelTitelDupe
            // 
            this.panelTitelDupe.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelTitelDupe.Controls.Add(this.labelTitleDupe);
            this.panelTitelDupe.Controls.Add(this.buttonDupeClose);
            this.panelTitelDupe.Location = new System.Drawing.Point(-2, -1);
            this.panelTitelDupe.Name = "panelTitelDupe";
            this.panelTitelDupe.Size = new System.Drawing.Size(305, 23);
            this.panelTitelDupe.TabIndex = 2;
            this.panelTitelDupe.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitelDupe_MouseDown);
            this.panelTitelDupe.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTitelDupe_MouseMove);
            // 
            // labelTitleDupe
            // 
            this.labelTitleDupe.AutoSize = true;
            this.labelTitleDupe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelTitleDupe.Location = new System.Drawing.Point(11, 2);
            this.labelTitleDupe.Name = "labelTitleDupe";
            this.labelTitleDupe.Size = new System.Drawing.Size(130, 17);
            this.labelTitleDupe.TabIndex = 3;
            this.labelTitleDupe.Text = "Remove Duplicates";
            this.labelTitleDupe.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitelDupe_MouseDown);
            this.labelTitleDupe.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTitelDupe_MouseMove);
            // 
            // buttonDupeClose
            // 
            this.buttonDupeClose.BackColor = System.Drawing.Color.Red;
            this.buttonDupeClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDupeClose.FlatAppearance.BorderSize = 0;
            this.buttonDupeClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDupeClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.buttonDupeClose.Location = new System.Drawing.Point(254, -11);
            this.buttonDupeClose.Name = "buttonDupeClose";
            this.buttonDupeClose.Size = new System.Drawing.Size(31, 42);
            this.buttonDupeClose.TabIndex = 2;
            this.buttonDupeClose.Text = "x";
            this.buttonDupeClose.UseVisualStyleBackColor = false;
            this.buttonDupeClose.Click += new System.EventHandler(this.buttonDupeClose_Click);
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelWarning.Location = new System.Drawing.Point(0, 124);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(280, 15);
            this.labelWarning.TabIndex = 2;
            this.labelWarning.Text = "*Warning: Make sure you have a backup of this file";
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(25, 49);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(114, 60);
            this.buttonRemove.TabIndex = 1;
            this.buttonRemove.Text = " Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBoxNew
            // 
            this.listBoxNew.FormattingEnabled = true;
            this.listBoxNew.Location = new System.Drawing.Point(44, 120);
            this.listBoxNew.Name = "listBoxNew";
            this.listBoxNew.Size = new System.Drawing.Size(120, 95);
            this.listBoxNew.TabIndex = 4;
            this.listBoxNew.Visible = false;
            // 
            // listBoxOld
            // 
            this.listBoxOld.FormattingEnabled = true;
            this.listBoxOld.Location = new System.Drawing.Point(66, 238);
            this.listBoxOld.Name = "listBoxOld";
            this.listBoxOld.Size = new System.Drawing.Size(88, 69);
            this.listBoxOld.TabIndex = 3;
            this.listBoxOld.Visible = false;
            // 
            // backgroundWorkerDupes
            // 
            this.backgroundWorkerDupes.WorkerSupportsCancellation = true;
            this.backgroundWorkerDupes.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDupes_DoWork);
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.Color.White;
            this.panelSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSearch.Controls.Add(this.domainUpDownHighlightColor);
            this.panelSearch.Controls.Add(this.labelHighLightCol);
            this.panelSearch.Controls.Add(this.labelSEarch);
            this.panelSearch.Controls.Add(this.textBoxSearch);
            this.panelSearch.Controls.Add(this.panelTitelSearch);
            this.panelSearch.Location = new System.Drawing.Point(326, 335);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(161, 134);
            this.panelSearch.TabIndex = 7;
            this.panelSearch.Visible = false;
            // 
            // domainUpDownHighlightColor
            // 
            this.domainUpDownHighlightColor.Items.Add("Red");
            this.domainUpDownHighlightColor.Items.Add("Gold");
            this.domainUpDownHighlightColor.Items.Add("Orange");
            this.domainUpDownHighlightColor.Items.Add("Yellow");
            this.domainUpDownHighlightColor.Items.Add("Green");
            this.domainUpDownHighlightColor.Items.Add("Lime Green");
            this.domainUpDownHighlightColor.Items.Add("Blue");
            this.domainUpDownHighlightColor.Items.Add("Cyan");
            this.domainUpDownHighlightColor.Location = new System.Drawing.Point(17, 103);
            this.domainUpDownHighlightColor.Name = "domainUpDownHighlightColor";
            this.domainUpDownHighlightColor.Size = new System.Drawing.Size(125, 20);
            this.domainUpDownHighlightColor.TabIndex = 9;
            this.domainUpDownHighlightColor.SelectedItemChanged += new System.EventHandler(this.domainUpDownHighlightColor_SelectedItemChanged);
            // 
            // labelHighLightCol
            // 
            this.labelHighLightCol.AutoSize = true;
            this.labelHighLightCol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelHighLightCol.Location = new System.Drawing.Point(14, 80);
            this.labelHighLightCol.Name = "labelHighLightCol";
            this.labelHighLightCol.Size = new System.Drawing.Size(104, 17);
            this.labelHighLightCol.TabIndex = 8;
            this.labelHighLightCol.Text = "Highlight Color:";
            // 
            // labelSEarch
            // 
            this.labelSEarch.AutoSize = true;
            this.labelSEarch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelSEarch.Location = new System.Drawing.Point(14, 30);
            this.labelSEarch.Name = "labelSEarch";
            this.labelSEarch.Size = new System.Drawing.Size(78, 17);
            this.labelSEarch.TabIndex = 4;
            this.labelSEarch.Text = "Search for:";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(16, 52);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(126, 20);
            this.textBoxSearch.TabIndex = 3;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panelTitelSearch
            // 
            this.panelTitelSearch.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelTitelSearch.Controls.Add(this.labelTitelSearch);
            this.panelTitelSearch.Controls.Add(this.buttonSearchExit);
            this.panelTitelSearch.Location = new System.Drawing.Point(-2, -1);
            this.panelTitelSearch.Name = "panelTitelSearch";
            this.panelTitelSearch.Size = new System.Drawing.Size(305, 23);
            this.panelTitelSearch.TabIndex = 2;
            this.panelTitelSearch.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitelSearch_MouseDown);
            this.panelTitelSearch.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTitelSearch_MouseMove);
            // 
            // labelTitelSearch
            // 
            this.labelTitelSearch.AutoSize = true;
            this.labelTitelSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelTitelSearch.Location = new System.Drawing.Point(10, 3);
            this.labelTitelSearch.Name = "labelTitelSearch";
            this.labelTitelSearch.Size = new System.Drawing.Size(53, 17);
            this.labelTitelSearch.TabIndex = 4;
            this.labelTitelSearch.Text = "Search";
            // 
            // buttonSearchExit
            // 
            this.buttonSearchExit.BackColor = System.Drawing.Color.Red;
            this.buttonSearchExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSearchExit.FlatAppearance.BorderSize = 0;
            this.buttonSearchExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.buttonSearchExit.Location = new System.Drawing.Point(132, -11);
            this.buttonSearchExit.Name = "buttonSearchExit";
            this.buttonSearchExit.Size = new System.Drawing.Size(31, 42);
            this.buttonSearchExit.TabIndex = 2;
            this.buttonSearchExit.Text = "x";
            this.buttonSearchExit.UseVisualStyleBackColor = false;
            this.buttonSearchExit.Click += new System.EventHandler(this.buttonSearchExit_Click);
            // 
            // textBoxMain
            // 
            this.textBoxMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.textBoxMain.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxMain.Location = new System.Drawing.Point(0, 19);
            this.textBoxMain.Name = "textBoxMain";
            this.textBoxMain.Size = new System.Drawing.Size(609, 368);
            this.textBoxMain.TabIndex = 8;
            this.textBoxMain.Text = "";
            this.textBoxMain.TextChanged += new System.EventHandler(this.textBoxMain_TextChanged);
            this.textBoxMain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxMain_KeyDown);
            this.textBoxMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.textBoxMain_MouseUp);
            // 
            // contextMenuStripAbout
            // 
            this.contextMenuStripAbout.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Faq,
            this.Contact,
            this.toolStripSeparator1,
            this.About,
            this.Changelog});
            this.contextMenuStripAbout.Name = "contextMenuStripFormat";
            this.contextMenuStripAbout.Size = new System.Drawing.Size(181, 120);
            // 
            // Faq
            // 
            this.Faq.Name = "Faq";
            this.Faq.Size = new System.Drawing.Size(180, 22);
            this.Faq.Text = "FAQ";
            this.Faq.Click += new System.EventHandler(this.Faq_Click);
            // 
            // Contact
            // 
            this.Contact.Name = "Contact";
            this.Contact.Size = new System.Drawing.Size(180, 22);
            this.Contact.Text = "Contact";
            this.Contact.Click += new System.EventHandler(this.Contact_Click);
            // 
            // About
            // 
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(180, 22);
            this.About.Text = "About";
            this.About.Click += new System.EventHandler(this.About_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // Changelog
            // 
            this.Changelog.Name = "Changelog";
            this.Changelog.Size = new System.Drawing.Size(180, 22);
            this.Changelog.Text = "Changelog";
            this.Changelog.Click += new System.EventHandler(this.Changelog_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(609, 387);
            this.Controls.Add(this.listBoxNew);
            this.Controls.Add(this.listBoxOld);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panelRemove);
            this.Controls.Add(this.panelFont);
            this.Controls.Add(this.textBoxDecrypt);
            this.Controls.Add(this.textBoxEncrypt);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBoxMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.panel1.ResumeLayout(false);
            this.contextMenuStripFile.ResumeLayout(false);
            this.contextMenuStripEdit.ResumeLayout(false);
            this.contextMenuStripFormat.ResumeLayout(false);
            this.panelFont.ResumeLayout(false);
            this.panelFont.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericFontSize)).EndInit();
            this.panelRemove.ResumeLayout(false);
            this.panelRemove.PerformLayout();
            this.panelDupeLineWord.ResumeLayout(false);
            this.panelDupeLineWord.PerformLayout();
            this.panelTitelDupe.ResumeLayout(false);
            this.panelTitelDupe.PerformLayout();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panelTitelSearch.ResumeLayout(false);
            this.panelTitelSearch.PerformLayout();
            this.contextMenuStripAbout.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonFile;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFile;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxEncrypt;
        private System.Windows.Forms.TextBox textBoxDecrypt;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripEdit;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.Button buttonFormat;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFormat;
        private System.Windows.Forms.ToolStripMenuItem fontSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeDuplicatesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCtrlSToolStripMenuItem;
        private System.Windows.Forms.Panel panelFont;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonPanelFontExit;
        private System.Windows.Forms.NumericUpDown numericFontSize;
        private System.Windows.Forms.Label labelFontSize;
        private System.Windows.Forms.CheckBox checkBoxItalic;
        private System.Windows.Forms.CheckBox checkBoxBold;
        private System.Windows.Forms.Label labelTitelFont;
        private System.Windows.Forms.CheckBox checkBoxBoldItalic;
        private System.Windows.Forms.Panel panelRemove;
        private System.Windows.Forms.Panel panelTitelDupe;
        private System.Windows.Forms.Label labelTitleDupe;
        private System.Windows.Forms.Button buttonDupeClose;
        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.ListBox listBoxNew;
        private System.Windows.Forms.ListBox listBoxOld;
        private System.ComponentModel.BackgroundWorker backgroundWorkerDupes;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Label labelSEarch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Panel panelTitelSearch;
        private System.Windows.Forms.Label labelTitelSearch;
        private System.Windows.Forms.Button buttonSearchExit;
        private System.Windows.Forms.DomainUpDown domainUpDownFont;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox textBoxMain;
        private System.Windows.Forms.DomainUpDown domainUpDownHighlightColor;
        private System.Windows.Forms.Label labelHighLightCol;
        private System.Windows.Forms.Label labelSubsectionDupe;
        private System.Windows.Forms.Panel panelDupeLineWord;
        private System.Windows.Forms.RadioButton radioButtonWords;
        private System.Windows.Forms.RadioButton radioButtonLines;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripAbout;
        private System.Windows.Forms.ToolStripMenuItem Faq;
        private System.Windows.Forms.ToolStripMenuItem Contact;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem About;
        private System.Windows.Forms.ToolStripMenuItem Changelog;
    }
}

