namespace CoffeeSell.ObjClass
{
    public class Ranking
    {
        public int Dong { get; set; }
        public int Bac { get; set; }
        public int Vang { get; set; }
        public int KimCuong { get; set; }

        public Ranking() { }

        public Ranking(int dong, int bac, int vang, int kimCuong)
        {
            Dong = dong;
            Bac = bac;
            Vang = vang;
            KimCuong = kimCuong;
        }
    }
}
