namespace Sube2.EntityApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Yeni bir Ogrenci oluşturulur
            //var ogr = new Ogrenci { Ad = "Ahmet", Soyad = "Mehmet", Numara = "456" };

            // Veritabanı bağlantısı oluşturulur
            //using (var ctx = new OkulDbContext())
            //{
            // Yeni öğrenci veritabanına eklenir
            //ctx.Ogrenciler.Add(ogr);

            // Değişiklikler veritabanına kaydedilir
            //int sonuc = ctx.SaveChanges();

            // Sonucun başarılı olup olmadığı kontrol edilir ve ekrana yazdırılır
            //Console.WriteLine(sonuc > 0 ? "Başarılı" : "Başarısız");
            //}

            // Veritabanından öğrenci bilgisi alınır
            //using (var ctx = new OkulDbContext())
            //{
            // İlgili ID'ye sahip öğrenci bulunur
            //var ogr = ctx.Ogrenciler.Find(1);

            // Eğer öğrenci bulunursa
            //if (ogr != null)
            //{
            // Öğrencinin numarası güncellenir
            //ogr.Numara = "789";

            // Değişiklikler veritabanına kaydedilir ve sonucu ekrana yazdırılır
            //Console.WriteLine(ctx.SaveChanges() > 0 ? "Güncelleme Başarılı" : "Başarısız!");
            //}
            // Eğer öğrenci bulunamazsa
            //else
            //{
            // "Öğrenci Bulunamadı!" mesajı ekrana yazdırılır
            //Console.WriteLine("Öğrenci Bulunamadı!");
            //}
            //}

            // Veritabanından öğrenci silinir
            //using (var ctx = new OkulDbContext())
            //{
            // İlgili ID'ye sahip öğrenci bulunur
            //var ogr = ctx.Ogrenciler.Find(1);

            // Eğer öğrenci bulunursa
            //if (ogr != null)
            //{
            // Öğrenci veritabanından silinir
            //ctx.Ogrenciler.Remove(ogr);

            // Değişiklikler veritabanına kaydedilir
            //ctx.SaveChanges();
            //}
            //}

            // Veritabanındaki tüm öğrenci bilgileri alınır ve ekrana yazdırılır
            //using (var ctx = new OkulDbContext())
            //{
            // Öğrenci tablosundaki tüm veriler alınır
            //var lst = ctx.Ogrenciler.ToList();

            // Alınan öğrenci bilgileri ekrana yazdırılır
            //foreach (var item in lst)
            //{
            // Öğrencinin adı ekrana yazdırılır
            //Console.WriteLine(item.Ad);
            //}
            //}
        }
    }
}
