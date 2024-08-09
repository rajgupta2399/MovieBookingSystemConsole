using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingApplication
{
    public class Customer
    {
        public int customerId;
        public string firstName;
        public string lastName;
        public string phone;
        public Address permanentAddress;
        public Contact primaryContact;

        public Customer()
        {
            this.customerId = 0;
            this.firstName = String.Empty;
            this.lastName = String.Empty;   
            this.phone = String.Empty;
            this.permanentAddress = new Address();
            this.primaryContact = new Contact();
        }

        public Customer(int customerId, string firstName, string lastName, string phone, Address address, Contact contact)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            PermanentAddress = address;
            PrimaryContact = contact;
        }

        public int CustomerId
        {
            get { return customerId; }
            set
            {
                if(Commons.CheckEmptyInt(value))
                {
                    this.customerId = value;
                }
                else
                {
                    Console.WriteLine("Invalid CustomerId");
                }
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (Commons.CheckEmpty(value))
                {
                    this.firstName = value;
                }
                else
                {
                    Console.WriteLine("Invalid FirstName");
                    this.firstName = String.Empty ;
                }
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (Commons.CheckEmpty(value))
                {
                    this.lastName = value;
                }
                else
                {
                    Console.WriteLine("Invalid LastName");
                    this.lastName = String.Empty ;
                }
            }
        }

        public string Phone
        {
            get { return phone; }
            set
            {
                if (Commons.CheckEmpty(value))
                {
                    this.phone = value;
                }
                else
                {
                    this.phone = String.Empty;
                }
            }
        }


        public void fileStorage()
        {
            string rootFolder = @"C:\Users\Raj Kumar\ASP.net\MovieBookingApplication\MovieBookingApplication\Account\";
            string accountFile = $@"C:\Users\Raj Kumar\ASP.net\MovieBookingApplication\MovieBookingApplication\Account\{Phone}.txt";

            if (File.Exists(accountFile))
            {
                Console.WriteLine("User Account Already Created");
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(accountFile))
                {
                    writer.WriteLine(this.ToString());
                }
            }

        }

        public static void checkAccount(string a)
        {
            string rootFolder = @"C:\Users\Raj Kumar\ASP.net\MovieBookingApplication\MovieBookingApplication\Account\";
            string accountFile = $@"{rootFolder}\{a}.txt";


            if (File.Exists(accountFile))
            {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                try
                {
                    foreach (var line in File.ReadLines(accountFile))
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        
                        var parts = line.Split(new[] { ':' }, 2);

                        if (parts.Length == 2)
                        {
                            string key = parts[0].Trim();
                            string value = parts[1].Trim();

                            keyValuePairs[key] = value;
                        }
                        else
                        {
                            Console.WriteLine($"Ignoring malformed line: {line}");
                        }
                    }

                    Console.WriteLine("User Account Information:");
                    if (keyValuePairs.ContainsKey("FirstName"))
                    {
                        Console.WriteLine($"Hello {keyValuePairs["FirstName"]}..Welcome Back..!!");
                    }
                    else
                    {
                        Console.WriteLine("First Name not found.");
                    }



                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading file: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("User Account does not exist.");
            }
        }

        public Address PermanentAddress { get; }
        public Contact PrimaryContact { get; }



        public override string ToString()
        {
            return " FirstName : " + FirstName +
                    "\n LastName : " + LastName +
                    "\n Address : " + PermanentAddress +
                    "\n Contact : " + PrimaryContact;
        }

    }
}
