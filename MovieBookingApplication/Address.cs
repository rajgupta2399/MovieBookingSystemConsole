using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingApplication
{
    public class Address
    {
        private int addressId;
        private string addressLine;
        private string city;
        private string state;
        private string pincode;
        private string country;
        
        public Address()
        {
            this.addressId = 0;
            this.addressLine = String.Empty;
            this.city = String.Empty;
            this.state = String.Empty;
            this.pincode = String.Empty;
            this.country = String.Empty;
        }

        public Address(int addressId, string addressLine, string city, string state, string pincode, string country)
        {
            AddressId = addressId;
            AddressLine = addressLine;
            City = city;
            State = state;
            Pincode = pincode;
            Country = country;
        }


        public int AddressId
        {
            get { return addressId; }
            set
            {
                if (Commons.CheckEmptyInt(value))
                {
                    this.addressId = value;
                }
                else
                {
                    Console.WriteLine("AddressId not valid");
                    this.addressId = 0;
                }
            }
        }

        public string AddressLine
        {
            get { return addressLine; }
            set
            {
                if (Commons.CheckEmpty(value))
                {
                    this.addressLine = value;
                }
                else
                {
                    Console.WriteLine("Invalid AddressLine");
                    this.addressLine = String.Empty;
                }
            }
        }

        public string City
        {
            get { return city; }
            set
            {
                if (Commons.CheckEmpty(value))
                {
                    this.city = value;
                }
                else
                {
                    Console.WriteLine("Invalid City");
                }
            }
        }

        public string State
        {
            get { return state; }
            set
            {
                if (Commons.CheckEmpty(value))
                {
                    this.state = value;
                }
                else
                {
                    Console.WriteLine("Invalid State");
                    this.state = String.Empty;
                }
            }
        }

        public string Pincode
        {
            get { return pincode; }
            set
            {
                if (Commons.CheckEmpty(value) && Commons.GetRegex(@"^[\d]{6}$").IsMatch(value))
                {
                    this.pincode = value;
                }
                else
                {
                    Console.WriteLine("Invalid Pincode");
                    this.pincode = String.Empty;
                }

                    
            }
        }

        public string Country
        {
            get { return country; }
            set
            {
                if (Commons.CheckEmpty(value))
                {
                    this.country = value;
                }
                else
                {
                    Console.WriteLine("Invalid Country");
                    this.country = String.Empty;
                }
            }
        }


        public override string ToString()
        {
            return addressLine + ", " + city + ", " + state + ", " + pincode + ", " + country;
        }

    }
}
