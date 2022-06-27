namespace Lab_4
{
    public interface IHotDrink
    {
        double Format { get; set; }
        double Price { get; }
        string Color { get; }
        bool Sugar { get; set; }
    }
}
