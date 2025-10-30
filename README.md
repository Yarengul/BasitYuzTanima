# BasitYuzTanima
C# ve OpenCV ile Basit Yüz Tanıma Projesi
Bu proje, bir okul ödevi veya OpenCV kütüphanesine giriş yapmak amacıyla C# kullanılarak geliştirilmiş bir Windows Forms uygulamasıdır.

Projenin temel amacı, bir fotoğraftaki insan yüzlerini tespit etmek ve bulunan yüzleri bir dikdörtgen içine alarak kullanıcıya göstermektir.

Projenin Amacı
Bu projeyi, Nesne Tabanlı Programlama veya Görüntü İşleme dersleri kapsamında C# dilini ve harici kütüphaneleri nasıl kullanacağımı öğrenmek için yaptım. Özellikle OpenCV gibi güçlü bir görüntü işleme kütüphanesinin C#'ta nasıl çalıştığını görmek ve temel bir "nesne tanıma" (bu örnekte yüz tanıma) algoritmasını uygulamak istedim.

Kullanılan Teknolojiler
Platform: .NET Framework (Windows Forms)

Dil: C#

Ana Kütüphane: OpenCvSharp4 (OpenCV için bir C# sarmalayıcısı)

Yöntem: Haar Cascade Sınıflandırıcıları

Kurulum ve Çalıştırma
Projeyi kendi bilgisayarınızda çalıştırmak için aşağıdaki adımları izlemeniz gerekmektedir:

Projeyi Klonlayın veya İndirin: Bu repoyu bilgisayarınıza indirin ve Visual Studio ile .sln dosyasını açın.

Gerekli NuGet Paketlerini Yükleyin: Proje açıldığında, Visual Studio'nun NuGet Paket Yöneticisi'ni kullanarak aşağıdaki paketlerin kurulu olduğundan emin olun. (Tools -> NuGet Package Manager -> Manage NuGet Packages for Solution...):

OpenCvSharp4.Windows

OpenCvSharp4.Extensions (Bu paket, BitmapConverter gibi yardımcı fonksiyonlar için gereklidir).

Model Dosyasını Hazırlayın: Bu proje, yüzleri tanımak için haarcascade_frontalface_default.xml adlı eğitilmiş bir model dosyasına ihtiyaç duyar.

Bu dosyayı OpenCV'nin resmi GitHub reposundan indirebilirsiniz.

İndirdiğiniz .xml dosyasını projenin ana dizinine ekleyin.

ÖNEMLİ: Dosyayı Visual Studio'da seçin ve "Properties" (Özellikler) penceresinden "Copy to Output Directory" ayarını "Copy if newer" olarak değiştirin. Bu, program çalıştığında dosyanın bulunabilmesi için kritiktir.

Test Fotoğrafı Ekleyin:

Kod, varsayılan olarak test.jpg adlı bir fotoğrafı arar.

İçinde yüzlerin bulunduğu bir fotoğrafı test.jpg olarak adlandırın ve projeye ekleyin.

Tıpkı .xml dosyası gibi, bu dosyanın da "Copy to Output Directory" ayarını "Copy if newer" olarak değiştirin.

Programı Başlatın: Visual Studio'da F5 tuşuna basarak veya "Start" butonu ile projeyi çalıştırın.

Program Nasıl Çalışır?
"Yüzleri Bul" butonuna tıklandığında kod tetiklenir.

haarcascade_frontalface_default.xml modeli CascadeClassifier sınıfı kullanılarak hafızaya yüklenir.

test.jpg dosyası Mat nesnesi olarak okunur.

Daha hızlı ve stabil bir tespit yapabilmek için resim Cv2.CvtColor komutuyla gri tonlamalı (grayscale) hale getirilir.

DetectMultiScale fonksiyonu, gri resim üzerinde çalışarak yüzlerin koordinatlarını (Rect) bir dizi olarak döndürür.

foreach döngüsü ile bulunan her yüzün koordinatına, orijinal renkli resim üzerine Cv2.Rectangle komutuyla yeşil bir dikdörtgen çizilir.

Son olarak, üzerinde dikdörtgenler çizilmiş olan Mat nesnesi, BitmapConverter.ToBitmap komutuyla PictureBox'ın anlayacağı Bitmap formatına dönüştürülür ve ekranda gösterilir.
