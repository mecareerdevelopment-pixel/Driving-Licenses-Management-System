using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Application
{
    public partial class frmUserDetails : Form
    {
        public frmUserDetails(BusinessLogicTier.clsUser User)
        {
            InitializeComponent();

            ctrlUserDetails1.FillUserDetails(User);
        }

        private void ctrlUserDetails1_Load(object sender, EventArgs e)
        {
        }
    }
}
