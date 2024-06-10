namespace Sube2.HelloMvc.Models
{
    public class Ogrenci:Object
    {
        public int OgrenciId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Numara { get; set; }

        public ICollection<Ders> Dersler { get; set; }
    }
}
