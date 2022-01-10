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
			this.label2 = new System.Windows.Forms.Label();
			this.btnRemove = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.chkOnlyMostRecent = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(1372, 867);
			this.btnOK.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(187, 58);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(1574, 867);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(187, 58);
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
			this.cmbPassLevel.Location = new System.Drawing.Point(253, 142);
			this.cmbPassLevel.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
			this.cmbPassLevel.Name = "cmbPassLevel";
			this.cmbPassLevel.Size = new System.Drawing.Size(384, 39);
			this.cmbPassLevel.TabIndex = 2;
			// 
			// chkRequireClose
			// 
			this.chkRequireClose.AutoSize = true;
			this.chkRequireClose.Location = new System.Drawing.Point(30, 30);
			this.chkRequireClose.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
			this.chkRequireClose.Name = "chkRequireClose";
			this.chkRequireClose.Size = new System.Drawing.Size(419, 36);
			this.chkRequireClose.TabIndex = 3;
			this.chkRequireClose.Text = "Require Review to be Closed";
			this.chkRequireClose.UseVisualStyleBackColor = true;
			// 
			// chkFailAnyBad
			// 
			this.chkFailAnyBad.AutoSize = true;
			this.chkFailAnyBad.Location = new System.Drawing.Point(30, 90);
			this.chkFailAnyBad.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
			this.chkFailAnyBad.Name = "chkFailAnyBad";
			this.chkFailAnyBad.Size = new System.Drawing.Size(498, 36);
			this.chkFailAnyBad.TabIndex = 4;
			this.chkFailAnyBad.Text = "Fail if any response is \'Needs Work\'";
			this.chkFailAnyBad.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(33, 148);
			this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(215, 32);
			this.label1.TabIndex = 5;
			this.label1.Text = "Min Pass Level:";
			// 
			// lstPaths
			// 
			this.lstPaths.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstPaths.FormattingEnabled = true;
			this.lstPaths.ItemHeight = 31;
			this.lstPaths.Location = new System.Drawing.Point(30, 275);
			this.lstPaths.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
			this.lstPaths.Name = "lstPaths";
			this.lstPaths.Size = new System.Drawing.Size(1726, 562);
			this.lstPaths.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(33, 228);
			this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(315, 32);
			this.label2.TabIndex = 7;
			this.label2.Text = "Paths to apply policy to:";
			// 
			// btnRemove
			// 
			this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnRemove.Location = new System.Drawing.Point(233, 867);
			this.btnRemove.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(187, 58);
			this.btnRemove.TabIndex = 9;
			this.btnRemove.Text = "Remove";
			this.btnRemove.UseVisualStyleBackColor = true;
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAdd.Location = new System.Drawing.Point(30, 867);
			this.btnAdd.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(187, 58);
			this.btnAdd.TabIndex = 8;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// chkOnlyMostRecent
			// 
			this.chkOnlyMostRecent.AutoSize = true;
			this.chkOnlyMostRecent.Location = new System.Drawing.Point(603, 30);
			this.chkOnlyMostRecent.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
			this.chkOnlyMostRecent.Name = "chkOnlyMostRecent";
			this.chkOnlyMostRecent.Size = new System.Drawing.Size(460, 36);
			this.chkOnlyMostRecent.TabIndex = 10;
			this.chkOnlyMostRecent.Text = "Check only most recent Request";
			this.chkOnlyMostRecent.UseVisualStyleBackColor = true;
			// 
			// CodeReviewPolicyForm
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoSize = true;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(1792, 957);
			this.ControlBox = false;
			this.Controls.Add(this.chkOnlyMostRecent);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lstPaths);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.chkFailAnyBad);
			this.Controls.Add(this.chkRequireClose);
			this.Controls.Add(this.cmbPassLevel);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CodeReviewPolicyForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Code Review Policy Settings";
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
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.CheckBox chkOnlyMostRecent;
	}
}