namespace SimpleProject
{
    partial class main
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._toolStripButton_Add = new System.Windows.Forms.ToolStripButton();
            this._toolStripButton_Edit = new System.Windows.Forms.ToolStripButton();
            this._toolStripButton_Delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._toolStripButton_Save = new System.Windows.Forms.ToolStripButton();
            this._toolStripButton_Load = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._toolStripButton_Exit = new System.Windows.Forms.ToolStripButton();
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Birthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HomeAdress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // _toolStrip
            // 
            this._toolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._toolStrip.AutoSize = false;
            this._toolStrip.BackColor = System.Drawing.Color.Transparent;
            this._toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this._toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this._toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripButton_Add,
            this._toolStripButton_Edit,
            this._toolStripButton_Delete,
            this.toolStripSeparator1,
            this._toolStripButton_Save,
            this._toolStripButton_Load,
            this.toolStripSeparator2,
            this._toolStripButton_Exit});
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this._toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this._toolStrip.Size = new System.Drawing.Size(926, 31);
            this._toolStrip.TabIndex = 1;
            this._toolStrip.Text = "toolStrip1";
            // 
            // _toolStripButton_Add
            // 
            this._toolStripButton_Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripButton_Add.Image = global::SimpleProject.Properties.Resources._24px_png_add;
            this._toolStripButton_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButton_Add.Name = "_toolStripButton_Add";
            this._toolStripButton_Add.Size = new System.Drawing.Size(28, 28);
            this._toolStripButton_Add.Text = "Додати";
            this._toolStripButton_Add.ToolTipText = "Додати";
            this._toolStripButton_Add.Click += new System.EventHandler(this._toolStripButton_Add_Click);
            // 
            // _toolStripButton_Edit
            // 
            this._toolStripButton_Edit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripButton_Edit.Image = global::SimpleProject.Properties.Resources._24px_png_edit;
            this._toolStripButton_Edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButton_Edit.Name = "_toolStripButton_Edit";
            this._toolStripButton_Edit.Size = new System.Drawing.Size(28, 28);
            this._toolStripButton_Edit.Text = "Редагувати";
            this._toolStripButton_Edit.ToolTipText = "Редагувати";
            this._toolStripButton_Edit.Click += new System.EventHandler(this._toolStripButton_Edit_Click);
            // 
            // _toolStripButton_Delete
            // 
            this._toolStripButton_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripButton_Delete.Image = global::SimpleProject.Properties.Resources._24px_png_del;
            this._toolStripButton_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButton_Delete.Name = "_toolStripButton_Delete";
            this._toolStripButton_Delete.Size = new System.Drawing.Size(28, 28);
            this._toolStripButton_Delete.Text = "Видалити";
            this._toolStripButton_Delete.ToolTipText = "Видалити";
            this._toolStripButton_Delete.Click += new System.EventHandler(this._toolStripButton_Delete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // _toolStripButton_Save
            // 
            this._toolStripButton_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripButton_Save.Image = global::SimpleProject.Properties.Resources._24px_png_save;
            this._toolStripButton_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButton_Save.Name = "_toolStripButton_Save";
            this._toolStripButton_Save.Size = new System.Drawing.Size(28, 28);
            this._toolStripButton_Save.Text = "Зберегти";
            this._toolStripButton_Save.ToolTipText = "Зберегти";
            this._toolStripButton_Save.Click += new System.EventHandler(this._toolStripButton_Save_Click);
            // 
            // _toolStripButton_Load
            // 
            this._toolStripButton_Load.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripButton_Load.Image = global::SimpleProject.Properties.Resources._24px_png_replace;
            this._toolStripButton_Load.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButton_Load.Name = "_toolStripButton_Load";
            this._toolStripButton_Load.Size = new System.Drawing.Size(28, 28);
            this._toolStripButton_Load.Text = "Оновити";
            this._toolStripButton_Load.ToolTipText = "Оновити";
            this._toolStripButton_Load.Click += new System.EventHandler(this._toolStripButton_Load_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // _toolStripButton_Exit
            // 
            this._toolStripButton_Exit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripButton_Exit.Image = global::SimpleProject.Properties.Resources._24px_png_exit;
            this._toolStripButton_Exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButton_Exit.Name = "_toolStripButton_Exit";
            this._toolStripButton_Exit.Size = new System.Drawing.Size(28, 28);
            this._toolStripButton_Exit.Text = "Вихід";
            this._toolStripButton_Exit.ToolTipText = "Вихід";
            this._toolStripButton_Exit.Click += new System.EventHandler(this._toolStripButton_Exit_Click);
            // 
            // _dataGridView
            // 
            this._dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FirstName,
            this.LastName,
            this.Birthday,
            this.RoomNo,
            this.HomeAdress});
            this._dataGridView.Location = new System.Drawing.Point(12, 45);
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.Size = new System.Drawing.Size(902, 433);
            this._dataGridView.TabIndex = 2;
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "Ім\'я";
            this.FirstName.Name = "FirstName";
            // 
            // LastName
            // 
            this.LastName.HeaderText = "Прізвище";
            this.LastName.Name = "LastName";
            // 
            // Birthday
            // 
            dataGridViewCellStyle1.NullValue = null;
            this.Birthday.DefaultCellStyle = dataGridViewCellStyle1;
            this.Birthday.HeaderText = "Дата народження";
            this.Birthday.Name = "Birthday";
            // 
            // RoomNo
            // 
            this.RoomNo.HeaderText = "Номер палати";
            this.RoomNo.Name = "RoomNo";
            // 
            // HomeAdress
            // 
            this.HomeAdress.HeaderText = "Домашня адресса";
            this.HomeAdress.Name = "HomeAdress";
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 490);
            this.Controls.Add(this._dataGridView);
            this.Controls.Add(this._toolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "main";
            this.Text = "Головне вікно";
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripButton _toolStripButton_Add;
        private System.Windows.Forms.ToolStripButton _toolStripButton_Edit;
        private System.Windows.Forms.ToolStripButton _toolStripButton_Delete;
        private System.Windows.Forms.ToolStripButton _toolStripButton_Exit;
        private System.Windows.Forms.DataGridView _dataGridView;
        private System.Windows.Forms.ToolStripButton _toolStripButton_Load;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton _toolStripButton_Save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Birthday;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HomeAdress;
    }
}

