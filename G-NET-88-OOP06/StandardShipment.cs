using System;
using System.Net.NetworkInformation;

namespace G_NET_88_OOP05
{
    internal class StandardShipment : Shipment
    {
        #region Constructors

        public StandardShipment(string trackingCode)
            : base(trackingCode)
        {
            Status = "Ready";
        }

        public StandardShipment(string trackingCode,
                                string description,
                                decimal weight,
                                decimal deliveryFee,
                                DeliveryAddress destination)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            Status = "Ready";
        }

        #endregion

        #region Abstract Member & Interface Implementation

        public override decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + (Weight * 5);
            }
        }

        public override void PrintShipment()
        {
            Console.WriteLine("Standard Shipment");
            Console.WriteLine();
            Console.WriteLine($"Tracking Code : {TrackingCode}");
            Console.WriteLine($"Description   : {Description}");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
        }

        public override string GetTrackingStatus()
        {
            return $"Shipment {TrackingCode} is {Status}.";
        }

        public override decimal CalculateInsurance()
        {
            return EstimatedCost * 0.05m;
        }

        #endregion
    }
}
