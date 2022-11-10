/// <summary>
/// The 'Component' interface
/// </summary>
public interface Mobile
{
    string Make { get; }
    string Model { get; }
    double Price { get; }
}

/// <summary>
/// The 'ConcreteComponent' class
/// </summary>
public class IPhone : Mobile
{
    public string Make
    {
        get { return "IPhone"; }
    }

    public string Model
    {
        get { return "IPhone 14"; }
    }

    public double Price
    {
        get { return 100000; }
    }
}

/// <summary>
/// The 'Decorator' abstract class
/// </summary>
public abstract class MobileDecorator : Mobile
{
    private Mobile _mobile;

    public MobileDecorator(Mobile mobile)
    {
        _mobile = mobile;
    }

    public string Make
    {
        get { return _mobile.Make; }
    }

    public string Model
    {
        get { return _mobile.Model; }
    }

    public double Price
    {
        get { return _mobile.Price; }
    }

}

/// <summary>
/// The 'ConcreteDecorator' class
/// </summary>
public class SpecialOffer : MobileDecorator
{
    public SpecialOffer(Mobile mobile) : base(mobile) { }

    public int DiscountPercentage { get; set; }
    public string Offer { get; set; }

    public double Price
    {
        get
        {
            double price = base.Price;
            int percentage = 100 - DiscountPercentage;
            return Math.Round((price * percentage) / 100, 2);
        }
    }

}

/// <summary>
/// Decorator Pattern Demo
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        IPhone iPhone = new();

        Console.WriteLine("IPhone base price is : {0}", iPhone.Price);

        // Special offer
        SpecialOffer offer = new(iPhone)
        {
            DiscountPercentage = 25,
            Offer = "15 % discount"
        };

        Console.WriteLine("{1} @ Diwali Special Offer and new price is : {0} ", offer.Price, offer.Offer);

        Console.ReadKey();

    }
}