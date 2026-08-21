using System;

namespace G_NET_88_OOP05
{
    internal class ExpressShipment : Shipment
    {
        #region Private Fields

        private decimal extraFee;

        #endregion

        #region Public Properties

        public decimal ExtraFee
        {
            get
            {
                return extraFee;
            }
            set
            {
                if (value >= 0)
                {
                    extraFee = value;
                }
            }
        }

        public override decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + (Weight * 5) + ExtraFee;
            }
        }

        #endregion

        #region Constructors

        public ExpressShipment(string trackingCode, decimal extraFee)
            : base(trackingCode)
        {
            ExtraFee = extraFee;
            Status = "Out for Delivery";
        }

        public ExpressShipment(string trackingCode,
                               string description,
                               decimal weight,
                               decimal deliveryFee,
                               DeliveryAddress destination,
                               decimal extraFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            ExtraFee = extraFee;
            Status = "Out for Delivery";
        }

        #endregion

        #region Abstract Member & Interface Implementation

        public override void PrintShipment()
        {
            Console.WriteLine("Express Shipment");
            Console.WriteLine();
            Console.WriteLine($"Tracking Code : {TrackingCode}");
            Console.WriteLine($"Extra Fee     : {ExtraFee} EGP");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
        }

        public override string GetTrackingStatus()
        {
            return $"Shipment {TrackingCode} is {Status}.";
        }

        public override decimal CalculateInsurance()
        {
            return EstimatedCost * 0.08m;
        }

        #endregion
    }
}
