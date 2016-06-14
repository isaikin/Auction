using System;

namespace Common
{
    public class Product
    {
        private int id;
        private string name;
        private double currentRate;
        private DateTime completion;

        public Product(string name, double currentRate, DateTime completion)
        {
            this.Name = name;
            this.CurrentRate = currentRate;
            this.Completion = completion;
            this.id = -1;
        }

        public Product()
        {
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("is not positive id");
                }

                this.id = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("name is null or white space");
                }

                this.name = value;
            }
        }

        public double CurrentRate
        {
            get
            {
                return this.currentRate;
            }

            set
            {
                if (value - this.currentRate < 0.001)
                {
                    throw new ArgumentException("The new rate is less than the current");
                }

                this.currentRate = value;
            }
        }

        public DateTime Completion
        {
            get
            {
                return this.completion;
            }

            set
            {
                this.completion = value;
            }
        }
    }
}