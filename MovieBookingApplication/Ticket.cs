using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingApplication
{
    public class Ticket
    {
        public string hallsCategory;
        public string price;
        public int capacity;

        public Ticket()
        {
            this.hallsCategory = String.Empty;
            this.price = String.Empty;
            this.capacity = 0;
        }

        public Ticket(string hallsCategory, string price, int capacity)
        {
            HallsCategory = hallsCategory;
            Price = price;
            Capacity = capacity;
        }

        public string HallsCategory
        {
            get { return this.hallsCategory; }
            set
            {
                if (Commons.CheckEmpty(value))
                {
                    this.hallsCategory = value;
                }
                else
                {
                    Console.WriteLine("Invalid HallCategory");
                    this.hallsCategory = String.Empty;
                }
            }
        }

        public string Price
        {
            get { return this.price; }
            set
            {
                if (Commons.CheckEmpty(value))
                {
                    this.price = value;
                }
                else
                {
                    Console.WriteLine("Invalid Price");
                    this.price = String.Empty;
                }
            }
        }

        public int Capacity
        {
            get { return this.capacity; }
            set
            {
                if (Commons.CheckEmptyInt(value))
                {
                    this.capacity = value;
                }
                else
                {
                    Console.WriteLine("Invalid Capacity");
                    this.Capacity = 0;
                }
            }
        }

        public override string ToString()
        {
            return $"Hall Category: {HallsCategory}\nPrice: {Price}\nCapacity: {Capacity}";
        }
    }
}
