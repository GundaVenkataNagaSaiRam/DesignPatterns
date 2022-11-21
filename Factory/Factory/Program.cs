/*In Factory pattern, we create the object without exposing the creation logic. 
 * In this pattern, an interface is used for creating an object, but let subclass decide which class to instantiate. 
 * The creation of object is done when it is required. 
 * The Factory method allows a class later instantiation to subclasses.*/
public interface IVehicleFactory
    {
        void Drive(int miles);
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    public class Scooter : IVehicleFactory
    {
        public void Drive(int miles)
        {
            Console.WriteLine("Drive the Scooter : " + miles.ToString() + "km");
        }
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    public class Bike : IVehicleFactory
    {
        public void Drive(int miles)
        {
            Console.WriteLine("Drive the Bike : " + miles.ToString() + "km");
        }
    }

    /// <summary>
    /// The Creator Abstract Class
    /// </summary>
    public abstract class VehicleFactory
    {
        public abstract IVehicleFactory GetVehicle(string Vehicle);

    }

    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    public class ConcreteVehicleFactory : VehicleFactory
    {
        public override IVehicleFactory GetVehicle(string Vehicle)
        {
            switch (Vehicle)
            {
                case "Scooter":
                    return new Scooter();
                case "Bike":
                    return new Bike();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Vehicle));
            }
        }

    }

    /// <summary>
    /// Factory Pattern Demo
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            VehicleFactory factory = new ConcreteVehicleFactory();

            IVehicleFactory scooter = factory.GetVehicle("Scooter");
            scooter.Drive(10);

            IVehicleFactory bike = factory.GetVehicle("Bike");
            bike.Drive(20);

            Console.ReadKey();

        }
    }