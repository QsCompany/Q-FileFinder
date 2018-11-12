namespace FastFinder
{
    partial class FastFinder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.spanel = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.search = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.browser = new System.Windows.Forms.Button();
            this.searchLocations = new System.Windows.Forms.TextBox();
            this.patent = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.nav = new System.Windows.Forms.DataGridView();
            this.icon = new System.Windows.Forms.DataGridViewImageColumn();
            this.fileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addToFavoriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.spanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nav)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // spanel
            // 
            this.spanel.Controls.Add(this.panel1);
            this.spanel.Controls.Add(this.label3);
            this.spanel.Controls.Add(this.label1);
            this.spanel.Controls.Add(this.search);
            this.spanel.Controls.Add(this.button1);
            this.spanel.Controls.Add(this.browser);
            this.spanel.Controls.Add(this.searchLocations);
            this.spanel.Controls.Add(this.patent);
            this.spanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.spanel.Location = new System.Drawing.Point(0, 0);
            this.spanel.Name = "spanel";
            this.spanel.Size = new System.Drawing.Size(895, 85);
            this.spanel.TabIndex = 0;
            this.spanel.TabStop = false;
            this.spanel.Text = "Search";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(889, 26);
            this.panel1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(420, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Location";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Patent";
            // 
            // search
            // 
            this.search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.search.Location = new System.Drawing.Point(814, 24);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(75, 23);
            this.search.TabIndex = 4;
            this.search.Text = "Search";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(716, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "And ...";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // browser
            // 
            this.browser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browser.Location = new System.Drawing.Point(778, 24);
            this.browser.Name = "browser";
            this.browser.Size = new System.Drawing.Size(28, 23);
            this.browser.TabIndex = 3;
            this.browser.Text = "...";
            this.browser.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.browser.UseVisualStyleBackColor = true;
            this.browser.Click += new System.EventHandler(this.browser_Click);
            // 
            // searchLocations
            // 
            this.searchLocations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchLocations.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.searchLocations.Location = new System.Drawing.Point(482, 26);
            this.searchLocations.Name = "searchLocations";
            this.searchLocations.Size = new System.Drawing.Size(211, 20);
            this.searchLocations.TabIndex = 1;
            this.searchLocations.Text = "a:\\";
            this.searchLocations.KeyDown += new System.Windows.Forms.KeyEventHandler(this.patent_KeyDown);
            // 
            // patent
            // 
            this.patent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.patent.Location = new System.Drawing.Point(57, 26);
            this.patent.Name = "patent";
            this.patent.Size = new System.Drawing.Size(312, 20);
            this.patent.TabIndex = 0;
            this.patent.Text = ".exe";
            this.patent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.patent_KeyDown);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 85);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Panel1Collapsed = true;
            this.splitContainer1.Panel1MinSize = 0;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.nav);
            this.splitContainer1.Panel2MinSize = 200;
            this.splitContainer1.Size = new System.Drawing.Size(895, 399);
            this.splitContainer1.SplitterDistance = 0;
            this.splitContainer1.SplitterWidth = 7;
            this.splitContainer1.TabIndex = 1;
            // 
            // nav
            // 
            this.nav.AllowUserToAddRows = false;
            this.nav.AllowUserToOrderColumns = true;
            this.nav.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.nav.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.nav.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.nav.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.nav.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nav.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.NullValue = "Indisponible";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.nav.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.nav.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.nav.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.icon,
            this.fileName,
            this.type,
            this.location,
            this.size,
            this.unite});
            this.nav.ContextMenuStrip = this.contextMenuStrip1;
            this.nav.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nav.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.nav.GridColor = System.Drawing.SystemColors.Control;
            this.nav.Location = new System.Drawing.Point(0, 0);
            this.nav.Name = "nav";
            this.nav.ReadOnly = true;
            this.nav.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.nav.RowHeadersVisible = false;
            this.nav.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.nav.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.nav.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.nav.Size = new System.Drawing.Size(895, 399);
            this.nav.StandardTab = true;
            this.nav.TabIndex = 0;
            this.nav.TabStop = false;
            this.nav.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.nav_CellDoubleClick);
            this.nav.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.nav_CellMouseDown);
            this.nav.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nav_KeyDown);
            // 
            // icon
            // 
            this.icon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.icon.DataPropertyName = "icon";
            this.icon.FillWeight = 81.21828F;
            this.icon.HeaderText = "";
            this.icon.MinimumWidth = 32;
            this.icon.Name = "icon";
            this.icon.ReadOnly = true;
            this.icon.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.icon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.icon.Width = 32;
            // 
            // fileName
            // 
            this.fileName.DataPropertyName = "fileName";
            this.fileName.FillWeight = 104.6954F;
            this.fileName.HeaderText = "File Name";
            this.fileName.Name = "fileName";
            this.fileName.ReadOnly = true;
            // 
            // type
            // 
            this.type.DataPropertyName = "type";
            this.type.FillWeight = 104.6954F;
            this.type.HeaderText = "Type";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            // 
            // location
            // 
            this.location.DataPropertyName = "location";
            this.location.FillWeight = 104.6954F;
            this.location.HeaderText = "Location";
            this.location.Name = "location";
            this.location.ReadOnly = true;
            // 
            // size
            // 
            this.size.DataPropertyName = "size";
            this.size.FillWeight = 104.6954F;
            this.size.HeaderText = "Size";
            this.size.Name = "size";
            this.size.ReadOnly = true;
            // 
            // unite
            // 
            this.unite.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.unite.DataPropertyName = "unit";
            this.unite.HeaderText = "";
            this.unite.Name = "unite";
            this.unite.ReadOnly = true;
            this.unite.Width = 19;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.openFileLocationToolStripMenuItem,
            this.toolStripSeparator1,
            this.addToFavoriteToolStripMenuItem,
            this.toolStripSeparator2,
            this.copyToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator3,
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(174, 198);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // openFileLocationToolStripMenuItem
            // 
            this.openFileLocationToolStripMenuItem.Name = "openFileLocationToolStripMenuItem";
            this.openFileLocationToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.openFileLocationToolStripMenuItem.Text = "Open File Location";
            this.openFileLocationToolStripMenuItem.Click += new System.EventHandler(this.openFileLocationToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(170, 6);
            // 
            // addToFavoriteToolStripMenuItem
            // 
            this.addToFavoriteToolStripMenuItem.Name = "addToFavoriteToolStripMenuItem";
            this.addToFavoriteToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.addToFavoriteToolStripMenuItem.Text = "Add To Favorite";
            this.addToFavoriteToolStripMenuItem.Click += new System.EventHandler(this.addToFavoriteToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(170, 6);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Enabled = false;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(170, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(173, 22);
            this.openToolStripMenuItem1.Text = "Open";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            // 
            // FastFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 484);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.spanel);
            this.Name = "FastFinder";
            this.Text = "FastFinder";
            this.spanel.ResumeLayout(false);
            this.spanel.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nav)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox spanel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView nav;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.Button browser;
        private System.Windows.Forms.TextBox searchLocations;
        private System.Windows.Forms.TextBox patent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewImageColumn icon;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn location;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewTextBoxColumn unite;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addToFavoriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
    }
}