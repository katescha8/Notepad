using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Notepad
{
    public partial class Form1 : Form
    {
        public string filename;
        public bool IsChanged;
        public Form1()
        {
            InitializeComponent();
            Init();
        }
        public void Init()
        {
            filename = "";
            IsChanged = false;

        }
        public void Create(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            filename = "";
        }
        public void Open(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader sr = new StreamReader(openFileDialog1.FileName);
                    richTextBox1.Text=sr.ReadToEnd();
                    sr.Close();
                    filename = openFileDialog1.FileName;
                }
                catch
                {
                    MessageBox.Show("Файл не может быть открыт");
                }
            }

        }
        public void Save(object sender, EventArgs e)
        {
            if(filename == "")
            {
                if(saveFileDialog1.ShowDialog()==DialogResult.OK)
                {
                    filename=saveFileDialog1.FileName;
                }
                try
                {
                    StreamWriter sw = new StreamWriter(filename);
                    sw.Write(richTextBox1.Text);
                    sw.Close();
                    IsChanged = false;
                }
                catch 
                {
                    MessageBox.Show("Не удалось сохранить файл");
                }
            }
        }
        public void Change(object sender, EventArgs e)
        {
           IsChanged = true;
        }
        public void Quit(object sender, EventArgs e)
        {
            if (IsChanged == false)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Изменения не сохранены");
            }
        }
        public void Font_(object sender, EventArgs e)
        {
            fontDialog1.Font = richTextBox1.Font;
            if (fontDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK && fontDialog1.Font != richTextBox1.SelectionFont)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
        }
        public void Reference(object sender, EventArgs e)
        {
            MessageBox.Show("Моя версия текстового редактора. 02.03.2023 @kathrinnka");
        }
    }
}
