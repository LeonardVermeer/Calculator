using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        Calculate calculate = new Calculate();
        private void btnOne_Click(object sender, EventArgs e) {
            calculate.InsertNumber('1');
            rtbAnswer.Text = rtbAnswer.Text + '1';
        }

        private void btnTwo_Click(object sender, EventArgs e) {
            calculate.InsertNumber('2');
            rtbAnswer.Text = rtbAnswer.Text + '2';
        }

        private void btnThree_Click(object sender, EventArgs e) {
            calculate.InsertNumber('3');
            rtbAnswer.Text = rtbAnswer.Text + '3';
        }

        private void btnFour_Click(object sender, EventArgs e) {
            calculate.InsertNumber('4');
            rtbAnswer.Text = rtbAnswer.Text + '4';
        }

        private void btnFive_Click(object sender, EventArgs e) {
            calculate.InsertNumber('5');
            rtbAnswer.Text = rtbAnswer.Text + '5';
        }

        private void btnSix_Click(object sender, EventArgs e) {
            calculate.InsertNumber('6');
            rtbAnswer.Text = rtbAnswer.Text + '6';
        }

        private void btnSeven_Click(object sender, EventArgs e) {
            calculate.InsertNumber('7');
            rtbAnswer.Text = rtbAnswer.Text + '7';
        }

        private void btnEight_Click(object sender, EventArgs e) {
            calculate.InsertNumber('8');
            rtbAnswer.Text = rtbAnswer.Text + '8';
        }

        private void btnNine_Click(object sender, EventArgs e) {
            calculate.InsertNumber('9');
            rtbAnswer.Text = rtbAnswer.Text + '9';
        }

        private void btnZero_Click(object sender, EventArgs e) {
            calculate.InsertNumber('0');
            rtbAnswer.Text = rtbAnswer.Text + '0';
        }

        private void btnDecimal_Click(object sender, EventArgs e) {
            calculate.InsertNumber(',');
            rtbAnswer.Text = rtbAnswer.Text + ',';
        }

        private void button13_Click(object sender, EventArgs e) {
            calculate.InsertOperator("+");
            rtbAnswer.Text = rtbAnswer.Text + " + ";
        }

        private void button15_Click(object sender, EventArgs e) {
            calculate.InsertOperator("-");
            rtbAnswer.Text = rtbAnswer.Text +  " - ";
        }

        private void button14_Click(object sender, EventArgs e) {
            calculate.InsertOperator("x");
            rtbAnswer.Text = rtbAnswer.Text + " x ";
        }

        private void button16_Click(object sender, EventArgs e) {
            calculate.InsertOperator("/");
            rtbAnswer.Text = rtbAnswer.Text + " / ";
        }

        private void btnEqual_Click(object sender, EventArgs e) {
            rtbAnswer.Text = rtbAnswer.Text + " = " + Convert.ToString(calculate.Calculation());
        }

        private void btnClear_Click(object sender, EventArgs e) {
            calculate.Clear();
            rtbAnswer.Clear();
        }
    }
}
