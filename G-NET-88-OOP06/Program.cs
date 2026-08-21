using System;

namespace G_NET_88_OOP05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part 01 — Theoretical Questions

            #region Q1 - Object Copying
            // Q1 Object Copying
            // a) What happens when you assign one object variable to another object variable?
            //    When you assign one object variable to another (e.g. shipment2 = shipment1), only the memory reference (address)
            //    pointing to the object on the heap is copied. Both variables now refer to the exact same object in memory.
            //
            // b) Does assigning one object to another create a new object? Explain.
            //    No. Assigning one object variable to another does NOT create a new object on the heap.
            //    It simply creates a second reference pointing to the existing object.
            //
            // c) What is the difference between copying an object and copying its reference?
            //    - Copying a reference duplicates the memory address pointing to an existing object. Modifications made via either reference affect the same instance.
            //    - Copying an object creates a brand new object in heap memory with duplicated field values, resulting in an independent instance.
            #endregion

            #region Q2 - Shallow Copy vs Deep Copy
            // Q2 Shallow Copy vs Deep Copy
            // a) What is a Shallow Copy?
            //    A Shallow Copy creates a new instance of the object and copies all fields as-is. Value types are copied by value,
            //    while reference types copy the memory reference (pointing to the original referenced object).
            //
            // b) What is a Deep Copy?
            //    A Deep Copy creates a new instance of the object and recursively creates new duplicates of all referenced objects,
            //    yielding a completely independent object graph.
            //
            // c) What happens to reference-type members when a Shallow Copy is created?
            //    Reference-type members continue to point to the exact same objects in memory as the original object.
            //    Modifying a reference-type property in the copy affects the original object.
            //
            // d) What happens to reference-type members when a Deep Copy is created?
            //    Reference-type members are duplicated into brand-new objects.
            //    Modifying a reference-type property in the deep copy does NOT affect the original object.
            //
            // e) Give one situation where Deep Copy would be safer than Shallow Copy.
            //    When an object contains mutable reference-type fields (e.g. DeliveryAddress, List<Item>) and you need to clone
            //    the object so it can be modified independently without inadvertently changing or corrupting the original object's state.
            #endregion

            #region Q3 - Static Members
            // Q3 Static Members
            // a) What is a static field, and how is it different from an instance field?
            //    A static field belongs to the class itself rather than any instance. It is shared across all objects of the class
            //    and initialized once in memory. An instance field belongs to a specific object instance, and each object gets its own copy.
            //
            // b) What is a static method? Can a static method directly access instance members?
            //    A static method is associated with the class itself and can be called without creating an instance.
            //    No, a static method CANNOT directly access instance members because it operates without a 'this' pointer to a specific instance.
            //
            // c) What is a static constructor, and when is it executed?
            //    A static constructor is a parameterless constructor used to initialize static data.
            //    It is executed automatically by the CLR before the first instance is created or any static member is accessed.
            //
            // d) What is a static class? Can you create an object from a static class?
            //    A static class is declared with the 'static' keyword and contains only static members.
            //    No, you cannot instantiate ('new') a static class.
            #endregion

            #region Q4 - Extension Methods
            // Q4 Extension Methods
            // a) What is an Extension Method?
            //    An extension method allows adding new methods to existing types without modifying their source code, inheriting, or recompiling them.
            //
            // b) What keyword must be used in the first parameter of an extension method?
            //    The 'this' keyword must precede the first parameter type.
            //
            // c) Where must an extension method be declared?
            //    Inside a top-level static class.
            //
            // d) Can an extension method access private members of the class it extends?
            //    No. Extension methods are external to the target class and can only access its public or internal members.
            #endregion

            #region Q5 - Partial Classes and Partial Methods
            // Q5 Partial Classes and Partial Methods
            // a) What is a Partial Class?
            //    A partial class allows the definition of a class to be split across multiple files using the 'partial' keyword.
            //    The C# compiler merges them into a single class at compile time.
            //
            // b) Why would a developer split one class into multiple files?
            //    To separate concerns (e.g. core properties vs tracking vs auto-generated code), improve maintainability in large projects,
            //    and enable multiple developers to work on different parts simultaneously.
            //
            // c) What is a Partial Method?
            //    A partial method is declared (signature only) in one partial class file and optionally implemented in another.
            //
            // d) What happens if a declared partial method has no implementation?
            //    The C# compiler completely removes the method declaration, signature, and all call sites at compile time with zero performance penalty.
            #endregion

            #endregion

            #region Part 02 — Practical Main() Checklist Execution

            // 1. System Title Banner
            DeliveryUtilities.PrintSystemTitle();
            Console.WriteLine();

            // Touch Shipment static member to execute static constructor
            _ = Shipment.GetTotalShipmentsCreated();
            Console.WriteLine();

            // 2. Creating Shipments (Static constructor has already initialized)
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Creating Shipments...");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine();

            StandardShipment s1 = new StandardShipment("SH001", "Laptop", 3, 80, new DeliveryAddress("Cairo", "Nasr City", 10));
            s1.Status = "In Transit";
            Console.WriteLine("Standard Shipment Created");

            ExpressShipment s2 = new ExpressShipment("SH002", "Mobile Phone", 2, 60, new DeliveryAddress("Cairo", "Dokki", 5), 30);
            s2.Status = "Out For Delivery";
            Console.WriteLine("Express Shipment Created");

            InternationalShipment s3 = new InternationalShipment("SH003", "Television", 8, 120, new DeliveryAddress("Cairo", "Center", 1), "Germany", 100);
            s3.Status = "Delivered";
            Console.WriteLine("International Shipment Created");

            Console.WriteLine();
            Console.WriteLine($"Total Shipments Created : {Shipment.GetTotalShipmentsCreated()}");

            // 3. Object Copying Demonstration
            Console.WriteLine();
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Object Copying");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine();

            Shipment shipment1 = s1;
            Shipment shipment2 = shipment1;

            Console.WriteLine($"Original Shipment  : {shipment1.TrackingCode}");
            Console.WriteLine($"Assigned Shipment  : {shipment2.TrackingCode}");
            Console.WriteLine();
            Console.WriteLine($"Same Object : {ReferenceEquals(shipment1, shipment2)}");

            // 4. Shallow Copy Demonstration
            Console.WriteLine();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Shallow Copy");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine();

            Shipment shallowOriginal = s1;
            Shipment shallowCopy = shallowOriginal.ShallowCopy();

            Console.WriteLine($"Original Shipment Address : {shallowOriginal.Destination.City}");
            Console.WriteLine($"Copied Shipment Address   : {shallowCopy.Destination.City}");
            Console.WriteLine();
            Console.WriteLine("Changing copied shipment address...");
            shallowCopy.Destination.City = "Giza";
            Console.WriteLine();
            Console.WriteLine($"Original Shipment Address : {shallowOriginal.Destination.City}");
            Console.WriteLine($"Copied Shipment Address   : {shallowCopy.Destination.City}");
            Console.WriteLine();
            Console.WriteLine($"Same DeliveryAddress Object : {ReferenceEquals(shallowOriginal.Destination, shallowCopy.Destination)}");

            // Reset address back for subsequent demonstrations
            shallowOriginal.Destination.City = "Cairo";

            // 5. Deep Copy Demonstration
            Console.WriteLine();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Deep Copy");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine();

            Shipment deepOriginal = s1;
            Shipment deepCopy = deepOriginal.DeepCopy();

            Console.WriteLine($"Original Shipment Address : {deepOriginal.Destination.City}");
            Console.WriteLine($"Copied Shipment Address   : {deepCopy.Destination.City}");
            Console.WriteLine();
            Console.WriteLine("Changing copied shipment address...");
            deepCopy.Destination.City = "Giza";
            Console.WriteLine();
            Console.WriteLine($"Original Shipment Address : {deepOriginal.Destination.City}");
            Console.WriteLine($"Copied Shipment Address   : {deepCopy.Destination.City}");
            Console.WriteLine();
            Console.WriteLine($"Same DeliveryAddress Object : {ReferenceEquals(deepOriginal.Destination, deepCopy.Destination)}");

            // 6. Extension Methods Demonstration
            Console.WriteLine();
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Extension Methods");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine();

            Console.WriteLine(s1.GetSummary());
            Console.WriteLine(s2.GetSummary());
            Console.WriteLine(s3.GetSummary());
            Console.WriteLine();

            Console.WriteLine($"SH001 Is Delivered : {s1.IsDelivered()}");
            Console.WriteLine($"SH003 Is Delivered : {s3.IsDelivered()}");

            // 7. Tracking Status Demonstration
            Console.WriteLine();
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Tracking Status");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine();

            s1.UpdateTrackingStatus("Out For Delivery");

            // 8. Static Utilities Demonstration
            Console.WriteLine();
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Static Utilities");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine();

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Delivery Center");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine();

            Console.WriteLine($"Total Shipments Created : {Shipment.GetTotalShipmentsCreated()}");

            // 9. Partial Method Demonstration
            Console.WriteLine();
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Partial Method");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine();

            s1.UpdateTrackingStatus("Delivered");

            // 10. Existing Assignment 04 Functionality Preserved
            Console.WriteLine();
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Assignment 04 System Operations");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine();

            DeliveryCenter center = new DeliveryCenter("Main Center");
            center.AddShipment(s1);
            center.AddShipment(s2);
            center.AddShipment(s3);
            center.PrintAllShipments();

            // 11. Assignment Completed Banner
            Console.WriteLine();
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Assignment Completed");
            DeliveryUtilities.PrintSeparator();

            #endregion
        }
    }
}
