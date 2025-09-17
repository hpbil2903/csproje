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


        // sýnýf bilgilerini girmek için alan oluþturur
        private void btnsinifekle_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.AutoSize = true; // boyutun otomatik ayarlanmasý için
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink; //boyutun küçülmesine de izin verir
            tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.AddRows; // satýr ekleneceðini belirtir
            tableLayoutPanel1.Location = new Point(0, 0); // panel1'in sol üst köþesine hizalanýr


            string[] basliklar = { "Ýsim Soyisim", "Bölüm", "Devamlý mý?", "Ortalama" };
            tableLayoutPanel1.ColumnCount = basliklar.Length; // baþlýk sayýsý kadar sütun tanýmla

            panel1.AutoScroll = true; // panelin kaydýrma çubuðu göstermesini saðlar
            panel1.Size = new Size(600, 400); // Sabit bir boyut ver, çok büyük olmasýn
            panel1.Controls.Clear(); // Önceki içeriði temizle
            panel1.Controls.Add(tableLayoutPanel1); // panel1'e tableLayoutPanel1'i ekle


            // Baþlýk satýrý
            tableLayoutPanel1.RowCount++; // baþlýk satýrý için bir satýr ekle
            for (int i = 0; i < basliklar.Length; i++)
            {
                Label lbl = new Label(); // label oluþturulur 
                lbl.Text = basliklar[i]; // baþlýk metni dizi indexsiyle atanýr
                tableLayoutPanel1.Controls.Add(lbl, i, 0);  // label tabloya eklenir
            }

            // Öðrenci satýrlarý
            int adet = (int)numsinifmevcud.Value;
            for (int row = 1; row <= adet; row++) // adet sayýsý kadar 
            {
                tableLayoutPanel1.RowCount++; // her öðrenci için satýr ekle 

                for (int hucre = 0; hucre < basliklar.Length; hucre++) // her sütun için
                {
                    Control ctrl; // tüm araçlarýn ana sýnýfýndan bir nesne oluþturulur ctrl ismi deðiþebilir 

                    if (basliklar[hucre] == "Devamlý mý?") // baþlýk "Devamlý mý?" ise CheckBox oluþtur
                    {
                        ctrl = new CheckBox();
                        ((CheckBox)ctrl).Dock = DockStyle.None; // hücreyi doldurmasýný engeller kutu olarak kalabilsin diye

                    }
                    else
                    {
                        ctrl = new TextBox(); // txt ekler
                        ctrl.Name = $"txt_{row}_{hucre}"; // isim satýr ve hücrre noya göre
                        ctrl.Dock = DockStyle.Fill; // hücreyi doldursun diye
                    }

                    tableLayoutPanel1.Controls.Add(ctrl, hucre, row); // controlü tabloya ekler   

                }
            }



        }

        // Diziler tanýmlandý
        string[] sinifisimleri = new string[15];
        int[] sinifmevcutlari = new int[15];

        // Dizideki boþ indeksleri takip etmek için sayaç
        int sinifIndex = 0;

        // sýnýf bilgilerini dizilere ekler
        private void button1_Click(object sender, EventArgs e)
        {
            if (sinifIndex < sinifisimleri.Length) // dizide boþ yer varsa
            {
                // TextBox ve NumericUpDown'dan deðerleri al
                string sinifadi = txtsinifadi.Text;
                int sinifmevcut = (int)numsinifmevcud.Value;

                // Dizilere ekle
                sinifisimleri[sinifIndex] = sinifadi;
                sinifmevcutlari[sinifIndex] = sinifmevcut;

                // Ýndeksi bir sonraki boþ yere kaydýr
                sinifIndex++;
            }
            else
            {
                MessageBox.Show("Maksimum sýnýf sayýsýna ulaþýldý.");
            }

            string[,] ogrenciBilgileri = new string[50, 4]; // 50 öðrenci, 4 bilgi (isim, bölüm, devamlýlýk, ortalama)
            foreach (Control ctrl in tableLayoutPanel1.Controls) // tableLayoutPanel1 içindeki tüm kontrolleri dolaþ
            {
                if (ctrl is TextBox txt && txt.Name.StartsWith("txt_")) // txt ile baþlayan textboxlarý bul (textbox olduklarýný anlamak için)
                {
                    string[] parcalar = txt.Name.Split('_'); // ismi indeklere ayýr ["txt", "1", "0"] þeklinde
                    int row = Convert.ToInt32(parcalar[1]); // satýr numarasýný alýr mesela 1
                    int col = Convert.ToInt32(parcalar[2]); // sütun numarasýný alýr mesela 0

                    // Artýk row ve col ile iki boyutlu dizide veri saklanabilri
                    ogrenciBilgileri[row, col] = txt.Text; // textbox içeriðini diziye atar
                }



            }

            // sýnýf ismi ve mevcut bilgileri için 
            string dosyaYolu = @"C:\Veriler\siniflar.txt"; // Dosya yolu 

            // Klasör yoksa oluþtur
            string? klasorYolu = Path.GetDirectoryName(dosyaYolu); // klasör yolunu alýr

            if (!string.IsNullOrEmpty(klasorYolu)) // klasör yolu boþ deðilse yani klasör varsa
            {
                Directory.CreateDirectory(klasorYolu); // yoksa oluþturur varsa bir þey yapmaz
            }


            // Yazma iþlemi
            using (StreamWriter sw = new StreamWriter(dosyaYolu)) // StreamWriter ile dosyaya yazma iþlemi yapar
            {
                for (int i = 0; i < sinifisimleri.Length; i++) // dizi uzunluðu kadar döner
                {
                    sw.WriteLine($"{sinifisimleri[i]} - Mevcut: {sinifmevcutlari[i]}"); // sýnýf adý ve mevcut bilgisini dosyaya yazar
                }
            }


            // sýnýftaki öðrencilerin bilgilerini yazmak için
            string dosyayolu2 = @"C:\Bilgiler\siniflar2.txt"; // dosya yolu

            // Klasör yoksa oluþtur
            string? klasorYolu2 = Path.GetDirectoryName(dosyayolu2);

            if (!string.IsNullOrEmpty(klasorYolu2)) // ayný þekilde 
            {
                Directory.CreateDirectory(klasorYolu2);
            }

            using (StreamWriter sw = new StreamWriter(dosyayolu2))
            {
                sw.WriteLine("Ad Soyad\tSýnýf\tOrtalama\tDevamlýlýk"); // baþlýk satýurý eklenir

                for (int i = 0; i < ogrenciBilgileri.GetLength(0); i++) // satýrlar kadar döner 
                {
                    // Sadece dolu satýrlarý yaz
                    if (!string.IsNullOrWhiteSpace(ogrenciBilgileri[i, 0]))
                    {
                        string satir = $"{ogrenciBilgileri[i, 0]}\t{ogrenciBilgileri[i, 1]}\t{ogrenciBilgileri[i, 2]}\t{ogrenciBilgileri[i, 3]}";
                        sw.WriteLine(satir); // her bir satýrýn içerdiði bilgileri yazar
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
    




