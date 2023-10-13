using System;
using System.Collections;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private bool temizle;
        private int i = 1;
        public ArrayList islemgecmisi = new ArrayList();
        public ArrayList data = new ArrayList();
        private bool karaislem2 = false;
        public Form1()
        {
            InitializeComponent();
            ButonKontrolcu();
        }
        private void ButonKontrolcu()
        {
            foreach (Control kontrol in Controls)
            {
                if (kontrol is Button button)
                {
                    button.Click += ButonaTiklandi;
                }
            }
        }
        private void ButonaTiklandi(object sender, EventArgs e)
        {
            this.ActiveControl = button15;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = button15;
        }
        private static double EvaluateExpression(string ifade)
        {
            DataTable table = new DataTable();
            table.Columns.Add("expression", typeof(string), ifade);
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            float sonuc = float.Parse((string)row["expression"]);
            return sonuc;
        }
        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                string ifade = textBox2.Text;
                if (ifade.Contains("√"))
                {
                    ifade = Regex.Replace(ifade, @"√\(([^)]*)\)", match =>
                    {
                        float deger = float.Parse(match.Groups[1].Value);
                        double karakok = Math.Sqrt(deger);
                        if (karaislem2 == false)
                        {
                            islemgecmisi.Add(i + "- " + ifade + ";");
                            karaislem2 = true;
                        }
                        return karakok.ToString();
                    });
                }
                if (ifade.Contains("^"))
                {
                    ifade = Regex.Replace(ifade, @"(\d+(\.\d+)?)\s*\^\s*(\d+(\.\d+)?)", match =>
                    {
                        float taban = float.Parse(match.Groups[1].Value);
                        float us = float.Parse(match.Groups[3].Value);
                        islemgecmisi.Add(i + "- " + ifade + ";");
                        return ((float)Math.Pow(taban, us)).ToString();
                    });
                } 
                double sonuc = EvaluateExpression(ifade);
                textBox1.Text = sonuc.ToString("#,##0.0");
                data.Add(sonuc);
                islemgecmisi.Add(i + "- " + ifade + " = " + sonuc + "\n ------------------ \n");
                i++;
                karaislem2 = false;
                temizle = true;
                textBox2.Text = "";
            }
            catch { MessageBox.Show("Tam sayı değeri giriniz veya fonksiyonu düzgün yazınız!"); }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (temizle == true)
            {
                textBox1.Text = "";
                temizle = false;
            }
            if (textBox1.Text == "0") textBox1.Text = "";
            textBox1.Text += "1";
            textBox2.Text += "1";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (temizle == true)
            {
                textBox1.Text = "";
                temizle = false;
            }
            if (textBox1.Text == "0") textBox1.Text = "";
            textBox1.Text += "2";
            textBox2.Text += "2";
        }
        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                temizle = true;
                textBox2.Text += "+";
            }
            catch
            {
                MessageBox.Show("Bir (sayı) değeri girmeden hesaplama yapamazsın!");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (temizle == true)
            {
                textBox1.Text = "";
                temizle = false;
            }
            if (textBox1.Text == "0") textBox1.Text = "";
            textBox1.Text += "3";
            textBox2.Text += "3";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (temizle == true)
            {
                textBox1.Text = "";
                temizle = false;
            }
            if (textBox1.Text == "0") textBox1.Text = "";
            textBox1.Text += "4";
            textBox2.Text += "4";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (temizle == true)
            {
                textBox1.Text = "";
                temizle = false;
            }
            if (textBox1.Text == "0") textBox1.Text = "";
            textBox1.Text += "5";
            textBox2.Text += "5";
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (temizle == true)
            {
                textBox1.Text = "";
                temizle = false;
            }
            if (textBox1.Text == "0") textBox1.Text = "";
            textBox1.Text += "6";
            textBox2.Text += "6";
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (temizle == true)
            {
                textBox1.Text = "";
                temizle = false;
            }
            if (textBox1.Text == "0") textBox1.Text = "";
            textBox1.Text += "7";
            textBox2.Text += "7";
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (temizle == true)
            {
                textBox1.Text = "";
                temizle = false;
            }
            if (textBox1.Text == "0") textBox1.Text = "";
            textBox1.Text += "8";
            textBox2.Text += "8";
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (temizle == true)
            {
                textBox1.Text = "";
                temizle = false;
            }
            if (textBox1.Text == "0") textBox1.Text = "";
            textBox1.Text += "9";
            textBox2.Text += "9";
        }
        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                temizle = true;
                textBox2.Text += "-";
            }
            catch
            {
                MessageBox.Show("Bir (sayı) değeri girmeden hesaplama yapamazsın!");
            }
        }
        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                temizle = true;
                textBox2.Text += "*";
            }
            catch
            {
                MessageBox.Show("Bir (sayı) değeri girmeden hesaplama yapamazsın!");
            }
        }
        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                temizle = true;
                textBox2.Text += "/";
            }
            catch
            {
                MessageBox.Show("Bir (sayı) değeri girmeden hesaplama yapamazsın!");
            }
        }
        private void button16_Click(object sender, EventArgs e)
        {
            temizle = false;
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                temizle = true;
                textBox2.Text += "√";
            }
            catch
            {
                MessageBox.Show("Bir (sayı) değeri girmeden hesaplama yapamazsın!");
            }
        }
        private void button18_Click(object sender, EventArgs e)
        {
            if (temizle == true)
            {
                textBox1.Text = "";
                temizle = false;
            }
            if (textBox1.Text == "0") textBox1.Text = "";
            textBox1.Text += "(";
            textBox2.Text += "(";
        }
        private void button19_Click(object sender, EventArgs e)
        {
            if (temizle == true)
            {
                textBox1.Text = "";
                temizle = false;
            }
            if (textBox1.Text == "0") textBox1.Text = "";
            textBox1.Text += ")";
            textBox2.Text += ")";
        }
        private void button20_Click(object sender, EventArgs e)
        {
            String mesaj = "";
            foreach (var islemler in islemgecmisi)
            {
                mesaj += islemler.ToString() + "\n";
            }
            MessageBox.Show(mesaj, "Son İşlemler");
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Add)
            {
                button11.PerformClick();
            }
            if (e.KeyCode == Keys.Subtract)
            {
                button12.PerformClick();
            }
            if (e.KeyCode == Keys.Multiply)
            {
                button13.PerformClick();
            }
            if (e.KeyCode == Keys.Divide)
            {
                button14.PerformClick();
            }
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    button15.PerformClick();
                }
                catch { MessageBox.Show("Bir değer girmeden hesaplama yapamazsın!"); }
            }
            if (e.KeyCode == Keys.D1)
            {
                button1.PerformClick();
            }
            if (e.KeyCode == Keys.D2)
            {
                button2.PerformClick();
            }
            if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.D3)
            {
                e.Handled = true;
                button21.PerformClick();
            }
            else if (e.KeyCode == Keys.D3)
            {
                button3.PerformClick();
            }
            if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.D4)
            {
                e.Handled = true;
                button11.PerformClick();
            }
            else if (e.KeyCode == Keys.D4)
            {
                e.Handled = true;
                button4.PerformClick();
            }
            if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.D5)
            {
                e.Handled = true; 
                button23.PerformClick();
            }
            else if (e.KeyCode == Keys.D5)
            {
                button5.PerformClick();
            }
            if (e.KeyCode == Keys.D6)
            {
                button6.PerformClick();
            }
            if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.D7)
            {
                e.Handled = true; 
                button14.PerformClick();
            }
            else if (e.KeyCode == Keys.D7)
            {
                button7.PerformClick();
            }
            if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.D8)
            {
                e.Handled = true;
                button18.PerformClick();
            }
            else if (e.KeyCode == Keys.D8)
            {
                button8.PerformClick();
            }
            if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.D9)
            {
                e.Handled = true;
                button19.PerformClick();
            }
            else if (e.KeyCode == Keys.D9)
            {
                button9.PerformClick();
            }
            if (e.KeyCode == Keys.D0)
            {
                button10.PerformClick();
            }
            //NumPad kısmı 
            if (e.KeyCode == Keys.NumPad1)
            {
                button1.PerformClick();
            }
            if (e.KeyCode == Keys.NumPad2)
            {
                button2.PerformClick();
            }
            if (e.KeyCode == Keys.NumPad3)
            {
                button3.PerformClick();
            }
            if (e.KeyCode == Keys.NumPad4)
            {
                button4.PerformClick();
            }
            if (e.KeyCode == Keys.NumPad5)
            {
                button5.PerformClick();
            }
            if (e.KeyCode == Keys.NumPad6)
            {
                button6.PerformClick();
            }
            if (e.KeyCode == Keys.NumPad7)
            {
                button7.PerformClick();
            }
            if (e.KeyCode == Keys.NumPad8)
            {
                button8.PerformClick();
            }
            if (e.KeyCode == Keys.NumPad9)
            {
                button9.PerformClick();
            }
            if (e.KeyCode == Keys.NumPad0)
            {
                button10.PerformClick();
            }
            if (e.KeyCode == Keys.Back)
            {
                temizle = false;
                if (textBox1.Text.Length > 0)
                {
                    textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                }
                if (textBox2.Text.Length > 0)
                {
                    textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length - 1);
                }
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (temizle == true)
            {
                textBox1.Text = "";
                temizle = false;
            }
            if (textBox1.Text == "0") textBox1.Text = "";
            textBox1.Text += "0";
            textBox2.Text += "0";
        }
        private void button22_Click(object sender, EventArgs e)
        {
            temizle = false;
            if (textBox1.Text.Length > 0)
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
            if (textBox2.Text.Length > 0)
            {
                textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length - 1);
            }
        }
        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                temizle = true;
                textBox2.Text += "^";
            }
            catch
            {
                MessageBox.Show("Bir (sayı) değeri girmeden hesaplama yapamazsın!");
            }
        }
        private void button24_Click(object sender, EventArgs e)
        {
            try { 
            temizle = true;
            textBox1.Text = "";
            textBox2.Text = "";
            double t = 0;
            foreach (double islemler in data)
            {
                t += islemler;
            }
                textBox2.Text += t.ToString();
                textBox1.Text += t.ToString(); ;
        } catch { MessageBox.Show("Mevcut değer yok!"); }
}
        private void button25_Click(object sender, EventArgs e)
        {
            try
            {
                temizle = true;
                textBox1.Text = "";
                textBox2.Text = "";
                double t = 0;

                // ArrayList'teki diğer sayıları çıkarın
                for (int i = 0; i < data.Count; i++)
                {
                    t -= (double)data[i];
                }
                textBox2.Text += t.ToString();
                textBox1.Text += t.ToString();
            } catch { MessageBox.Show("Mevcut değer yok!"); }
        }
        private void button23_Click(object sender, EventArgs e)
        {
            try
            {
                temizle = true;
                textBox2.Text += "/100";
            }
            catch
            {
                MessageBox.Show("Bir (sayı) değeri girmeden hesaplama yapamazsın!");
            }
        }
    }
}
