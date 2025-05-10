namespace CoffeeSell.ObjClass
{
    public class Ranking
    {
        public int Dong { get; set; }
        public int Bac { get; set; }
        public int Vang { get; set; }
        public int KiemCuong { get; set; }

        public Ranking() { }

        public Ranking(int dong, int bac, int vang, int kiemCuong)
        {
            Dong = dong;
            Bac = bac;
            Vang = vang;
            KiemCuong = kiemCuong;
        }
    }
}
