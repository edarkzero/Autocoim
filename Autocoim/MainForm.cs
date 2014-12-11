using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autocoim
{
    public partial class MainForm : Form
    {
        private PathUserControl pathUserControl;
        private ScanUserControl scanUserControl;
        private MainController controller;        

        public MainForm(object controller)
        {
            this.controller = (MainController)controller;            
            InitializeComponent();
        }

        private void disposeAllControls()
        {
            if (pathUserControl != null)
                pathUserControl.Dispose();

            if (scanUserControl != null)
                scanUserControl.Dispose();
        }

        private void pathsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.disposeAllControls();
            pathUserControl = new PathUserControl(controller);
            this.panelContent.Controls.Add(pathUserControl);
        }        

        private void scanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.disposeAllControls();
            scanUserControl = new ScanUserControl(controller);
            this.panelContent.Controls.Add(scanUserControl);
        }

        private void españolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.changelanguage("es");
            pathsToolStripMenuItem.Text = controller.Trad.t("Paths");
        }

        private void inglesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.changelanguage("en");
            pathsToolStripMenuItem.Text = controller.Trad.t("Paths");
        }
    }
}
