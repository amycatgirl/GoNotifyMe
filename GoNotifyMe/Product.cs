namespace GoNotifyMe
{
    internal class Product
    {
        private readonly string id;
        private readonly string name;
        private readonly int minimumStock;
        private int stock;

        public Product(string id, string name, int minimumStock, int stock)
        {
            this.id = id;
            this.name = name;
            this.minimumStock = minimumStock;
            this.stock = stock;
        }

        public bool ShouldNotifyOfRestock()
        {
            if (stock < minimumStock)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
