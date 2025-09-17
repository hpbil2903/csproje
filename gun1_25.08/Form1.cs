using System.Windows.Forms;
using System.IO;

namespace gun1_25._08
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        // s�n�f bilgilerini girmek i�in alan olu�turur
        private void btnsinifekle_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.AutoSize = true; // boyutun otomatik ayarlanmas� i�in
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink; //boyutun k���lmesine de izin verir
            tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.AddRows; // sat�r eklenece�ini belirtir
            tableLayoutPanel1.Location = new Point(0, 0); // panel1'in sol �st k��esine hizalan�r


            string[] basliklar = { "�sim Soyisim", "B�l�m", "Devaml� m�?", "Ortalama" };
            tableLayoutPanel1.ColumnCount = basliklar.Length; // ba�l�k say�s� kadar s�tun tan�mla

            panel1.AutoScroll = true; // panelin kayd�rma �ubu�u g�stermesini sa�lar
            panel1.Size = new Size(600, 400); // Sabit bir boyut ver, �ok b�y�k olmas�n
            panel1.Controls.Clear(); // �nceki i�eri�i temizle
            panel1.Controls.Add(tableLayoutPanel1); // panel1'e tableLayoutPanel1'i ekle


            // Ba�l�k sat�r�
            tableLayoutPanel1.RowCount++; // ba�l�k sat�r� i�in bir sat�r ekle
            for (int i = 0; i < basliklar.Length; i++)
            {
                Label lbl = new Label(); // label olu�turulur 
                lbl.Text = basliklar[i]; // ba�l�k metni dizi indexsiyle atan�r
                tableLayoutPanel1.Controls.Add(lbl, i, 0);  // label tabloya eklenir
            }

            // ��renci sat�rlar�
            int adet = (int)numsinifmevcud.Value;
            for (int row = 1; row <= adet; row++) // adet say�s� kadar 
            {
                tableLayoutPanel1.RowCount++; // her ��renci i�in sat�r ekle 

                for (int hucre = 0; hucre < basliklar.Length; hucre++) // her s�tun i�in
                {
                    Control ctrl; // t�m ara�lar�n ana s�n�f�ndan bir nesne olu�turulur ctrl ismi de�i�ebilir 

                    if (basliklar[hucre] == "Devaml� m�?") // ba�l�k "Devaml� m�?" ise CheckBox olu�tur
                    {
                        ctrl = new CheckBox();
                        ((CheckBox)ctrl).Dock = DockStyle.None; // h�creyi doldurmas�n� engeller kutu olarak kalabilsin diye

                    }
                    else
                    {
                        ctrl = new TextBox(); // txt ekler
                        ctrl.Name = $"txt_{row}_{hucre}"; // isim sat�r ve h�crre noya g�re
                        ctrl.Dock = DockStyle.Fill; // h�creyi doldursun diye
                    }

                    tableLayoutPanel1.Controls.Add(ctrl, hucre, row); // control� tabloya ekler   

                }
            }



        }

        // Diziler tan�mland�
        string[] sinifisimleri = new string[15];
        int[] sinifmevcutlari = new int[15];

        // Dizideki bo� indeksleri takip etmek i�in saya�
        int sinifIndex = 0;

        // s�n�f bilgilerini dizilere ekler
        private void button1_Click(object sender, EventArgs e)
        {
            if (sinifIndex < sinifisimleri.Length) // dizide bo� yer varsa
            {
                // TextBox ve NumericUpDown'dan de�erleri al
                string sinifadi = txtsinifadi.Text;
                int sinifmevcut = (int)numsinifmevcud.Value;

                // Dizilere ekle
                sinifisimleri[sinifIndex] = sinifadi;
                sinifmevcutlari[sinifIndex] = sinifmevcut;

                // �ndeksi bir sonraki bo� yere kayd�r
                sinifIndex++;
            }
            else
            {
                MessageBox.Show("Maksimum s�n�f say�s�na ula��ld�.");
            }

            string[,] ogrenciBilgileri = new string[50, 4]; // 50 ��renci, 4 bilgi (isim, b�l�m, devaml�l�k, ortalama)
            foreach (Control ctrl in tableLayoutPanel1.Controls) // tableLayoutPanel1 i�indeki t�m kontrolleri dola�
            {
                if (ctrl is TextBox txt && txt.Name.StartsWith("txt_")) // txt ile ba�layan textboxlar� bul (textbox olduklar�n� anlamak i�in)
                {
                    string[] parcalar = txt.Name.Split('_'); // ismi indeklere ay�r ["txt", "1", "0"] �eklinde
                    int row = Convert.ToInt32(parcalar[1]); // sat�r numaras�n� al�r mesela 1
                    int col = Convert.ToInt32(parcalar[2]); // s�tun numaras�n� al�r mesela 0

                    // Art�k row ve col ile iki boyutlu dizide veri saklanabilri
                    ogrenciBilgileri[row, col] = txt.Text; // textbox i�eri�ini diziye atar
                }



            }

            // s�n�f ismi ve mevcut bilgileri i�in 
            string dosyaYolu = @"C:\Veriler\siniflar.txt"; // Dosya yolu 

            // Klas�r yoksa olu�tur
            string? klasorYolu = Path.GetDirectoryName(dosyaYolu); // klas�r yolunu al�r

            if (!string.IsNullOrEmpty(klasorYolu)) // klas�r yolu bo� de�ilse yani klas�r varsa
            {
                Directory.CreateDirectory(klasorYolu); // yoksa olu�turur varsa bir �ey yapmaz
            }


            // Yazma i�lemi
            using (StreamWriter sw = new StreamWriter(dosyaYolu)) // StreamWriter ile dosyaya yazma i�lemi yapar
            {
                for (int i = 0; i < sinifisimleri.Length; i++) // dizi uzunlu�u kadar d�ner
                {
                    sw.WriteLine($"{sinifisimleri[i]} - Mevcut: {sinifmevcutlari[i]}"); // s�n�f ad� ve mevcut bilgisini dosyaya yazar
                }
            }


            // s�n�ftaki ��rencilerin bilgilerini yazmak i�in
            string dosyayolu2 = @"C:\Bilgiler\siniflar2.txt"; // dosya yolu

            // Klas�r yoksa olu�tur
            string? klasorYolu2 = Path.GetDirectoryName(dosyayolu2);

            if (!string.IsNullOrEmpty(klasorYolu2)) // ayn� �ekilde 
            {
                Directory.CreateDirectory(klasorYolu2);
            }

            using (StreamWriter sw = new StreamWriter(dosyayolu2))
            {
                sw.WriteLine("Ad Soyad\tS�n�f\tOrtalama\tDevaml�l�k"); // ba�l�k sat�ur� eklenir

                for (int i = 0; i < ogrenciBilgileri.GetLength(0); i++) // sat�rlar kadar d�ner 
                {
                    // Sadece dolu sat�rlar� yaz
                    if (!string.IsNullOrWhiteSpace(ogrenciBilgileri[i, 0]))
                    {
                        string satir = $"{ogrenciBilgileri[i, 0]}\t{ogrenciBilgileri[i, 1]}\t{ogrenciBilgileri[i, 2]}\t{ogrenciBilgileri[i, 3]}";
                        sw.WriteLine(satir); // her bir sat�r�n i�erdi�i bilgileri yazar
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }
    }
}
    




