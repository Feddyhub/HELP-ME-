using System;
using System.Linq;
using System.Windows.Forms;

namespace Carkifelek
{
    public partial class Form1 : Form
    {
        string[] autoinput = { "b", "c", "d", "y", "z", "i" };
        string[] input = new string[4];
        string[] data = { "NAMAGLUPLUK", "klavye", "icardi", "holokost", "hayaletsevgilim", "Tutusturtusumuzunmus" };
        string[] vowels = { "a", "e", "o", "u" };

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Temizleme
            Array.Clear(input, 0, input.Length);

            Random random = new Random();
            int a = 0;
            bool[] flags = new bool[4];

            // TextBox'lardaki harfleri kontrol etme
            for (int i = 0; i < 4; i++)
            {
                TextBox textBox = Controls.Find("textBox" + (i + 1), true).FirstOrDefault() as TextBox;
                if (textBox == null)
                    continue;

                if (textBox.Text.Length != 1)
                {
                    MessageBox.Show($"Lütfen 1 harf giriniz. HATA ({i + 1}): {textBox.Text}");
                }
                else
                {
                    while (!flags[i] && a < vowels.Length)
                    {
                        if (textBox.Text == vowels[a])
                        {
                            flags[i] = true;
                        }
                        else
                        {
                            a++;
                            input[i] = textBox.Text;
                        }
                    }

                    if (flags[i])
                    {
                        MessageBox.Show($"Lütfen geçerli sessiz harf giriniz {i + 1}: ");
                    }
                    else
                    {
                        MessageBox.Show($"Başarılı ({i + 1}) : ");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            string randomData = data[random.Next(data.Length)];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string message = string.Join("", input);
            MessageBox.Show(message);
        }
    }
}
