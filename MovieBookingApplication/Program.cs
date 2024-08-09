using MovieBookingApplication;
using System.Security.Principal;

Address address1 = new Address(addressId: 1, addressLine: "Kohat Enclave", city: "Delhi", state: "New Delhi", pincode: "110086", country: "India");
Console.WriteLine(address1.ToString());

Contact contact1 = new Contact(contactId: 1, contactNumber: "8700066069", email: "rajkuar499@gmail.com");
Console.WriteLine(contact1.ToString());

Customer customer1 = new Customer(customerId:1, firstName:"Raj",lastName:"Kumar", phone: "1234567890", address: address1, contact: contact1);
Console.WriteLine(customer1.ToString());

//Movie movie1 = new Movie(name: "Avengers", description: "SuperHero Movie", genre: "Thriller", year: 2020);
//Console.WriteLine(movie1.ToString());


MovieManager movieManager1 = new MovieManager();
movieManager1.LoadMoviesFromFile();

Console.WriteLine("1) User Account Login '\n2) Admin Account Login \nEnter Your Choice : ");
int choice = Convert.ToInt32(Console.ReadLine().Trim());
if(choice == 1)
{
    Console.WriteLine("Does User Have Account \n 1) For Yes \n 2) For No : ");
    int choice1 = Convert.ToInt32(Console.ReadLine().Trim());
    if(choice1 == 1)
    {
        Console.WriteLine("Enter your User Account phone number:");
        string phoneNumber = Console.ReadLine().Trim();

        if (!Commons.GetRegex(@"^\d{10}$").IsMatch(phoneNumber))
        {
            Console.WriteLine("Invalid input. Please enter a valid 10-digit phone number.");
        }
        else
        {
            Customer.checkAccount(phoneNumber);
            while (true)
            {
                Console.WriteLine("Welcome To Movie Ticket Booking Application \n1). To View Movie List \n2). To Book movie Ticket\n3). To view Ticket Booking \n4). To Cancel Ticket Booking \n5). Exit the Applicaton");
                string userChoice = Console.ReadLine().Trim();
                switch (userChoice)
                {
                    case "1":
                        movieManager1.ViewMovies();
                        break;
                    case "2":
                        // Implement booking logic here
                        movieManager1.BookMovieTicket();
                        break;
                    case "3":
                        // Implement view ticket booking logic here
                        break;
                    case "4":
                        // Implement cancel ticket booking logic here
                        break;
                    case "5":
                        Console.WriteLine("Exiting the Application...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            
        }

    }
    else if(choice1 == 2)
    {
        Console.WriteLine("Why We Don't Have any Account create your account first");
        createAccount();

    }
    else
    {
        Console.WriteLine("Invalid Input Only Integer Value");
    }
}
else if(choice == 2)
{
    Console.WriteLine("Enter Admin Password : ");
    int password = Convert.ToInt32(Console.ReadLine().Trim());
    if(password == 1234)
    {
        MovieManager movieManager = new MovieManager();
        movieManager.LoadMoviesFromFile();
        while (true)
        {
            Console.WriteLine("\nMovie Manager");
            Console.WriteLine("1. Add Movie");
            Console.WriteLine("2. View Movies");
            Console.WriteLine("3. Update Movie");
            Console.WriteLine("4. Delete Movie");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            string choice2 = Console.ReadLine();

            switch (choice2)
            {
                case "1":
                    movieManager.AddMovie();
                    break;
                case "2":
                    movieManager.ViewMovies();
                    break;
                case "3":
                    movieManager.UpdateMovie();
                    break;
                case "4":
                    movieManager.DeleteMovie();
                    break;
                case "5":
                    movieManager.SaveMoviesToFile();
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
    else
    {
        Console.WriteLine("Wrong password..!!");
    }
}
else
{
    Console.WriteLine("Invalid Input \n Try Again Later...");
}

void createAccount()
{

    Console.WriteLine("Enter Your Name : ");
    string FirstName = Console.ReadLine().Trim();

    Console.WriteLine("Enter Your LastName : ");
    string LastName = Console.ReadLine().Trim();

    Console.WriteLine("Enter Your Phone Number : ");
    string contactNumber = Console.ReadLine().Trim();

    Console.WriteLine("Enter Your Email : ");
    string email = Console.ReadLine();

    Console.WriteLine("Enter Your AddressLine : ");
    string addressLine = Console.ReadLine().Trim();

    Console.WriteLine("Enter Your City : ");
    string city = Console.ReadLine().Trim();

    Console.WriteLine("Enter Your State : ");
    string state = Console.ReadLine().Trim();

    Console.WriteLine("Enter Your Pincode : ");
    string pincode = Console.ReadLine().Trim();

    Console.WriteLine("Enter Your Country : ");
    string country = Console.ReadLine().Trim();

    Address address = new Address(1, addressLine, city, state, pincode, country);
    Contact contact = new Contact(1, contactNumber, email);

    Customer customer = new Customer(customerId: 1, firstName: FirstName, lastName: LastName, phone: contactNumber, address: address, contact: contact);
    Console.WriteLine(customer1 != null ? "Thank You For Sign Up \n New Profile Created \n Login Your Profile" : "Profile Not Created");

    customer.fileStorage();
}



