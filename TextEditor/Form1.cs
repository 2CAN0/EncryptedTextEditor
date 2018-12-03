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
using System.Net;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace TextEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string FileName = "";
        private bool StartUpLoading = false;
        private string FileParts;


        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                StartUpLoading = true;
                using (StreamReader sr = new StreamReader(FileName))
                {
                    textBoxEncrypt.Text = "";
                    textBoxMain.Text = "";
                    //
                    if (FileName.Contains(".2AO"))
                    {
                        textBoxDecrypt.Text = sr.ReadToEnd();
                        Decrypt();
                        sr.Close();
                    }
                    else
                    {
                        textBoxMain.Text = sr.ReadToEnd();
                        sr.Close();
                    }
                    FileParts = FileName.Split('\\')[FileName.Split('\\').Count() - 1];
                    this.Text = FileParts + "   ||   (Encrypted)TextEditor By 2CAN0";
                }
            }
            catch
            {
                if (FileName.Length == 0)
                {
                    this.Text = "Untitled.2AO   ||   (Encrypted)TextEditor By 2CAN0";
                }
                else
                    this.Text = FileName + "   ||   (Encrypted)TextEditor By 2CAN0";
                panelFont.Location = new Point(171, 119);
                panelRemove.Location = new Point(124, 58);
                domainUpDownFont.SelectedIndex = domainUpDownFont.Items.Count - 1;
            }

            StartUpLoading = false;

            //Cyan Highlight color
            r = 0;
            g = 255;
            b = 255;
            domainUpDownHighlightColor.SelectedIndex = domainUpDownHighlightColor.Items.Count - 1;
        }

        #region FileButton
        private void buttonFile_Click(object sender, EventArgs e)
        { 
            Button Sender = (Button)sender;
            Point left = new Point(0, Sender.Height - 2);
            left = Sender.PointToScreen(left);
            contextMenuStripFile.Show(left);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
             if (Changed == true)
             {
                 DialogResult Save = MessageBox.Show("Do you want to save your changes?", "2CAN0's TextEditor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                 if (Save == DialogResult.Yes)
                 {
                    SaveFileDialog save = new SaveFileDialog();

                    save.FileName = "Untitled.2AO";

                    save.Filter = "Encrypted Text File | *.2AO";

                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        if (save.FileName != "")
                        {
                            textBoxEncrypt.Text = "";
                            Encrypt();
                            using (StreamWriter sw = new StreamWriter(save.OpenFile()))
                            {
                                sw.Write(textBoxEncrypt.Text);
                            }
                            Changed = false;
                        }
                        else
                        {
                            MessageBox.Show("You didn't enter a filename");
                        }
                    }
                    Form1.ActiveForm.Text = "Untitled.2AO   ||   (Encrypted)TextEditor By 2CAN0";
                 }
                 else if (Save == DialogResult.No)
                 {
                    textBoxMain.Text = "";
                    Form1.ActiveForm.Text = "Untitled.2AO   ||   (Encrypted)TextEditor By 2CAN0";
                 }
                 else
                 {
                     //
                 }
             }
             else
             {
                textBoxMain.Text = "";
                Form1.ActiveForm.Text = "Untitled.2AO   ||   (Encrypted)TextEditor By 2CAN0";
             }
        }

        #region Encrypt
        private void Encrypt()
        {
            //Key
            string key = "cipher";
            int keyIndex = 0;
            string keyLetter = "";

            //Text
            int length = textBoxMain.Text.Length;
            string text = textBoxMain.Text;
            int textIndex = 0;
            string textLetter = "";
            int tabelIndex = 0;

            // Tabel voor letter encryptie
            string[] a = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "\r\n" };
            string[] b = { "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a" };
            string[] c = { "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b" };
            string[] d = { "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c" };
            string[] e = { "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d" };
            string[] f = { "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e" };
            string[] g = { "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f" };
            string[] h = { "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g" };
            string[] i = { "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h" };
            string[] j = { "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h", "i" };
            string[] k = { "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
            string[] l = { "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k" };
            string[] m = { "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l" };
            string[] n = { "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m" };
            string[] o = { "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n" };
            string[] p = { "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o" };
            string[] q = { "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p" };
            string[] r = { "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q" };
            string[] s = { "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r" };
            string[] t = { "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s" };
            string[] u = { "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t" };
            string[] v = { "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u" };
            string[] w = { "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v" };
            string[] x = { "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w" };
            string[] y = { "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x" };
            string[] z = { "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y" };

            bool secondEncryption = false;
            DoubleEncrypt:
            if (secondEncryption == true)
            {
                length = textBoxEncrypt.Text.Length;
                text = textBoxEncrypt.Text;
                textBoxEncrypt.Text = "";
            }

            for (textIndex = 0; textIndex < length; textIndex++)
            {
                //Check KeyIndex
                if (keyIndex == key.Length)
                {
                    keyIndex = 0;
                }
                keyLetter = key[keyIndex].ToString();
                keyIndex++;
                textLetter = text[textIndex].ToString();
                tabelIndex = Array.IndexOf(a, textLetter);

                try
                {
                    if (tabelIndex == -1)
                    {
                        textBoxEncrypt.Text += "\r\n";
                        textIndex++;
                        keyIndex--;
                    }
                    else if (keyLetter == "a")
                    {
                        textBoxEncrypt.Text += a[tabelIndex].ToString();
                    }
                    else if (keyLetter == "b")
                    {
                        textBoxEncrypt.Text += b[tabelIndex].ToString();
                    }
                    else if (keyLetter == "c")
                    {
                        textBoxEncrypt.Text += c[tabelIndex].ToString();
                    }
                    else if (keyLetter == "d")
                    {
                        textBoxEncrypt.Text += d[tabelIndex].ToString();
                    }
                    else if (keyLetter == "e")
                    {
                        textBoxEncrypt.Text += e[tabelIndex].ToString();
                    }
                    else if (keyLetter == "f")
                    {
                        textBoxEncrypt.Text += f[tabelIndex].ToString();
                    }
                    else if (keyLetter == "g")
                    {
                        textBoxEncrypt.Text += g[tabelIndex].ToString();
                    }
                    else if (keyLetter == "h")
                    {
                        textBoxEncrypt.Text += h[tabelIndex].ToString();
                    }
                    else if (keyLetter == "i")
                    {
                        textBoxEncrypt.Text += i[tabelIndex].ToString();
                    }
                    else if (keyLetter == "j")
                    {
                        textBoxEncrypt.Text += j[tabelIndex].ToString();
                    }
                    else if (keyLetter == "k")
                    {
                        textBoxEncrypt.Text += k[tabelIndex].ToString();
                    }
                    else if (keyLetter == "l")
                    {
                        textBoxEncrypt.Text += l[tabelIndex].ToString();
                    }
                    else if (keyLetter == "m")
                    {
                        textBoxEncrypt.Text += m[tabelIndex].ToString();
                    }
                    else if (keyLetter == "n")
                    {
                        textBoxEncrypt.Text += n[tabelIndex].ToString();
                    }
                    else if (keyLetter == "o")
                    {
                        textBoxEncrypt.Text += o[tabelIndex].ToString();
                    }
                    else if (keyLetter == "p")
                    {
                        textBoxEncrypt.Text += p[tabelIndex].ToString();
                    }
                    else if (keyLetter == "q")
                    {
                        textBoxEncrypt.Text += q[tabelIndex].ToString();
                    }
                    else if (keyLetter == "r")
                    {
                        textBoxEncrypt.Text += r[tabelIndex].ToString();
                    }
                    else if (keyLetter == "s")
                    {
                        textBoxEncrypt.Text += s[tabelIndex].ToString();
                    }
                    else if (keyLetter == "t")
                    {
                        textBoxEncrypt.Text += t[tabelIndex].ToString();
                    }
                    else if (keyLetter == "u")
                    {
                        textBoxEncrypt.Text += u[tabelIndex].ToString();
                    }
                    else if (keyLetter == "v")
                    {
                        textBoxEncrypt.Text += v[tabelIndex].ToString();
                    }
                    else if (keyLetter == "w")
                    {
                        textBoxEncrypt.Text += w[tabelIndex].ToString();
                    }
                    else if (keyLetter == "x")
                    {
                        textBoxEncrypt.Text += z[tabelIndex].ToString();
                    }
                    else if (keyLetter == "y")
                    {
                        textBoxEncrypt.Text += y[tabelIndex].ToString();
                    }
                    else if (keyLetter == "z")
                    {
                        textBoxEncrypt.Text += z[tabelIndex].ToString();
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("error!! With keyletter: " + keyLetter + " & LetterIndex: " + tabelIndex + "\r\nPlease contact me on discord \"2CAN0_Music#0003\" about this error");
                }
            }
            if (secondEncryption == false)
            {
                secondEncryption = true;
                goto DoubleEncrypt;
            }
            else
                secondEncryption = false;
        }
        #endregion

        #region Decrypt
        private void Decrypt()
        {
            //Key
            string key = "cipher";
            int keyIndex = 0;
            string keyLetter = "";

            //Text
            int length = textBoxDecrypt.Text.Length;
            string text = textBoxDecrypt.Text;
            int textIndex = 0;
            string textLetter = "";
            int tabelIndex = 0;

            // Tabel voor letter encryptie
            string[] a = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "\r\n" };
            string[] b = { "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a" };
            string[] c = { "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b" };
            string[] d = { "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c" };
            string[] e = { "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d" };
            string[] f = { "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e" };
            string[] g = { "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f" };
            string[] h = { "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g" };
            string[] i = { "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h" };
            string[] j = { "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h", "i" };
            string[] k = { "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
            string[] l = { "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k" };
            string[] m = { "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l" };
            string[] n = { "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m" };
            string[] o = { "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n" };
            string[] p = { "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o" };
            string[] q = { "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p" };
            string[] r = { "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q" };
            string[] s = { "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r" };
            string[] t = { "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s" };
            string[] u = { "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t" };
            string[] v = { "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u" };
            string[] w = { "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v" };
            string[] x = { "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w" };
            string[] y = { "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x" };
            string[] z = { "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", ",", "?", "/", "(", ")", "*", "&", "^", "%", "$", "#", "@", "!", "~", "`", "'", "<", ">", "+", "=", "-", "_", "{", "}", "[", "]", "\"", "\\", "€", "¤", ";", ":", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y" };

            bool SecondDebug = false;
            DebugAgain:
            if (SecondDebug == true)
            {
                text = textBoxMain.Text;
                length = textBoxMain.Text.Length;
                textBoxMain.Text = "";
            }

            for (textIndex = 0; textIndex < length; textIndex++)
            {
                //Check KeyIndex
                if (keyIndex == key.Length)
                {
                    keyIndex = 0;
                }
                keyLetter = key[keyIndex].ToString();
                keyIndex++;
                textLetter = text[textIndex].ToString();                

                try
                {
                    tabelIndex = Array.IndexOf(a, textLetter);
                    if (tabelIndex == -1)
                    {
                        textIndex++;
                        textBoxMain.Text += "\r\n";
                        keyIndex--;
                    }
                    else if (keyLetter == "a")
                    {
                        tabelIndex = Array.IndexOf(a, textLetter);
                        textBoxMain.Text += a[tabelIndex].ToString();
                    }
                    else if (keyLetter == "b")
                    {
                        tabelIndex = Array.IndexOf(b, textLetter);
                        textBoxMain.Text += a[tabelIndex].ToString();
                    }
                    else if (keyLetter == "c")
                    {
                        tabelIndex = Array.IndexOf(c, textLetter);
                        textBoxMain.Text += a[tabelIndex].ToString();
                    }
                    else if (keyLetter == "d")
                    {
                        tabelIndex = Array.IndexOf(d, textLetter);
                        textBoxMain.Text += a[tabelIndex].ToString();
                    }
                    else if (keyLetter == "e")
                    {
                        tabelIndex = Array.IndexOf(e, textLetter);
                        textBoxMain.Text += a[tabelIndex].ToString();
                    }
                    else if (keyLetter == "f")
                    {
                        tabelIndex = Array.IndexOf(f, textLetter);
                        textBoxMain.Text += a[tabelIndex].ToString();
                    }
                    else if (keyLetter == "g")
                    {
                        tabelIndex = Array.IndexOf(g, textLetter);
                        textBoxMain.Text += a[tabelIndex].ToString();
                    }
                    else if (keyLetter == "h")
                    {
                        tabelIndex = Array.IndexOf(h, textLetter);
                        textBoxMain.Text += a[tabelIndex].ToString();
                    }
                    else if (keyLetter == "i")
                    {
                        tabelIndex = Array.IndexOf(i, textLetter);
                        textBoxMain.Text += a[tabelIndex].ToString();
                    }
                    else if (keyLetter == "j")
                    {
                        tabelIndex = Array.IndexOf(j, textLetter);
                        textBoxMain.Text += a[tabelIndex].ToString();
                    }
                    else if (keyLetter == "k")
                    {
                        tabelIndex = Array.IndexOf(k, textLetter);
                        textBoxMain.Text += a[tabelIndex].ToString();
                    }
                    else if (keyLetter == "l")
                    {
                        tabelIndex = Array.IndexOf(l, textLetter);
                        textBoxMain.Text += a[tabelIndex].ToString();
                    }
                    else if (keyLetter == "m")
                    {
                        tabelIndex = Array.IndexOf(m, textLetter);
                        textBoxMain.Text += a[tabelIndex].ToString();
                    }
                    else if (keyLetter == "n")
                    {
                        tabelIndex = Array.IndexOf(n, textLetter);
                        textBoxMain.Text += a[tabelIndex].ToString();
                    }
                    else if (keyLetter == "o")
                    {
                        tabelIndex = Array.IndexOf(o, textLetter);
                        textBoxMain.Text += a[tabelIndex].ToString();
                    }
                    else if (keyLetter == "p")
                    {
                        tabelIndex = Array.IndexOf(p, textLetter);
                        textBoxMain.Text += a[tabelIndex].ToString();
                    }
                    else if (keyLetter == "q")
                    {
                        tabelIndex = Array.IndexOf(q, textLetter);
                        textBoxMain.Text += a[tabelIndex].ToString();
                    }
                    else if (keyLetter == "r")
                    {
                        tabelIndex = Array.IndexOf(r, textLetter);
                        textBoxMain.Text += a[tabelIndex].ToString();
                    }
                    else if (keyLetter == "s")
                    {
                        tabelIndex = Array.IndexOf(s, textLetter);
                        textBoxMain.Text += a[tabelIndex].ToString();
                    }
                    else if (keyLetter == "t")
                    {
                        tabelIndex = Array.IndexOf(t, textLetter);
                        textBoxMain.Text += a[tabelIndex].ToString();
                    }
                    else if (keyLetter == "u")
                    {
                        tabelIndex = Array.IndexOf(u, textLetter);
                        textBoxMain.Text += a[tabelIndex].ToString();
                    }
                    else if (keyLetter == "v")
                    {
                        tabelIndex = Array.IndexOf(v, textLetter);
                        textBoxMain.Text += a[tabelIndex].ToString();
                    }
                    else if (keyLetter == "w")
                    {
                        tabelIndex = Array.IndexOf(w, textLetter);
                        textBoxMain.Text += a[tabelIndex].ToString();
                    }
                    else if (keyLetter == "x")
                    {
                        tabelIndex = Array.IndexOf(x, textLetter);
                        textBoxMain.Text += a[tabelIndex].ToString();
                    }
                    else if (keyLetter == "y")
                    {
                        tabelIndex = Array.IndexOf(y, textLetter);
                        textBoxMain.Text += a[tabelIndex].ToString();
                    }
                    else if (keyLetter == "z")
                    {
                        tabelIndex = Array.IndexOf(z, textLetter);
                        textBoxMain.Text += a[tabelIndex].ToString();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("error!! With keyletter: " + keyLetter + " & LetterIndex: " + tabelIndex + "\r\nPlease contact me on discord \"2CAN0_Music#0003\" about this error");
                }
            }
            if (SecondDebug == false)
            {
                SecondDebug = true;
                goto DebugAgain;
            }
            else
                SecondDebug = false;
        }
        #endregion

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.FileName = "Untitled.2AO";

            save.Filter = "Encrypted Text File | *.2AO";

            if (save.ShowDialog() == DialogResult.OK)
            {
                if (save.FileName != "")
                {
                    textBoxEncrypt.Text = "";
                    Encrypt();
                    using (StreamWriter sw = new StreamWriter(save.OpenFile()))
                    {                       
                        sw.Write(textBoxEncrypt.Text);
                    }
                    FileName = Path.GetFileName(save.FileName);
                    Form1.ActiveForm.Text = FileName + "   ||   (Encrypted)TextEditor By 2CAN0";
                    FileName = save.FileName;
                }
                else
                {
                    MessageBox.Show("You didn't enter a filename");
                }
                Changed = false;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Changed == true)
            {
                DialogResult Save = MessageBox.Show("Do you want to save your changes?", "2CAN0's TextEditor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (Save == DialogResult.Yes)
                {
                    SaveFileDialog save = new SaveFileDialog();

                    save.FileName = "Untitled.2AO";

                    save.Filter = "Encrypted Text File | *.2AO";

                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        if (save.FileName != "")
                        {
                            textBoxEncrypt.Text = "";
                            Encrypt();
                            using (StreamWriter sw = new StreamWriter(save.OpenFile()))
                            {
                                sw.Write(textBoxEncrypt.Text);
                            }
                            Changed = false;
                        }
                        else
                        {
                            MessageBox.Show("You didn't enter a filename");
                        }
                    }
                }
                else if (Save == DialogResult.No)
                {
                    textBoxMain.Text = "";
                }
                else
                {
                    //
                }
            }

            OpenFileDialog OF = new OpenFileDialog();
            OF.InitialDirectory = "C:\\";
            OF.Filter = "Encrypted Text File (*.2AO)|*.2AO|Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            OF.FilterIndex = 0;

            if (OF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBoxEncrypt.Text = "";
                textBoxMain.Text = "";
                StreamReader sr = new StreamReader(OF.FileName);

                OF.RestoreDirectory = true;
                if (OF.FileName.Contains(".2AO"))
                {
                    textBoxDecrypt.Text = sr.ReadToEnd();
                    Decrypt();
                    sr.Close();
                }
                else
                {
                    textBoxMain.Text = sr.ReadToEnd();
                    sr.Close();
                }
                FileName = Path.GetFileName(OF.FileName);
                Form1.ActiveForm.Text = FileName + "   ||   (Encrypted)TextEditor By 2CAN0";
                FileName = OF.FileName;
                Changed = false;
            }
        }

        private void saveCtrlSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FileName.Length == 0)
            {
                SaveFileDialog save = new SaveFileDialog();

                save.FileName = "Untitled.2AO";

                save.Filter = "Text File | *.2AO";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (save.FileName != "")
                    {
                        textBoxEncrypt.Text = "";
                        Encrypt();
                        using (StreamWriter sw = new StreamWriter(save.OpenFile()))
                        {
                            sw.Write(textBoxEncrypt.Text);
                        }
                        FileName = Path.GetFileName(save.FileName);
                        Form1.ActiveForm.Text = FileName + "   ||   (Encrypted)TextEditor By 2CAN0";
                        FileName = save.FileName;
                    }
                    else
                    {
                        MessageBox.Show("You didn't enter a filename");
                    }
                }
            }
            else
            {
                textBoxEncrypt.Text = "";
                Encrypt();
                using (StreamWriter sw = new StreamWriter(FileName))
                {

                    sw.Write(textBoxEncrypt.Text);
                }
            }
        }
        #endregion

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            textBoxMain.Width = this.Width - 11;
            textBoxMain.Height = this.Height - 54;
            panel1.Width = this.Width - 10;
        }

        #region EditButton
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            Button Sender = (Button)sender;
            Point left = new Point(0, Sender.Height - 2);
            left = Sender.PointToScreen(left);
            contextMenuStripEdit.Show(left);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxMain.SelectedText);
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxMain.Text.Replace(textBoxMain.SelectedText, "");
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxMain.Text += Clipboard.GetText();
        }
        #endregion

        private void buttonFormat_Click(object sender, EventArgs e)
        {
            Button Sender = (Button)sender;
            Point left = new Point(0, Sender.Height - 2);
            left = Sender.PointToScreen(left);
            contextMenuStripFormat.Show(left);
        }

        private void fontNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelFont.Visible = true;
        }

        public bool Changed = false;

        #region Shortcuts
        private void textBoxMain_KeyDown(object sender, KeyEventArgs e)
        {
            bool Save;
            bool SaveAs;
            bool Open;
            bool New;
            bool Search;
            Save = ((e.KeyCode == Keys.S) && ((e.Modifiers & Keys.Control) != 0));
            SaveAs = ((e.KeyCode == Keys.S) && ((e.Modifiers & Keys.Control) != 0) && ((e.Modifiers & Keys.Shift) != 0));
            Open = ((e.KeyCode == Keys.O) && ((e.Modifiers & Keys.Control) != 0));
            New = ((e.KeyCode == Keys.N) && ((e.Modifiers & Keys.Control) != 0));
            Search = ((e.KeyCode == Keys.F) && ((e.Modifiers & Keys.Control) != 0));


            if (Save == true)
            {
                #region Save
                if (FileName.Length == 0)
                {
                    SaveFileDialog save = new SaveFileDialog();

                    save.FileName = "Untitled.2AO";

                    save.Filter = "Encrypted Text File|*.2AO|All Files|*.*";

                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        if (save.FileName != "")
                        {
                            textBoxEncrypt.Text = "";
                            Encrypt();
                            using (StreamWriter sw = new StreamWriter(save.OpenFile()))
                            {
                                sw.Write(textBoxEncrypt.Text);
                            }
                        }
                        else
                        {
                            MessageBox.Show("You didn't enter a filename");
                        }
                    }
                    FileName = Path.GetFileName(save.FileName);
                    Form1.ActiveForm.Text = FileName + "   ||   (Encrypted)TextEditor By 2CAN0";
                    FileName = save.FileName;
                }
                else
                {
                    textBoxEncrypt.Text = "";
                    Encrypt();
                    using (StreamWriter sw = new StreamWriter(FileName))
                    {

                        sw.Write(textBoxEncrypt.Text);
                    }
                }
                #endregion
            }
            else if (SaveAs == true)
            {
                #region SaveAs
                SaveFileDialog save = new SaveFileDialog();

                save.FileName = "Untitled.2AO";

                save.Filter = "Encrypted Text File|*.2AO|All Files|*.*";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (save.FileName != "")
                    {
                        textBoxEncrypt.Text = "";
                        Encrypt();
                        using (StreamWriter sw = new StreamWriter(save.OpenFile()))
                        {
                            sw.Write(textBoxEncrypt.Text);
                        }
                        FileName = Path.GetFileName(save.FileName);
                        Form1.ActiveForm.Text = FileName + "   ||   (Encrypted)TextEditor By 2CAN0";
                        FileName = save.FileName;
                    }
                    else
                    {
                        MessageBox.Show("You didn't enter a filename");
                    }
                }
                #endregion
            }
            else if (Open == true)
            {
                #region Open
                if (Changed == true)
                {
                    DialogResult DialogS = MessageBox.Show("Do you want to save your changes?", "2CAN0's TextEditor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                    if (DialogS == DialogResult.Yes)
                    {
                        SaveFileDialog save = new SaveFileDialog();

                        save.FileName = "Untitled.2AO";

                        save.Filter = "Encrypted Text File | *.2AO";

                        if (save.ShowDialog() == DialogResult.OK)
                        {
                            if (save.FileName != "")
                            {
                                textBoxEncrypt.Text = "";
                                Encrypt();
                                using (StreamWriter sw = new StreamWriter(save.OpenFile()))
                                {
                                    sw.Write(textBoxEncrypt.Text);
                                }
                                Changed = false;
                            }
                            else
                            {
                                MessageBox.Show("You didn't enter a filename");
                            }
                        }
                    }
                    else if (DialogS == DialogResult.No)
                    {
                        textBoxMain.Text = "";
                    }
                    else
                    {
                        //
                    }
                }

                OpenFileDialog OF = new OpenFileDialog();
                OF.InitialDirectory = "C:\\";
                OF.Filter = "Encrypted Text File (*.2AO)|*.2AO|Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                OF.FilterIndex = 0;

                if (OF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    textBoxEncrypt.Text = "";
                    textBoxMain.Text = "";
                    StreamReader sr = new StreamReader(OF.FileName);

                    OF.RestoreDirectory = true;
                    if (OF.FileName.Contains(".2AO"))
                    {
                        textBoxDecrypt.Text = sr.ReadToEnd();
                        Decrypt();
                        sr.Close();
                    }
                    else
                    {
                        textBoxMain.Text = sr.ReadToEnd();
                        sr.Close();
                    }
                    FileName = Path.GetFileName(OF.FileName);
                    Filenmae = Path.GetFileName(OF.FileName);
                    Form1.ActiveForm.Text = FileName + "   ||   (Encrypted)TextEditor By 2CAN0";
                    FileName = OF.FileName;
                }
                #endregion
            }
            else if (New == true)
            {
                #region New
                if (Changed == true)
                {
                    DialogResult DialogSave = MessageBox.Show("Do you want to save your changes?", "2CAN0's TextEditor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                    if (DialogSave == DialogResult.Yes)
                    {
                        SaveFileDialog save = new SaveFileDialog();

                        save.FileName = "Untitled.2AO";

                        save.Filter = "Encrypted Text File | *.2AO";

                        if (save.ShowDialog() == DialogResult.OK)
                        {
                            if (save.FileName != "")
                            {
                                textBoxEncrypt.Text = "";
                                Encrypt();
                                using (StreamWriter sw = new StreamWriter(save.OpenFile()))
                                {
                                    sw.Write(textBoxEncrypt.Text);
                                }
                                Changed = false;
                            }
                            else
                            {
                                MessageBox.Show("You didn't enter a filename");
                            }
                        }
                        Form1.ActiveForm.Text = "Untitled.2AO   ||   (Encrypted)TextEditor By 2CAN0";
                    }
                    else if (DialogSave == DialogResult.No)
                    {
                        textBoxMain.Text = "";
                        Form1.ActiveForm.Text = "Untitled.2AO   ||   (Encrypted)TextEditor By 2CAN0";
                    }
                    else
                    {
                        //
                    }
                }
                else
                {
                    textBoxMain.Text = "";
                    Form1.ActiveForm.Text = "Untitled.2AO   ||   (Encrypted)TextEditor By 2CAN0";
                }
                #endregion
            }
            else if (Search== true)
            {
                #region Search
                panelSearch.Visible = true;
                panelSearch.Location = new Point(170, 160);
                #endregion
            }
        }

        private void textBoxMain_TextChanged(object sender, EventArgs e)
        {
            if (StartUpLoading != true)
            {
                Changed = true;
                if (Filenmae != null)
                    Form1.ActiveForm.Text = "*" + Filenmae + "   ||   (Encrypted)TextEditor By 2CAN0";
                else if (FileParts != null)
                    Form1.ActiveForm.Text = "*" + FileParts + "   ||   (Encrypted)TextEditor By 2CAN0";
                else
                    Form1.ActiveForm.Text = "*Untitled.2AO   ||   (Encrypted)TextEditor By 2CAN0";
            }
        }

        private string Filenmae;


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            bool Save;
            bool SaveAs;
            bool Open;
            bool New;
            Save = ((e.KeyCode == Keys.S) && ((e.Modifiers & Keys.Control) != 0));
            SaveAs = ((e.KeyCode == Keys.S) && ((e.Modifiers & Keys.Control) != 0) && ((e.Modifiers & Keys.Shift) != 0));
            Open = ((e.KeyCode == Keys.O) && ((e.Modifiers & Keys.Control) != 0));
            New = ((e.KeyCode == Keys.N) && ((e.Modifiers & Keys.Control) != 0));


            if (Save == true)
            {
                #region Save
                if (FileName.Length == 0)
                {
                    SaveFileDialog save = new SaveFileDialog();

                    save.FileName = "Untitled.2AO";

                    save.Filter = "Encrypted Text File|*.2AO|All Files|*.*";

                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        if (save.FileName != "")
                        {
                            textBoxEncrypt.Text = "";
                            Encrypt();
                            using (StreamWriter sw = new StreamWriter(save.OpenFile()))
                            {
                                sw.Write(textBoxEncrypt.Text);
                            }
                        }
                        else
                        {
                            MessageBox.Show("You didn't enter a filename");
                        }
                    }
                    FileName = Path.GetFileName(save.FileName);
                    Form1.ActiveForm.Text = FileName + "   ||   (Encrypted)TextEditor By 2CAN0";
                    FileName = save.FileName;
                }
                else
                {
                    textBoxEncrypt.Text = "";
                    Encrypt();
                    using (StreamWriter sw = new StreamWriter(FileName))
                    {

                        sw.Write(textBoxEncrypt.Text);
                    }
                }
                #endregion
            }
            else if (SaveAs == true)
            {
                #region SaveAs
                SaveFileDialog save = new SaveFileDialog();

                save.FileName = "Untitled.2AO";

                save.Filter = "Encrypted Text File|*.2AO|All Files|*.*";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (save.FileName != "")
                    {
                        textBoxEncrypt.Text = "";
                        Encrypt();
                        using (StreamWriter sw = new StreamWriter(save.OpenFile()))
                        {
                            sw.Write(textBoxEncrypt.Text);
                        }
                        FileName = Path.GetFileName(save.FileName);
                        Form1.ActiveForm.Text = FileName + "   ||   (Encrypted)TextEditor By 2CAN0";
                        FileName = save.FileName;
                    }
                    else
                    {
                        MessageBox.Show("You didn't enter a filename");
                    }
                }
                #endregion
            }
            else if (Open == true)
            {
                #region Open
                if (Changed == true)
                {
                    DialogResult DialogS = MessageBox.Show("Do you want to save your changes?", "2CAN0's TextEditor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                    if (DialogS == DialogResult.Yes)
                    {
                        SaveFileDialog save = new SaveFileDialog();

                        save.FileName = "Untitled.2AO";

                        save.Filter = "Encrypted Text File | *.2AO";

                        if (save.ShowDialog() == DialogResult.OK)
                        {
                            if (save.FileName != "")
                            {
                                textBoxEncrypt.Text = "";
                                Encrypt();
                                using (StreamWriter sw = new StreamWriter(save.OpenFile()))
                                {
                                    sw.Write(textBoxEncrypt.Text);
                                }
                                Changed = false;
                            }
                            else
                            {
                                MessageBox.Show("You didn't enter a filename");
                            }
                        }
                    }
                    else if (DialogS == DialogResult.No)
                    {
                        textBoxMain.Text = "";
                    }
                    else
                    {
                        //
                    }
                }

                OpenFileDialog OF = new OpenFileDialog();
                OF.InitialDirectory = "C:\\";
                OF.Filter = "Encrypted Text File (*.2AO)|*.2AO|Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                OF.FilterIndex = 0;

                if (OF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    textBoxEncrypt.Text = "";
                    textBoxMain.Text = "";
                    StreamReader sr = new StreamReader(OF.FileName);

                    OF.RestoreDirectory = true;
                    if (OF.FileName.Contains(".2AO"))
                    {
                        textBoxDecrypt.Text = sr.ReadToEnd();
                        Decrypt();
                        sr.Close();
                    }
                    else
                    {
                        textBoxMain.Text = sr.ReadToEnd();
                        sr.Close();
                    }
                    FileName = Path.GetFileName(OF.FileName);
                    Form1.ActiveForm.Text = FileName + "   ||   (Encrypted)TextEditor By 2CAN0";
                    FileName = OF.FileName;
                }
                #endregion
            }
            else if (New == true)
            {
                #region New
                if (Changed == true)
                {
                    DialogResult DialogSave = MessageBox.Show("Do you want to save your changes?", "2CAN0's TextEditor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                    if (DialogSave == DialogResult.Yes)
                    {
                        SaveFileDialog save = new SaveFileDialog();

                        save.FileName = "Untitled.2AO";

                        save.Filter = "Encrypted Text File | *.2AO";

                        if (save.ShowDialog() == DialogResult.OK)
                        {
                            if (save.FileName != "")
                            {
                                textBoxEncrypt.Text = "";
                                Encrypt();
                                using (StreamWriter sw = new StreamWriter(save.OpenFile()))
                                {
                                    sw.Write(textBoxEncrypt.Text);
                                }
                                Changed = false;
                            }
                            else
                            {
                                MessageBox.Show("You didn't enter a filename");
                            }
                        }
                        Form1.ActiveForm.Text = "Untitled.2AO   ||   (Encrypted)TextEditor By 2CAN0";
                    }
                    else if (DialogSave == DialogResult.No)
                    {
                        textBoxMain.Text = "";
                        Form1.ActiveForm.Text = "Untitled.2AO   ||   (Encrypted)TextEditor By 2CAN0";
                    }
                    else
                    {
                        //
                    }
                }
                else
                {
                    textBoxMain.Text = "";
                    Form1.ActiveForm.Text = "Untitled.2AO   ||   (Encrypted)TextEditor By 2CAN0";
                }
                #endregion
            }
        }
        #endregion

        #region Font
        private void button1_Click(object sender, EventArgs e)
        {
            panelFont.Visible = false;
            panelFont.Location = new Point(171, 119);
        }

        Point lastPoint;
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                panelFont.Left += e.X - lastPoint.X;
                panelFont.Top += e.Y - lastPoint.Y;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            textBoxMain.Font = new Font(domainUpDownFont.SelectedItem.ToString(), Convert.ToInt32(numericFontSize.Value));
        }

        private void checkBoxBold_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBold.Checked == true)
            {
                textBoxMain.Font = new Font(domainUpDownFont.SelectedItem.ToString(), Convert.ToInt32(numericFontSize.Value), FontStyle.Bold);
                checkBoxItalic.Checked = false;
                checkBoxBoldItalic.Checked = false;
            }
            else if (checkBoxBoldItalic.Checked == false && checkBoxBold.Checked == false && checkBoxItalic.Checked == false)
            {
                textBoxMain.Font = new Font(domainUpDownFont.SelectedItem.ToString(), Convert.ToInt32(numericFontSize.Value));
            }
        }

        private void checkBoxItalic_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxItalic.Checked == true)
            {
                textBoxMain.Font = new Font(domainUpDownFont.SelectedItem.ToString(), Convert.ToInt32(numericFontSize.Value), FontStyle.Italic);
                checkBoxBoldItalic.Checked = false;
                checkBoxBold.Checked = false;
            }
            else if (checkBoxBoldItalic.Checked == false && checkBoxBold.Checked == false && checkBoxItalic.Checked == false)
            {
                textBoxMain.Font = new Font(domainUpDownFont.SelectedItem.ToString(), Convert.ToInt32(numericFontSize.Value));
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBoldItalic.Checked == true)
            {
                textBoxMain.Font = new Font(domainUpDownFont.SelectedItem.ToString(), Convert.ToInt32(numericFontSize.Value), FontStyle.Bold | FontStyle.Italic);
                checkBoxItalic.Checked = false;
                checkBoxBold.Checked = false;
            }
            else if (checkBoxBoldItalic.Checked == false && checkBoxBold.Checked == false && checkBoxItalic.Checked == false)
                textBoxMain.Font = new Font(domainUpDownFont.SelectedItem.ToString(), Convert.ToInt32(numericFontSize.Value));
        }

        private void domainUpDownFont_SelectedItemChanged(object sender, EventArgs e)
        {

            if (checkBoxBold.Checked == true)
            {
                textBoxMain.Font = new Font(domainUpDownFont.SelectedItem.ToString(), Convert.ToInt32(numericFontSize.Value), FontStyle.Bold);
                checkBoxItalic.Checked = false;
                checkBoxBoldItalic.Checked = false;
            }
            else if (checkBoxBoldItalic.Checked == true)
            {
                textBoxMain.Font = new Font(domainUpDownFont.SelectedItem.ToString(), Convert.ToInt32(numericFontSize.Value), FontStyle.Bold | FontStyle.Italic);
                checkBoxItalic.Checked = false;
                checkBoxBold.Checked = false;
            }
            else if (checkBoxItalic.Checked == true)
            {
                textBoxMain.Font = new Font(domainUpDownFont.SelectedItem.ToString(), Convert.ToInt32(numericFontSize.Value), FontStyle.Italic);
                checkBoxBoldItalic.Checked = false;
                checkBoxBold.Checked = false;
            }
            else
                textBoxMain.Font = new Font(domainUpDownFont.SelectedItem.ToString(), Convert.ToInt32(numericFontSize.Value));
        }
        #endregion

        #region RemoveDupe
        private void buttonDupeClose_Click(object sender, EventArgs e)
        {
            panelRemove.Visible = false;
            panelRemove.Location = new Point(124, 58);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            buttonRemove.Text = "Removing Dupes...";
            backgroundWorkerDupes.RunWorkerAsync();
        }

        private void removeDuplicatesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panelRemove.Visible = true;
            panelRemove.Location = new Point();
        }

        private void panelTitelDupe_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                panelRemove.Left += e.X - lastPoint.X;
                panelRemove.Top += e.Y - lastPoint.Y;
            }
        }

        private void panelTitelDupe_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void backgroundWorkerDupes_DoWork(object sender, DoWorkEventArgs e)
        {
            int removed = 0;
            listBoxOld.Items.Clear();
            listBoxNew.Items.Clear();
            if (radioButtonLines.Checked == true)
                listBoxOld.Items.AddRange(textBoxMain.Text.Split(new char[] { '\n', '\r' }));
            else if (radioButtonWords.Checked == true)
                listBoxOld.Items.AddRange(textBoxMain.Text.Split(new char[] { ' '}));

            foreach (string line in listBoxOld.Items)
            {
                if (listBoxNew.Items.Contains(line))
                {
                    //
                }
                else
                    listBoxNew.Items.Add(line);
            }
            removed = listBoxOld.Items.Count - listBoxNew.Items.Count;

            textBoxMain.Text = "";
            if (radioButtonLines.Checked == true)
            {
                foreach (var line in listBoxNew.Items)
                    textBoxMain.Text += line.ToString() + "\r\n";
            }
            else
            {
                foreach (var line in listBoxNew.Items)
                {
                    textBoxMain.Text += line.ToString() + " ";
                }
            }

            buttonRemove.Text = "Remove";
            if (radioButtonLines.Checked == true)
            {
                if (removed > 1 || removed == 0)
                    MessageBox.Show(removed + " lines have been removed", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(removed + " line has been removed", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (removed > 1 || removed == 0)
                    MessageBox.Show(removed + " words have been removed", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(removed + " word has been removed", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Search
        private int r;
        private int g;
        private int b;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int hits = 0;
            int start = 0;
            int end = textBoxMain.Text.LastIndexOf(textBoxSearch.Text);

            textBoxMain.SelectAll();
            textBoxMain.SelectionBackColor = Color.White;
            Color color = new Color();

            while (start < end)
            {
                textBoxMain.Find(textBoxSearch.Text, start, textBoxMain.TextLength, RichTextBoxFinds.MatchCase);

                textBoxMain.SelectionBackColor = Color.FromArgb(r, g, b);
                start = textBoxMain.Text.IndexOf(textBoxSearch.Text, start) + 1;
            }

            if (textBoxMain.Text.Contains(textBoxSearch.Text))
            {

                textBoxSearch.BackColor = Color.Green;
                hits = Regex.Matches(textBoxMain.Text, textBoxSearch.Text).Count;              
            }
            else
            {
                textBoxSearch.BackColor = Color.Red;
                textBoxMain.SelectAll();
                textBoxMain.SelectionBackColor = Color.White;
            }
            if (textBoxSearch.Text.Length == 0)
            {
                textBoxSearch.BackColor = Color.White;
                textBoxMain.SelectAll();
                textBoxMain.SelectionBackColor = Color.White;
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelSearch.Visible = true;
            panelSearch.Location = new Point(170, 160);
        }

        private void buttonSearchExit_Click(object sender, EventArgs e)
        {
            panelSearch.Visible = false;
            textBoxSearch.Text = "";
        }

        private void panelTitelSearch_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                panelSearch.Left += e.X - lastPoint.X;
                panelSearch.Top += e.Y - lastPoint.Y;
            }
        }


        private void panelTitelSearch_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void domainUpDownHighlightColor_SelectedItemChanged(object sender, EventArgs e)
        {
            if (domainUpDownHighlightColor.SelectedIndex == domainUpDownHighlightColor.Items.Count - 3)
            {
                //LimeGreen
                r = 0;
                g = 255;
                b = 0;
            }
            else if (domainUpDownHighlightColor.SelectedIndex == domainUpDownHighlightColor.Items.Count - 4)
            {
                //Green
                r = 0;
                g = 128;
                b = 0;
            }
            else if (domainUpDownHighlightColor.SelectedIndex == domainUpDownHighlightColor.Items.Count - 8)
            {
                //Red
                r = 255;
                g = 0;
                b = 0;
            }
            else if (domainUpDownHighlightColor.SelectedIndex == domainUpDownHighlightColor.Items.Count - 2)
            {
                //Blue
                r = 0;
                g = 0;
                b = 255;
            }
            else if (domainUpDownHighlightColor.SelectedIndex == domainUpDownHighlightColor.Items.Count - 1)
            {
                //Cyan
                r = 0;
                g = 255;
                b = 255;
            }
            else if (domainUpDownHighlightColor.SelectedIndex == domainUpDownHighlightColor.Items.Count - 5)
            {
                //Yellow
                r = 255;
                g = 255;
                b = 0;
            }
            else if (domainUpDownHighlightColor.SelectedIndex == domainUpDownHighlightColor.Items.Count - 6)
            {
                //Orange
                r = 255;
                g = 127;
                b = 0;
            }
            else if (domainUpDownHighlightColor.SelectedIndex == domainUpDownHighlightColor.Items.Count - 7)
            {
                //Gold
                r = 255;
                g = 193;
                b = 37;
            }

        }
        #endregion

        private void textBoxMain_Click(object sender, EventArgs e)
        {
            
        }

        #region mouse RightClick
        private void textBoxMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ContextMenu contextMenu = new System.Windows.Forms.ContextMenu();
                MenuItem menuItem = new MenuItem("Cut      (Ctrl + X)");
                menuItem.Click += new EventHandler(CutAction);
                contextMenu.MenuItems.Add(menuItem);
                menuItem = new MenuItem("Copy   (Ctrl + C)");
                menuItem.Click += new EventHandler(CopyAction);
                contextMenu.MenuItems.Add(menuItem);
                menuItem = new MenuItem("Paste   (Ctrl + V)");
                menuItem.Click += new EventHandler(PasteAction);
                contextMenu.MenuItems.Add(menuItem);

                textBoxMain.ContextMenu = contextMenu;
            }
        }

        void CutAction(object sender, EventArgs e)
        {
            textBoxMain.Cut();
        }

        void CopyAction(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxMain.SelectedText);
        }

        void PasteAction(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                textBoxMain.Text
                    += Clipboard.GetText(TextDataFormat.Text).ToString();
            }
        }
        #endregion

        private void button1_Click_1(object sender, EventArgs e)
        {
            Button Sender = (Button)sender;
            Point left = new Point(0, Sender.Height - 2);
            left = Sender.PointToScreen(left);
            contextMenuStripAbout.Show(left);
        }

        private void Changelog_Click(object sender, EventArgs e)
        {
            Process.Start("Http://multichecker.tech/Changelog");
        }

        private void About_Click(object sender, EventArgs e)
        {
            Process.Start("Http://multichecker.tech/About");
        }

        private void Contact_Click(object sender, EventArgs e)
        {
            Process.Start("Http://multichecker.tech/Contact");
        }

        private void Faq_Click(object sender, EventArgs e)
        {
            Process.Start("Http://multichecker.tech/Faq");
        }
    }

    #region DropDownButton
    public class MenuButton : Button
    {
        [DefaultValue(null)]
        public ContextMenuStrip Menu { get; set; }

        [DefaultValue(false)]
        public bool ShowMenuUnderCursor { get; set; }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);

            if (Menu != null && mevent.Button == MouseButtons.Left)
            {
                Point menuLocation;

                if (ShowMenuUnderCursor)
                {
                    menuLocation = mevent.Location;
                }
                else
                {
                    menuLocation = new Point(0, Height);
                }

                Menu.Show(this, menuLocation);
            }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            if (Menu != null)
            {
                int arrowX = ClientRectangle.Width - 14;
                int arrowY = ClientRectangle.Height / 2 - 1;

                Brush brush = Enabled ? SystemBrushes.ControlText : SystemBrushes.ButtonShadow;
                Point[] arrows = new Point[] { new Point(arrowX, arrowY), new Point(arrowX + 7, arrowY), new Point(arrowX + 3, arrowY + 4) };
                pevent.Graphics.FillPolygon(brush, arrows);
            }
        }
    }
    #endregion
}
