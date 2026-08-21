using System;

namespace G_NET_88_OOP05
{
    internal sealed class CompletedShipment : Shipment
    {
        public CompletedShipment(string code) : base(code)
        {
            Status = "has been Delivered";
        }

        public override decimal EstimatedCost => DeliveryFee + (Weight * 5);

        public override void PrintShipment()
        {
            Console.WriteLine("Completed Shipment");
            Console.WriteLine();
            Console.WriteLine($"Tracking Code : {TrackingCode}");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
        }

        public override string GetTrackingStatus()
        {
            return $"Shipment {TrackingCode} {Status}.";
        }

        public override decimal CalculateInsurance()
        {
            return EstimatedCost * 0.05m;
        }
    }
}
