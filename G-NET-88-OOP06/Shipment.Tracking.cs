using System;

namespace G_NET_88_OOP05
{
    internal abstract partial class Shipment
    {
        #region Tracking Properties & Members

        public string Status { get; set; } = "Ready";

        public abstract string GetTrackingStatus();

        public void UpdateTrackingStatus(string newStatus)
        {
            Status = newStatus;
            OnTrackingStatusChanged(newStatus);
        }

        #endregion

        #region Partial Methods

        partial void OnTrackingStatusChanged(string newStatus);

        partial void OnTrackingStatusChanged(string newStatus)
        {
            Console.WriteLine($"Tracking status changed to: {newStatus}");
        }

        #endregion
    }
}
