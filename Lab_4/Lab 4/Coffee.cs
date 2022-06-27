namespace Lab_4
{
    public class Coffee : IHotDrink
    {
        public Coffee()
        {
            Format = 1;
        }
        public Coffee(double Format, bool Sugar)
        {
            this.Format = Format;
            this.Sugar = Sugar;
        }
        public Coffee(double Format, bool Sugar, bool WithMilk)
        {
            this.Format = Format;
            this.Sugar = Sugar;
            this.WithMilk = WithMilk;
        }
        public virtual double Price
        {
            get { return 5; }
        }
        public virtual string Color
        {
            get { return "Dark brown"; }
        }
        public double Format { get; set; }
        public bool Sugar { get; set; }
        public bool WithMilk { get; set; }
    }
}
