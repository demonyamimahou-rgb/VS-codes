using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace units
{
    public partial class Form1 : Form
    {
       
        private const double COST_PER_UNIT = 487.00;
        private const double FEE_PER_HANDS_ON = 2341.86;
        private const double FEE_PER_LABORATORY = 3429.30;
        private const double MISC_FEE = 3739.98;

        public Form1()
        {
            InitializeComponent();
            btnAss.Click += BtnAssess_Click;
        }

        private void BtnAssess_Click(object sender, EventArgs e)
        {
            
            double units = 0;
            bool isUnitsANumber = double.TryParse(tztUnits.Text, out units);
            if (!isUnitsANumber) tztUnits.Text = "0";

            int handsOnSubjects = 0;
            bool isHandsOnANumber = int.TryParse(txtHandsOn.Text, out handsOnSubjects);
            if (!isHandsOnANumber) txtHandsOn.Text = "0";
            
            int labSubjects = 0;
            bool isLabANumber = int.TryParse(txtLab.Text, out labSubjects);
            if (!isLabANumber) txtLab.Text = "0";
          
            if (units >= 26 || units <= 0 || handsOnSubjects < 0 || labSubjects < 0)
            {
                MessageBox.Show("Invalid Input");
                
                lblfee.Text = "0.00";
                lblHFee.Text = "0.00";
                lblLabFee.Text = "0.00";
                lblMiscFee.Text = "0.00";
                lblTotalAssessment.Text = "0.00";
            }
            else
            {
                
                double tuitionFee = units * COST_PER_UNIT;
                double handsOnFee = handsOnSubjects * FEE_PER_HANDS_ON;
                double labFee = labSubjects * FEE_PER_LABORATORY;
                double totalAssessment = tuitionFee + handsOnFee + labFee + MISC_FEE;
  
                lblfee.Text = tuitionFee.ToString("#,#0.00");
                lblHFee.Text = handsOnFee.ToString("#,#0.00");
                lblLabFee.Text = labFee.ToString("#,#0.00");
                lblMiscFee.Text = MISC_FEE.ToString("#,#0.00");            
                lblTotalAssessment.Text = totalAssessment.ToString("#,#0.00");
            }
        }
    }
}


