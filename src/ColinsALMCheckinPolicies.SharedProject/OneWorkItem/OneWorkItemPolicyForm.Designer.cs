namespace ColinsALMCheckinPolicies
{
	partial class OneWorkItemPolicyForm
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
			this.rdoExactly = new System.Windows.Forms.RadioButton();
			this.rdoAtLeast = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cmbTypes = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(174, 122);
			this.btnOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(112, 35);
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(296, 122);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(112, 35);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// rdoExactly
			// 
			this.rdoExactly.AutoSize = true;
			this.rdoExactly.Location = new System.Drawing.Point(9, 17);
			this.rdoExactly.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.rdoExactly.Name = "rdoExactly";
			this.rdoExactly.Size = new System.Drawing.Size(118, 24);
			this.rdoExactly.TabIndex = 5;
			this.rdoExactly.TabStop = true;
			this.rdoExactly.Text = "Exactly One";
			this.rdoExactly.UseVisualStyleBackColor = true;
			// 
			// rdoAtLeast
			// 
			this.rdoAtLeast.AutoSize = true;
			this.rdoAtLeast.Location = new System.Drawing.Point(141, 17);
			this.rdoAtLeast.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.rdoAtLeast.Name = "rdoAtLeast";
			this.rdoAtLeast.Size = new System.Drawing.Size(128, 24);
			this.rdoAtLeast.TabIndex = 6;
			this.rdoAtLeast.TabStop = true;
			this.rdoAtLeast.Text = "At Least One";
			this.rdoAtLeast.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rdoAtLeast);
			this.groupBox1.Controls.Add(this.rdoExactly);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox1.Location = new System.Drawing.Point(74, 60);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox1.Size = new System.Drawing.Size(334, 52);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			// 
			// cmbTypes
			// 
			this.cmbTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTypes.FormattingEnabled = true;
			this.cmbTypes.Location = new System.Drawing.Point(74, 18);
			this.cmbTypes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmbTypes.Name = "cmbTypes";
			this.cmbTypes.Size = new System.Drawing.Size(332, 28);
			this.cmbTypes.TabIndex = 8;
			this.cmbTypes.SelectedIndexChanged += new System.EventHandler(this.cmbTypes_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 23);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 20);
			this.label2.TabIndex = 9;
			this.label2.Text = "Type:";
			// 
			// OneWorkItemPolicyForm
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoSize = true;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(426, 172);
			this.ControlBox = false;
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cmbTypes);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OneWorkItemPolicyForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "One Work Item Policy Settings";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.RadioButton rdoExactly;
		private System.Windows.Forms.RadioButton rdoAtLeast;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox cmbTypes;
		private System.Windows.Forms.Label label2;
	}
}