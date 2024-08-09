using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingApplication
{
    public class Contact
    {
        private int contactId;
        private string contactNumber;
        private string email;

        public Contact()
        {
            this.contactId = 0;
            this.contactNumber = String.Empty;
            this.email = String.Empty;
        }

        public Contact(int contactId, string contactNumber, string email)
        {
            ContactId = contactId;
            ContactNumber = contactNumber;
            Email = email;
        }

        public int ContactId
        {
            get { return contactId; }
            set
            {
                if (Commons.CheckEmptyInt(value))
                {
                    contactId = value;
                }
                else
                {
                    this.contactId = 0;
                    Console.WriteLine("Invalid ContactId");
                }
            }
        }

        public string ContactNumber
        {
            get { return contactNumber; }
            set
            {
                if(Commons.CheckEmpty(value) && Commons.GetRegex(@"^[\d*]{10}$").IsMatch(value))
                {
                    contactNumber = value;
                }
                else
                {
                    this.contactNumber = String.Empty;

                }
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if(Commons.CheckEmpty(value) && Commons.GetRegex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").IsMatch(value))
                {
                    email = value;
                }
                else
                {
                    this.email = String.Empty;
                    Console.WriteLine("Invalid Email");
                }
            }
        }

        public override string ToString()
        {
            return contactNumber + ", " + email;
        }
    }
}
