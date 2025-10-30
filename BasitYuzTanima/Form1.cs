using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
namespace BasitYuzTanima
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Gerekli dosyaların isimlerini belirle
            string resimYolu = "test.jpg";
            string modelYolu = "haarcascade_frontalface_default.xml";

            // 2. OpenCV'nin CascadeClassifier'ını (model yükleyici) oluştur
            //    ve eğitilmiş XML model dosyasını yükle.
            CascadeClassifier yuzBulucu = new CascadeClassifier(modelYolu);

            // 3. Test resmini diskten yükle
            //    'using' bloğu, iş bittiğinde resmi bellekten atar, bu iyi bir pratiktir.
            using (Mat resim = new Mat(resimYolu, ImreadModes.Color))
            {
                // 4. Resmi gri tona çevir.
                //    Haar cascade, renkli resimden çok gri tonlamalı resimde daha hızlı
                //    ve daha iyi çalışır.
                using (Mat griResim = new Mat())
                {
                    Cv2.CvtColor(resim, griResim, ColorConversionCodes.BGR2GRAY);

                    // 5. Yüzleri tespit et!
                    //    DetectMultiScale: "Farklı ölçeklerde (büyük/küçük) tespit et" demektir.
                    //    Bulduğu her yüz için bir dikdörtgen (Rect) döndürür.
                    Rect[] yuzler = yuzBulucu.DetectMultiScale(
                        image: griResim,
                        scaleFactor: 1.1,  // Resim ne kadar küçültülecek (daha hızlı ama daha az hassas)
                        minNeighbors: 3,   // Bir yüzü "yüz" saymak için kaç komşu dikdörtgen gerekli (kalite ayarı)
                        minSize: new OpenCvSharp.Size(30, 30) // Minimum yüz boyutu (30x30 pikselden küçükleri bulma)
                        );

                    // 6. Bulunan her yüzün etrafına bir dikdörtgen çiz
                    foreach (Rect yuz in yuzler)
                    {
                        // Ana resmin (renkli olanın) üzerine yeşil bir dikdörtgen çiz
                        Cv2.Rectangle(resim, yuz, Scalar.Green, 2); // 2: Çizgi kalınlığı
                    }
                }

                // 7. Sonucu (üzeri çizilmiş resmi) PictureBox'ta göster
                //    OpenCV'nin Mat formatını, PictureBox'ın anladığı Bitmap formatına çeviriyoruz.
                pictureBox1.Image = BitmapConverter.ToBitmap(resim);
            }
        }
    }
}
