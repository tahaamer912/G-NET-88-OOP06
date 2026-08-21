using System;

namespace G_NET_88_OOP05
{
    internal class InternationalShipment : Shipment
    {
        #region Private Fields

        private string destinationCountry = "Unknown";
        private decimal customsFee;

        #endregion

        #region Public Properties

        public string DestinationCountry
        {
            get
            {
                return destinationCountry;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    destinationCountry = value;
                }
            }
        }

        public decimal CustomsFee
        {
            get
            {
                return customsFee;
            }
            set
            {
                if (value >= 0)
                {
                    customsFee = value;
                }
            }
        }

        public override decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + (Weight * 5) + CustomsFee;
            }
        }

        #endregion

        #region Constructors

        public InternationalShipment(string trackingCode,
                                     string destinationCountry,
                                     decimal customsFee)
            : base(trackingCode)
        {
            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;
            Status = "has been Delivered";
        }

        public InternationalShipment(string trackingCode,
                                     string description,
                                     decimal weight,
                                     decimal deliveryFee,
                                     DeliveryAddress destination,
                                     string destinationCountry,
                                     decimal customsFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;
            Status = "has been Delivered";
        }

        #endregion

        #region Abstract Member & Interface Implementation

        public virtual void GenerateCustomsReport()
        {
            Console.WriteLine("Customs Report Generated.");
        }

        public override void PrintShipment()
        {
            Console.WriteLine("International Shipment");
            Console.WriteLine();
            Console.WriteLine($"Tracking Code        : {TrackingCode}");
            Console.WriteLine($"Destination Country  : {DestinationCountry}");
            Console.WriteLine($"Estimated Cost       : {EstimatedCost} EGP");
        }

        public override string GetTrackingStatus()
        {
            return $"Shipment {TrackingCode} {Status}.";
        }

        public override decimal CalculateInsurance()
        {
            return EstimatedCost * 0.12m;
        }

        #endregion
    }
}
