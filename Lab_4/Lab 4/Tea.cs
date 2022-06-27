namespace Lab_4
{
    public class Tea : IHotDrink
    {
        public Tea()
        {
            Format = 3;
        }
        public Tea(double Format, bool Sugar)
        {
            this.Format = Format;
            this.Sugar = Sugar;
        }
        public Tea(double Format, bool Sugar, bool WithLemon)
        {
            this.Format = Format;
            this.Sugar = Sugar;
            this.WithLemon = WithLemon;
        }
        public virtual double Price { get { return 2; } }
        public virtual string Color { get { return "Green"; } }
        public double Format { get; set; }
        public bool Sugar { get; set; }
        public bool WithLemon { get; set; }
    }
}

