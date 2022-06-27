namespace Lab_4
{
    public class Puer : Tea
    {
        public Puer()
        {
            Format = 5;
        }
        public Puer(double Format, bool Sugar)
        {
            this.Format = Format;
            this.Sugar = Sugar;
        }
        public Puer(double Format, bool Sugar, bool WithLemon)
        {
            this.Format = Format;
            this.Sugar = Sugar;
            this.WithLemon = WithLemon;
        }
        public override double Price { get { return 10; } }
        public override string Color { get { return "Yellow"; } }
    }
}
