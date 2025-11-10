namespace Project;

    public abstract class Product : IComparable<Product>
    {
        private int price;
        private int quantity;

        protected Product(int price, int quantity)
        {
            this.price = price;
            this.quantity = quantity;
            if (price <= 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Цена должна быть положительной.");

            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Количество должно быть больше нуля.");
        }
        public int Price
        {
            get => price;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(Price), "Цена должна быть положительной.");
                price = value;
            }
        }
        public int Quantity
        {
            get => quantity;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(Quantity), "Количество должно быть больше нуля.");
                quantity = value;
            }
        }
        public int CompareTo(Product? other)
        {
            if (other == null) return 1;
            return this.Price.CompareTo(other.Price);
        }
        public abstract decimal GetTotal();

        public override string ToString()
        {
            return $"Цена за единицу: {Price}, Количество: {Quantity}, Общая стоимость: {GetTotal():C}";
        }

    }