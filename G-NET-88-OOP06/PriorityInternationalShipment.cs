using System;

namespace G_NET_88_OOP05
{
    internal class PriorityInternationalShipment : InternationalShipment
    {
        public PriorityInternationalShipment(string trackingCode,
                                             string description,
                                             decimal weight,
                                             decimal deliveryFee,
                                             DeliveryAddress destination,
                                             string country,
                                             decimal customsFee)
            : base(trackingCode, description, weight, deliveryFee, destination, country, customsFee)
        {
        }

        public sealed override void GenerateCustomsReport()
        {
            Console.WriteLine("Priority Customs Report Generated.");
        }
    }
}
