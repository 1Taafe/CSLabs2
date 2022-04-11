using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    public partial class Form1 : Form
    {
        public Calculator calculator = new Calculator();
        public Form1()
        {
            InitializeComponent();
        }

        private bool isOperationChoosed = false;

        private void button10_Click(object sender, EventArgs e)
        {
            isOperationChoosed = true;
            label3.Text = "AND";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(isOperationChoosed == false)
            {
                label1.Text = label1.Text + "1";
            }
            else
            {
                label2.Text = label2.Text + "1";
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                string operation = label3.Text;
                int x1 = Convert.ToInt32(label1.Text, 2);
                int x2 = Convert.ToInt32(label2.Text, 2);
                int result;
                switch (operation)
                {
                    case "AND":
                        result = calculator.BinaryAnd(x1, x2);
                        textBox1.Text = Convert.ToString(result, 2);
                        textBox2.Text = Convert.ToString(result, 8);
                        textBox3.Text = Convert.ToString(result, 10);
                        textBox4.Text = Convert.ToString(result, 16);
                        break;
                    case "OR":
                        result = calculator.BinaryOr(x1, x2);
                        textBox1.Text = Convert.ToString(result, 2);
                        textBox2.Text = Convert.ToString(result, 8);
                        textBox3.Text = Convert.ToString(result, 10);
                        textBox4.Text = Convert.ToString(result, 16);
                        break;
                    case "XOR":
                        result = calculator.BinaryXor(x1, x2);
                        textBox1.Text = Convert.ToString(result, 2);
                        textBox2.Text = Convert.ToString(result, 8);
                        textBox3.Text = Convert.ToString(result, 10);
                        textBox4.Text = Convert.ToString(result, 16);
                        break;
                    case "NOT":
                        result = calculator.BinaryNot(x1);
                        textBox1.Text = Convert.ToString(result, 2);
                        textBox2.Text = Convert.ToString(result, 8);
                        textBox3.Text = Convert.ToString(result, 10);
                        textBox4.Text = Convert.ToString(result, 16);
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при конвертации. Убедитесь в корректности вводимых данных!", "Ошибка");
                label1.Text = "";
                label2.Text = "";
                label3.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                isOperationChoosed = false;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (isOperationChoosed == false)
            {
                label1.Text = label1.Text + "0";
            }
            else
            {
                label2.Text = label2.Text + "0";
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            isOperationChoosed = true;
            label3.Text = "OR";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            isOperationChoosed = true;
            label3.Text = "XOR";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            isOperationChoosed = false;
            label3.Text = "NOT";
            label2.Text = "0";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            isOperationChoosed = false;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.D0 || e.KeyChar == (char)Keys.NumPad0)
            {
                if(isOperationChoosed == false)
                {
                    label1.Text = label1.Text + "0";
                }
                else
                {
                    label2.Text = label2.Text + "0";
                }
            }
            else if(e.KeyChar == (char)Keys.D1 || e.KeyChar == (char)Keys.NumPad1)
            {
                if (isOperationChoosed == false)
                {
                    label1.Text = label1.Text + "1";
                }
                else
                {
                    label2.Text = label2.Text + "1";
                }
            }
        }
    }
}
