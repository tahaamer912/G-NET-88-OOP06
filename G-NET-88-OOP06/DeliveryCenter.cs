using System;

namespace G_NET_88_OOP05
{
    internal class DeliveryCenter
    {
        #region Private Fields

        private Shipment?[] shipments;
        private int count;

        #endregion

        #region Properties

        public string CenterName { get; set; }
        public Driver? Driver { get; set; }

        public int Count
        {
            get
            {
                return count;
            }
        }

        #endregion

        #region Constructors

        public DeliveryCenter()
            : this("Default Delivery Center")
        {
        }

        public DeliveryCenter(string centerName)
        {
            CenterName = !string.IsNullOrWhiteSpace(centerName) ? centerName : "Default Delivery Center";
            shipments = new Shipment?[20];
            count = 0;
        }

        #endregion

        #region Integer Indexer

        public Shipment? this[int index]
        {
            get
            {
                if (shipments != null && index >= 0 && index < count)
                {
                    return shipments[index];
                }

                return null;
            }

            set
            {
                if (shipments != null && index >= 0 && index < count)
                {
                    shipments[index] = value;
                }
            }
        }

        #endregion

        #region String Indexer

        public Shipment? this[string? trackingCode]
        {
            get
            {
                if (shipments != null && !string.IsNullOrWhiteSpace(trackingCode))
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (shipments[i] != null && shipments[i]!.TrackingCode == trackingCode)
                        {
                            return shipments[i];
                        }
                    }
                }

                return null;
            }
        }

        #endregion

        #region Methods

        public bool AddShipment(Shipment shipment)
        {
            if (shipment == null)
            {
                return false;
            }

            if (shipments == null)
            {
                shipments = new Shipment?[20];
            }

            if (count >= shipments.Length)
            {
                return false;
            }

            shipments[count] = shipment;
            count++;

            return true;
        }

        public bool RemoveShipment(string? trackingCode)
        {
            if (shipments == null || string.IsNullOrWhiteSpace(trackingCode))
            {
                return false;
            }

            for (int i = 0; i < count; i++)
            {
                if (shipments[i] != null && shipments[i]!.TrackingCode == trackingCode)
                {
                    for (int j = i; j < count - 1; j++)
                    {
                        shipments[j] = shipments[j + 1];
                    }

                    shipments[count - 1] = null;
                    count--;

                    return true;
                }
            }

            return false;
        }

        public void PrintAllShipments()
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("Delivery Center");
            Console.WriteLine("==========================================");
            Console.WriteLine();

            for (int i = 0; i < count; i++)
            {
                shipments[i]?.PrintShipment();
                Console.WriteLine();

                if (i < count - 1)
                {
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine();
                }
            }

            Console.WriteLine("==========================================");
        }

        public void PrintTrackingStatuses()
        {
            for (int i = 0; i < count; i++)
            {
                if (shipments[i] is ITrackable trackable)
                {
                    DeliveryReport.PrintShipment(trackable);
                    Console.WriteLine();
                }
            }
        }

        #endregion
    }
}
