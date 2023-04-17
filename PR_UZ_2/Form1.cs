using System;
using System.Text;
using System.Windows.Forms;

namespace PR_UZ_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != String.Empty && textBox1.TextLength >= 8)
            {
                string key = textBox1.Text;
                string text = textBox2.Text;

                textBox3.Text = MainLogic.Encrypt(text, key);
            }
            else if (textBox1.Text == String.Empty && textBox1.TextLength == 0)
            {
                MessageBox.Show("Please enter the key.");
            }
            else if (textBox1.Text != String.Empty && textBox1.TextLength < 8)
            {
                MessageBox.Show("The key needs to be the length of 8 characters.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != String.Empty && textBox1.TextLength >= 8)
            {
                string key = textBox1.Text;
                string text = textBox2.Text;
                
                textBox3.Text = MainLogic.Decrypt(text, key);
            }
            else if (textBox1.Text == String.Empty && textBox1.TextLength == 0)
            {
                MessageBox.Show("Please enter the key.");
            }
            else if (textBox1.Text != String.Empty && textBox1.TextLength < 8)
            {
                MessageBox.Show("The key needs to be the length of 8 characters.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select File";
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.Filter = "Text File (*.txt)|*.txt";
            openFileDialog.FilterIndex = 1;
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != "")
            {
                string file_content = System.IO.File.ReadAllText(openFileDialog.FileName,Encoding.ASCII);
                textBox2.Text = file_content;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save File";
            saveFileDialog.InitialDirectory = @"C:\";
            saveFileDialog.Filter = "Text File (*.txt)|*.txt";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.ShowDialog();
            
            if (saveFileDialog.FileName != "")
            {
                System.IO.File.WriteAllText(saveFileDialog.FileName, textBox3.Text);
            }
        }
    }
}