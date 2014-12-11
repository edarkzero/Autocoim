using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autocoim
{
    public partial class PathUserControl : UserControl
    {
        private MainController controller;

        public PathUserControl(object controller)
        {
            this.controller = (MainController)controller;
            InitializeComponent();
            renderPathStatus();
        }

        private void renderPathStatus()
        {
            this.labelPathGP.Text = controller.CRegistryManager.getGPPath();
            this.labelPathEmail.Text = controller.CRegistryManager.getEmailPath();
            this.labelPathFolder.Text = controller.CRegistryManager.getFolderPath();
        }

        private void buttonSearchGP_Click(object sender, EventArgs e)
        {
            // Show the FolderBrowserDialog.
            DialogResult result = this.openFileDialogGP.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filePath = this.openFileDialogGP.FileName;
                controller.CRegistryManager.setGPPath(filePath);
                this.labelPathGP.Text = controller.CRegistryManager.getGPPath();
            }
        }

        private void buttonSearchEmail_Click(object sender, EventArgs e)
        {
            // Show the FolderBrowserDialog.
            DialogResult result = this.openFileDialogEmail.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filePath = this.openFileDialogEmail.FileName;
                controller.CRegistryManager.setEmailPath(filePath);
                this.labelPathEmail.Text = controller.CRegistryManager.getEmailPath();
            }
        }

        private void buttonSearchFolder_Click(object sender, EventArgs e)
        {
            // Show the FolderBrowserDialog.
            DialogResult result = this.folderBrowserDialogAll.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filePath = this.folderBrowserDialogAll.SelectedPath;
                controller.CRegistryManager.setFolderPath(filePath);
                this.labelPathFolder.Text = controller.CRegistryManager.getFolderPath();
            }
        }
    }
}
