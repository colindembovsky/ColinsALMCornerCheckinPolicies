using Microsoft.TeamFoundation.VersionControl.Client;
using Microsoft.TeamFoundation.VersionControl.Controls.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColinsALMCheckinPolicies
{
	public partial class CodeReviewPolicyForm : Form
	{
		public CodeReviewPolicyConfig Config { get; private set; }
		public VersionControlServer VCServer { get; private set; }

		public CodeReviewPolicyForm()
		{
			InitializeComponent();
		}

		public CodeReviewPolicyForm(CodeReviewPolicyConfig config, VersionControlServer vcServer)
		{
			InitializeComponent();
			Config = config;
			VCServer = vcServer;
			chkFailAnyBad.Checked = Config.FailIfAnyResponseIsNeedsWork;
			chkRequireClose.Checked = Config.RequireReviewToBeClosed;
            chkOnlyMostRecent.Checked = Config.CheckOnlyMostRecentReview;
            cmbPassLevel.SelectedItem = "With Comments";
			if (Config.MinPassLevel == PassLevel.LooksGood)
			{
				cmbPassLevel.SelectedItem = "Looks Good";
			}
            else if (Config.MinPassLevel == PassLevel.None)
            {
                cmbPassLevel.SelectedItem = "None";
            }

			lstPaths.Items.Clear();
			config.Paths.ForEach(p => lstPaths.Items.Add(p));

			chkFailAnyBad.CheckedChanged += chkFailAnyBad_CheckedChanged;
			chkRequireClose.CheckedChanged += chkRequireClose_CheckedChanged;
            chkOnlyMostRecent.CheckedChanged += chkOnlyMostRecent_CheckedChanged;
            cmbPassLevel.SelectedIndexChanged += cmbPassLevel_SelectedIndexChanged;
		}

		void cmbPassLevel_SelectedIndexChanged(object sender, EventArgs e)
		{
			Config.MinPassLevel = PassLevel.LooksGood;
			if (cmbPassLevel.SelectedItem.ToString() == "With Comments")
			{
				Config.MinPassLevel = PassLevel.WithComments;
			}
            else if (cmbPassLevel.SelectedItem.ToString() == "None")
            {
                Config.MinPassLevel = PassLevel.None;
            }
		}

		void chkRequireClose_CheckedChanged(object sender, EventArgs e)
		{
			Config.RequireReviewToBeClosed = chkRequireClose.Checked;
		}

		void chkFailAnyBad_CheckedChanged(object sender, EventArgs e)
		{
			Config.FailIfAnyResponseIsNeedsWork = chkFailAnyBad.Checked;
		}

        void chkOnlyMostRecent_CheckedChanged(object sender, EventArgs e)
        {
            Config.CheckOnlyMostRecentReview = chkOnlyMostRecent.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			using (var diag = new DialogChooseServerFolder(VCServer, "$/"))
			{
				if (diag.ShowDialog() == DialogResult.OK)
				{
					var path = diag.CurrentServerItem;
					if (!Config.Paths.Contains(path))
					{
						Config.Paths.Add(path);
						lstPaths.Items.Add(path);
					}
				}
			}
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			var index = lstPaths.SelectedIndex;
			if (index > -1)
			{
				Config.Paths.Remove(lstPaths.Items[index].ToString());
				lstPaths.Items.RemoveAt(index);
			}
		}
	}
}
