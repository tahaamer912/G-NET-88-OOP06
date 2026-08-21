using System;

namespace G_NET_88_OOP05
{
    internal static class ShipmentExtensions
    {
        public static string GetSummary(this Shipment shipment)
        {
            if (shipment == null)
                return string.Empty;

            string type = shipment.GetType().Name.Replace("Shipment", "");
            return $"{shipment.TrackingCode} | {type} | {shipment.Weight} KG | {shipment.Status}";
        }

        public static bool IsDelivered(this Shipment shipment)
        {
            if (shipment == null)
                return false;

            return shipment.Status.Equals("Delivered", StringComparison.OrdinalIgnoreCase) ||
                   shipment.Status.IndexOf("Delivered", StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
