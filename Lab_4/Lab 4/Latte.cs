namespace Lab_4
{
    public class Latte : Coffee
    {
        public Latte(double Format, bool Sugar)
        {
            this.Format = Format;
            this.Sugar = Sugar;
        }
        public Latte(double Format, bool Sugar, bool WithMilk)
        {
            this.Format = Format;
            this.Sugar = Sugar;
            this.WithMilk = WithMilk;
        }
        public override double Price
        {
            get { return 4; }
        }
        public override string Color
        {
            get { return "Light brown"; }
        }
    }
}
