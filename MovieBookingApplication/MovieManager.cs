using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingApplication
{
    public class MovieManager
    {
        private const string FilePath = @"C:\Users\Raj Kumar\ASP.net\MovieBookingApplication\MovieBookingApplication\MovieFolder\movies.txt";

        private List<Movie> movies;
        private Dictionary<string, Ticket> hallCategories;

        public MovieManager()
        {
            movies = new List<Movie>();
            hallCategories = new Dictionary<string, Ticket>();

            // Populate default hall categories with default prices and capacities
            hallCategories.Add("Standard", new Ticket("Standard", "500", 100));
            hallCategories.Add("Premium", new Ticket("Premium", "1000", 50));
            hallCategories.Add("VIP", new Ticket("VIP", "1500", 20));
        }

        public void AddMovie()
        {
            Console.Write("Enter movie name: ");
            string name = Console.ReadLine();
            Console.Write("Enter movie description: ");
            string description = Console.ReadLine();
            Console.Write("Enter movie year: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Enter movie genre: ");
            string genre = Console.ReadLine();
            Console.Write("Enter hall capacity: ");
            int hallCapacity;
            while (!int.TryParse(Console.ReadLine().Trim(), out hallCapacity) || hallCapacity <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid hall capacity.");
            }
            Movie movie = new Movie(name, description, year, genre,hallCapacity);
            movies.Add(movie);

            Console.WriteLine("Movie added successfully.");
        }

        public void ViewMovies()
        {
            if (movies.Count == 0)
            {
                Console.WriteLine("No movies available.");
                return;
            }

            Console.WriteLine("\nMovies List: \n");
            for (int i = 0; i < movies.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {movies[i]}");
            }
        }


        public void UpdateMovie()
        {
            Console.Write("Enter the movie number to update: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index < 0 || index >= movies.Count)
            {
                Console.WriteLine("Invalid movie number.");
                return;
            }

            Console.Write("Enter new movie name: ");
            movies[index].Name = Console.ReadLine();
            Console.Write("Enter new movie description: ");
            movies[index].Description = Console.ReadLine();
            Console.Write("Enter new movie year: ");
            movies[index].Year = int.Parse(Console.ReadLine());
            Console.Write("Enter new movie genre: ");
            movies[index].Genre = Console.ReadLine();
            Console.Write("Enter hall capacity: ");
            Console.Write("Enter new hall capacity: ");
            int hallCapacity;
            while (!int.TryParse(Console.ReadLine().Trim(), out hallCapacity) || hallCapacity <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid hall capacity.");
            }
            movies[index].HallCapacity = hallCapacity;

            Console.WriteLine("Movie updated successfully.");
        }

        public void DeleteMovie()
        {
            Console.Write("Enter the movie number to delete: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index < 0 || index >= movies.Count)
            {
                Console.WriteLine("Invalid movie number.");
                return;
            }

            movies.RemoveAt(index);
            Console.WriteLine("Movie deleted successfully.");
        }
        public void BookMovieTicket()
        {
            ViewMovies();
            Console.WriteLine("Select a movie by number to book a ticket:");
            int movieIndex = Convert.ToInt32(Console.ReadLine().Trim());
            if (movieIndex > 0 && movieIndex <= movies.Count)
            {
                Movie selectedMovie = movies[movieIndex - 1];
                Console.WriteLine($"You have selected: {selectedMovie.Name}");
                Console.WriteLine("Proceed to book a ticket...");
                Console.WriteLine("Choose hall category:");
                int i = 1;
                foreach (var category in hallCategories)
                {
                    Console.WriteLine($"{i}. {category.Key} - Price: {category.Value.Price:C} | Capacity: {category.Value.Capacity}");
                    i++;
                }

                if (int.TryParse(Console.ReadLine().Trim(), out int categoryIndex) && categoryIndex > 0 && categoryIndex <= hallCategories.Count)
                {
                    var selectedCategory = hallCategories.Values.ToArray()[categoryIndex - 1];
                    Console.WriteLine($"Hall Category selected: {selectedCategory.HallsCategory}");
                    Console.WriteLine($"Price per ticket: {selectedCategory.Price:C}");
                    Console.WriteLine($"Capacity: {selectedCategory.Capacity}");

                    // Proceed with further booking logic (e.g., seat selection, payment, etc.)
                    Console.WriteLine("Proceed to book a ticket...");
                    Console.WriteLine("Ticket booked successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid hall category selection. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid selection. Please try again.");
            }
        }

        public void SaveMoviesToFile()
        {
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                foreach (var movie in movies)
                {
                    writer.WriteLine(movie.ToFileString());
                }
            }
        }

        public void LoadMoviesFromFile()
        {
            if (File.Exists(FilePath))
            {
                using (StreamReader reader = new StreamReader(FilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        movies.Add(Movie.FromFileString(line));
                    }
                }
            }
        }

    }
}
