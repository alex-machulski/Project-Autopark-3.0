using System;

namespace Autopark
{
    class Rent
    {
        internal DateTime RentDate { get; set; }
        internal double RentPrice { get; set; }

        public Rent()
        {
        }

        public Rent(DateTime rentDate, double rentPrice)
        {
            RentDate = rentDate;
            RentPrice = rentPrice;
        }
    }
}
