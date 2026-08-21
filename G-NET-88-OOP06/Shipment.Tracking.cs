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
        }

        #endregion
    }
}
