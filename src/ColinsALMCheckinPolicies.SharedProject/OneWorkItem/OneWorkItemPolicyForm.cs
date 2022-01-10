using Microsoft.TeamFoundation.VersionControl.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
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
	public partial class OneWorkItemPolicyForm : Form
	{
		public OneWorkItemPolicyConfig Config { get; private set; }

		public OneWorkItemPolicyForm()
		{
			InitializeComponent();
		}

		public OneWorkItemPolicyForm(OneWorkItemPolicyConfig config, TeamProject teamProject)
			: this()
		{
			Config = config;
			rdoExactly.Checked = config.ExactlyOne;
			rdoAtLeast.Checked = !config.ExactlyOne;

			InitWorkItemTypes(teamProject);

			rdoAtLeast.CheckedChanged += rdoAtLeast_CheckedChanged;
			rdoExactly.CheckedChanged += rdoExactly_CheckedChanged;
		}

		private void InitWorkItemTypes(TeamProject teamProject)
		{
			var store = teamProject.TeamProjectCollection.GetService<WorkItemStore>();
			cmbTypes.Items.Clear();
			foreach(WorkItemType wit in store.Projects[teamProject.Name].WorkItemTypes)
			{
				cmbTypes.Items.Add(wit.Name);
			}
			cmbTypes.SelectedItem = Config.WorkItemType;
			if (cmbTypes.SelectedIndex == -1)
			{
				cmbTypes.SelectedIndex = 0;
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void rdoExactly_CheckedChanged(object sender, EventArgs e)
		{
			Config.ExactlyOne = rdoExactly.Checked;
		}

		private void rdoAtLeast_CheckedChanged(object sender, EventArgs e)
		{
			Config.ExactlyOne = rdoExactly.Checked;
		}

		private void cmbTypes_SelectedIndexChanged(object sender, EventArgs e)
		{
			Config.WorkItemType = cmbTypes.SelectedItem.ToString();
		}
	}
}
