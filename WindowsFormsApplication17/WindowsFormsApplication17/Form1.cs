using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication17
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = int.Parse(textBox1.Text);
            string a = textBox2.Text;
            string[] b = a.Split();
            int[] arr = new int[x];
            for (int i = 0; i < x; i++)
            {
                arr[i] = int.Parse(b[i]);
            }
            int key, j;
            for (int i = 1; i < x; i++)
            {
                key = arr[i];
                j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
            for (int i = 0; i < x; i++)
            {
                listBox1.Items.Add(arr[i]);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
