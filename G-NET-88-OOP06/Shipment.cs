using System;

namespace G_NET_88_OOP05
{
    internal abstract class Shipment : ITrackable, IInsurable
    {
        #region Private Fields

        private string trackingCode;
        private string? description;
        private decimal weight;
        private decimal deliveryFee;

        #endregion

        #region Public Properties

        public DeliveryAddress Destination { get; set; }

        public string TrackingCode
        {
            get { return trackingCode; }
        }

        public string? Description
        {
            get { return description; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    description = value;
            }
        }

        public decimal Weight
        {
            get { return weight; }
            set
            {
                if (value > 0)
                    weight = value;
            }
        }

        public decimal DeliveryFee
        {
            get { return deliveryFee; }
            private set
            {
                if (value > 0)
                    deliveryFee = value;
            }
        }

        public abstract decimal EstimatedCost { get; }

        public string Status { get; set; } = "Ready";

        #endregion

        #region Constructors

        public Shipment(string trackingCode)
            : this(trackingCode, "Unknown", 1, 50, new DeliveryAddress("Unknown", "Unknown", 0))
        {
        }

        public Shipment(string trackingCode,
                        string description,
                        decimal weight,
                        decimal deliveryFee,
                        DeliveryAddress destination)
        {
            this.trackingCode = !string.IsNullOrWhiteSpace(trackingCode) ? trackingCode : "TRK000";

            Description = description;
            Weight = weight;
            DeliveryFee = deliveryFee;
            Destination = destination;
        }

        #endregion

        #region Object Copying Methods

        public Shipment CopyShipment()
        {
            return (Shipment)this.MemberwiseClone();
        }

        #endregion

        #region Methods

        public void UpdateDeliveryFee(decimal newFee)
        {
            if (newFee > 0)
                DeliveryFee = newFee;
        }

        public void UpdateWeight(decimal newWeight)
        {
            if (newWeight > 0)
                Weight = newWeight;
        }

        public void UpdateWeight(decimal newWeight, decimal extraWeight)
        {
            decimal totalWeight = newWeight + extraWeight;

            if (totalWeight > 0)
                Weight = totalWeight;
        }

        public abstract string GetTrackingStatus();

        public void UpdateTrackingStatus(string newStatus)
        {
            Status = newStatus;
        }

        public abstract void PrintShipment();

        public abstract decimal CalculateInsurance();

        public override string ToString()
        {
            return $"Tracking Code : {TrackingCode}" +
                   $"\nDescription   : {Description}" +
                   $"\nWeight        : {Weight}" +
                   $"\nDelivery Fee  : {DeliveryFee}" +
                   $"\nDestination   : {Destination.GetFullAddress()}" +
                   $"\nEstimated Cost: {EstimatedCost}";
        }

        #endregion
    }
}
