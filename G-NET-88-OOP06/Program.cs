using System;

namespace G_NET_88_OOP05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StandardShipment s1 = new StandardShipment("SH001", "Laptop", 3, 80, new DeliveryAddress("Cairo", "Nasr City", 10));
            ExpressShipment s2 = new ExpressShipment("SH002", "Mobile Phone", 2, 60, new DeliveryAddress("Cairo", "Dokki", 5), 30);
            InternationalShipment s3 = new InternationalShipment("SH003", "Television", 8, 120, new DeliveryAddress("Cairo", "Center", 1), "Germany", 100);

            DeliveryCenter center = new DeliveryCenter("Main Center");
            center.AddShipment(s1);
            center.AddShipment(s2);
            center.AddShipment(s3);
            center.PrintAllShipments();
        }
    }
}
