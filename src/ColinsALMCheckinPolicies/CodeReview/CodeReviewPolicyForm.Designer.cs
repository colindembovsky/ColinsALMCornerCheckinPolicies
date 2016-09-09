namespace ColinsALMCheckinPolicies
{
	partial class CodeReviewPolicyForm
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbPassLevel = new System.Windows.Forms.ComboBox();
            this.chkRequireClose = new System.Windows.Forms.CheckBox();
            this.chkFailAnyBad = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstPaths = new System.Windows.Forms.ListBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.chkOnlyMostRecent = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.Location = new System.Drawing.Point(12, 304);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(389, 303);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbPassLevel
            // 
            this.cmbPassLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPassLevel.FormattingEnabled = true;
            this.cmbPassLevel.Items.AddRange(new object[] {
            "Looks Good",
            "With Comments",
            "None"});
            this.cmbPassLevel.Location = new System.Drawing.Point(338, 10);
            this.cmbPassLevel.Name = "cmbPassLevel";
            this.cmbPassLevel.Size = new System.Drawing.Size(125, 21);
            this.cmbPassLevel.TabIndex = 2;
            // 
            // chkRequireClose
            // 
            this.chkRequireClose.AutoSize = true;
            this.chkRequireClose.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRequireClose.Location = new System.Drawing.Point(38, 12);
            this.chkRequireClose.Name = "chkRequireClose";
            this.chkRequireClose.Size = new System.Drawing.Size(167, 17);
            this.chkRequireClose.TabIndex = 3;
            this.chkRequireClose.Text = "Require Review to be Closed:";
            this.chkRequireClose.UseVisualStyleBackColor = true;
            // 
            // chkFailAnyBad
            // 
            this.chkFailAnyBad.AutoSize = true;
            this.chkFailAnyBad.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFailAnyBad.Location = new System.Drawing.Point(9, 35);
            this.chkFailAnyBad.Name = "chkFailAnyBad";
            this.chkFailAnyBad.Size = new System.Drawing.Size(196, 17);
            this.chkFailAnyBad.TabIndex = 4;
            this.chkFailAnyBad.Text = "Fail if any response is \'Needs Work\':";
            this.chkFailAnyBad.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Min Pass Level:";
            // 
            // lstPaths
            // 
            this.lstPaths.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPaths.FormattingEnabled = true;
            this.lstPaths.Location = new System.Drawing.Point(10, 22);
            this.lstPaths.Name = "lstPaths";
            this.lstPaths.Size = new System.Drawing.Size(431, 134);
            this.lstPaths.TabIndex = 6;
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(366, 162);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 9;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(285, 162);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // chkOnlyMostRecent
            // 
            this.chkOnlyMostRecent.AutoSize = true;
            this.chkOnlyMostRecent.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkOnlyMostRecent.Location = new System.Drawing.Point(30, 58);
            this.chkOnlyMostRecent.Name = "chkOnlyMostRecent";
            this.chkOnlyMostRecent.Size = new System.Drawing.Size(175, 17);
            this.chkOnlyMostRecent.TabIndex = 10;
            this.chkOnlyMostRecent.Text = "Only check most recent review:";
            this.chkOnlyMostRecent.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lstPaths);
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Location = new System.Drawing.Point(12, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(452, 193);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Paths to apply policy against";
            // 
            // CodeReviewPolicyForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(476, 339);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkOnlyMostRecent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkFailAnyBad);
            this.Controls.Add(this.chkRequireClose);
            this.Controls.Add(this.cmbPassLevel);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CodeReviewPolicyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Code Review Policy Settings";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ComboBox cmbPassLevel;
		private System.Windows.Forms.CheckBox chkRequireClose;
		private System.Windows.Forms.CheckBox chkFailAnyBad;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox lstPaths;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.CheckBox chkOnlyMostRecent;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}