using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace FractonationApp
{
    public partial class Form1 : Form
    {
        private List<Box> Letters;

        public Form1()
        {
            InitializeComponent();
        }

        static List<int> RandomNum()
        {
            Random rand = new Random();
            List<int> numbers = new List<int> { 1,2,3,4,5 };
            List<int> result = new List<int>();
            int n = 5;
            for (int i = 0; i < 5; i++)
            {
                int r = rand.Next(n);
                result.Add(numbers[r]);
                numbers.RemoveAt(r);
                n--;
            }
            return result;
        }

        public char GetChar(int Xpos, int Ypos)
        {
            char result = 'A';
            foreach(Box b in Letters)
            {
                if(b.getX()==Xpos && b.getY() == Ypos)
                {
                    result = b.Character;
                    break;
                }
            }
            return result;
        }

        public int[] GetPos(char c)
        {
            int[] result = new int[2];
            foreach(Box b in Letters)
            {
                if (b.Character == c)
                {
                    result[0] = b.getX();
                    result[1] = b.getY();
                    break;
                }
            }
            return result;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                Letters = new List<Box>();

                //losowanie liczb indeksowych
                List<int> XNum = RandomNum();
                numberX1.Text = XNum[0].ToString();
                numberX2.Text = XNum[1].ToString();
                numberX3.Text = XNum[2].ToString();
                numberX4.Text = XNum[3].ToString();
                numberX5.Text = XNum[4].ToString();
                Thread.Sleep(500);
                List<int> YNum = RandomNum();
                numberY1.Text = YNum[0].ToString();
                numberY2.Text = YNum[1].ToString();
                numberY3.Text = YNum[2].ToString();
                numberY4.Text = YNum[3].ToString();
                numberY5.Text = YNum[4].ToString();

                //towrzenie tabeli
                List<char> Alphabet = new List<char> {'A','B','C','D','E','F','G','H','I','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z' };
                List<char> KeyAlphabet = new List<char>();
                string Keyword = textBox2.Text.ToUpper().ToString();
                char[] KeyWordChar = Keyword.ToCharArray();
                for(int i = 0; i < KeyWordChar.Length; i++)
                {
                    if (KeyWordChar[i] == 'J') KeyWordChar[i] = 'I';
                    if (Alphabet.Contains(KeyWordChar[i]))
                    {
                        KeyAlphabet.Add(KeyWordChar[i]);
                        Alphabet.Remove(KeyWordChar[i]);
                    }
                }
                foreach(char c in Alphabet) { KeyAlphabet.Add(c); }
                char11.Text = KeyAlphabet[0].ToString(); Letters.Add(new Box(KeyAlphabet[0], XNum[0], YNum[0]));
                char12.Text = KeyAlphabet[1].ToString(); Letters.Add(new Box(KeyAlphabet[1], XNum[0], YNum[1]));
                char13.Text = KeyAlphabet[2].ToString(); Letters.Add(new Box(KeyAlphabet[2], XNum[0], YNum[2]));
                char14.Text = KeyAlphabet[3].ToString(); Letters.Add(new Box(KeyAlphabet[3], XNum[0], YNum[3]));
                char15.Text = KeyAlphabet[4].ToString(); Letters.Add(new Box(KeyAlphabet[4], XNum[0], YNum[4]));
                char21.Text = KeyAlphabet[5].ToString(); Letters.Add(new Box(KeyAlphabet[5], XNum[1], YNum[0]));
                char22.Text = KeyAlphabet[6].ToString(); Letters.Add(new Box(KeyAlphabet[6], XNum[1], YNum[1]));
                char23.Text = KeyAlphabet[7].ToString(); Letters.Add(new Box(KeyAlphabet[7], XNum[1], YNum[2]));
                char24.Text = KeyAlphabet[8].ToString(); Letters.Add(new Box(KeyAlphabet[8], XNum[1], YNum[3]));
                char25.Text = KeyAlphabet[9].ToString(); Letters.Add(new Box(KeyAlphabet[9], XNum[1], YNum[4]));
                char31.Text = KeyAlphabet[10].ToString(); Letters.Add(new Box(KeyAlphabet[10], XNum[2], YNum[0]));
                char32.Text = KeyAlphabet[11].ToString(); Letters.Add(new Box(KeyAlphabet[11], XNum[2], YNum[1]));
                char33.Text = KeyAlphabet[12].ToString(); Letters.Add(new Box(KeyAlphabet[12], XNum[2], YNum[2]));
                char34.Text = KeyAlphabet[13].ToString(); Letters.Add(new Box(KeyAlphabet[13], XNum[2], YNum[3]));
                char35.Text = KeyAlphabet[14].ToString(); Letters.Add(new Box(KeyAlphabet[14], XNum[2], YNum[4]));
                char41.Text = KeyAlphabet[15].ToString(); Letters.Add(new Box(KeyAlphabet[15], XNum[3], YNum[0]));
                char42.Text = KeyAlphabet[16].ToString(); Letters.Add(new Box(KeyAlphabet[16], XNum[3], YNum[1]));
                char43.Text = KeyAlphabet[17].ToString(); Letters.Add(new Box(KeyAlphabet[17], XNum[3], YNum[2]));
                char44.Text = KeyAlphabet[18].ToString(); Letters.Add(new Box(KeyAlphabet[18], XNum[3], YNum[3]));
                char45.Text = KeyAlphabet[19].ToString(); Letters.Add(new Box(KeyAlphabet[19], XNum[3], YNum[4]));
                char51.Text = KeyAlphabet[20].ToString(); Letters.Add(new Box(KeyAlphabet[20], XNum[4], YNum[0]));
                char52.Text = KeyAlphabet[21].ToString(); Letters.Add(new Box(KeyAlphabet[21], XNum[4], YNum[1]));
                char53.Text = KeyAlphabet[22].ToString(); Letters.Add(new Box(KeyAlphabet[22], XNum[4], YNum[2]));
                char54.Text = KeyAlphabet[23].ToString(); Letters.Add(new Box(KeyAlphabet[23], XNum[4], YNum[3]));
                char55.Text = KeyAlphabet[24].ToString(); Letters.Add(new Box(KeyAlphabet[24], XNum[4], YNum[4]));
            }
            else
            {
                MessageBox.Show("Need a word!");
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            if(Letters == null)
            {
                MessageBox.Show("Need a key!");
                return;
            }
            if (textBox1.Text.Length > 1)
            {
                List<char> ClearText = new List<char>();
                List<int> CypherCode = new List<int>();
                char[] TextChar = textBox1.Text.ToUpper().ToCharArray();
                foreach(char c in TextChar)
                {
                    if (c >= 65 && c <= 90)
                    {
                        ClearText.Add(c);
                    }
                }
                foreach(char c in ClearText)
                {
                    int[] Pos = new int[2];
                    if (c == 74) { Pos = GetPos('I'); }
                    else { Pos = GetPos(c); }
                    CypherCode.Add(Pos[0]);
                }
                foreach (char c in ClearText)
                {
                    int[] Pos = new int[2];
                    if (c == 74) { Pos = GetPos('I'); }
                    else { Pos = GetPos(c); }
                    CypherCode.Add(Pos[1]);
                }
                List<char> CypherText = new List<char>();
                for(int i = 0; i < CypherCode.Count; i += 2)
                {
                    char Character = GetChar(CypherCode[i], CypherCode[i+1]);
                    CypherText.Add(Character);
                }
                foreach(char c in CypherText) { textBox3.Text += c; }
            }
            else
            {
                MessageBox.Show("Load clear text!");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked) { textBox1.Clear(); }
            else if(radioButton2.Checked) { textBox3.Clear(); }
            else
            {
                MessageBox.Show("Select an option!");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked) {
                textBox1.Clear();
                openFileDialog1.ShowDialog();
                string path = openFileDialog1.FileName;
                StreamReader Outro = new StreamReader(path);
                do
                {
                    textBox1.Text += Outro.ReadLine();
                } while (Outro.ReadLine() != null);
                Outro.Close();
            }
            else if (radioButton2.Checked)
            {
                textBox3.Clear();
                openFileDialog1.ShowDialog();
                string path = openFileDialog1.FileName;
                StreamReader Outro = new StreamReader(path);
                do
                {
                    textBox3.Text += Outro.ReadLine();
                } while (Outro.ReadLine() != null);
                Outro.Close();
            }
            else
            {
                MessageBox.Show("Select an option!");
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            if (Letters == null)
            {
                MessageBox.Show("Need a key!");
                return;
            }
            if (textBox3.Text.Length > 1)
            {
                List<char> ClearText = new List<char>();
                List<int> CypherCode = new List<int>();
                char[] TextChar = textBox3.Text.ToUpper().ToCharArray();
                foreach (char c in TextChar)
                {
                    if (c >= 65 && c <= 90) { ClearText.Add(c); }
                }
                foreach (char c in ClearText)
                {
                    int[] Pos = new int[2];
                    if (c == 74) { Pos = GetPos('I'); }
                    else { Pos = GetPos(c); }
                    CypherCode.Add(Pos[0]);
                    CypherCode.Add(Pos[1]);
                }
                int TextLength = CypherCode.Count/2;
                List<char> CypherText = new List<char>();
                for (int i = 0; i < TextLength; i++)
                {
                    char Character = GetChar(CypherCode[i], CypherCode[i + TextLength]);
                    CypherText.Add(Character);
                }
                foreach (char c in CypherText) { textBox1.Text += c; }
            }
            else
            {
                MessageBox.Show("Load cipher text!");
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Length > 0)
            {
                folderBrowserDialog1.ShowDialog();
                string path = folderBrowserDialog1.SelectedPath + "\\" + textBox4.Text + ".txt";
                StreamWriter Intro = new StreamWriter(path);
                if (radioButton1.Checked) { Intro.Write(textBox1.Text); }
                else if (radioButton2.Checked) { Intro.Write(textBox3.Text); }
                else { MessageBox.Show("Select an option!"); }
                Intro.Close();
            }
            else
            {
                MessageBox.Show("Load file name!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }

    public class Box
    {
        public char Character;
        int Xpos;
        int Ypos;

        public Box(char c, int x, int y)
        {
            Character = c;
            Xpos = x;
            Ypos = y;
        }

        public int getX() { return Xpos; }
        public int getY() { return Ypos; }
    }
}
