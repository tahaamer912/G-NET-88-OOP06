namespace G_NET_88_OOP05
{
    internal class DeliveryAddress
    {
        #region Fields

        public string City;
        public string Street;
        public int BuildingNumber;

        #endregion

        #region Constructor

        public DeliveryAddress(string city, string street, int buildingNumber)
        {
            City = city ?? string.Empty;
            Street = street ?? string.Empty;
            BuildingNumber = buildingNumber;
        }

        #endregion

        #region Methods

        public string GetFullAddress()
        {
            return $"{BuildingNumber}, {Street}, {City}";
        }

        public override string ToString()
        {
            return GetFullAddress();
        }

        #endregion
    }
}
