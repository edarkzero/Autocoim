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
    public partial class ScanUserControl : UserControl
    {
        private MainController controller;

        public ScanUserControl(object controller)
        {
            this.controller = (MainController)controller;
            InitializeComponent();

            //Excel process
            string result = this.controller.ETransform.getExcelArray(this.controller.CRegistryManager.getGPPath());
            this.label1.Text = this.controller.Trad.t(result);
        }
    }
}
