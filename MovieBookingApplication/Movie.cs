using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingApplication
{
    public class Movie
    {
        public string name;
        public string description;
        public int year;
        public string genre;
        public int HallCapacity { get; set; }

        public Movie()
        {
            this.name = String.Empty;
            this.description = String.Empty;
            this.year = 0;
            this.genre = String.Empty;
            this.HallCapacity = 0;
        }

        public Movie(string name, string description, int year, string genre, int hallCapacity)
        {
            Name = name;
            Description = description;
            Year = year;
            Genre = genre;
            HallCapacity = hallCapacity;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (Commons.CheckEmpty(value))
                {
                    this.name = value;
                }
                else
                {
                    Console.WriteLine("Invalid Movie Name");
                    this.name = String.Empty;
                }
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                if (Commons.CheckEmpty(value))
                {
                    this.description = value;
                }
                else
                {
                    Console.WriteLine("Invalid Movie Descricption");
                    this.description  = String.Empty;
                }
            }
        }

        public string Genre
        {
            get { return genre ; }
            set
            {
                if (Commons.CheckEmpty(value))
                {
                    this.genre  = value;
                }
                else
                {
                    Console.WriteLine("Invalid Movie Genre");
                    this.genre  = String.Empty;
                }
            }
        }

        public int Year
        {
            get { return year; }
            set
            {
                if (Commons.CheckEmptyInt(value))
                {
                    this.year  = value;
                }
                else
                {
                    Console.WriteLine("Invalid Year");
                    this.year = 0;
                }
            }
        }

        public override string ToString()
        {
            return $"Name: {Name} \nDescription: {Description} \nYear: {Year} \nGenre: {Genre} \nHall Capacity: {HallCapacity} \n";
        }

        public string ToFileString()
        {
            return $"{Name}|{Description}|{Year}|{Genre}|{HallCapacity}";
        }

        public static Movie FromFileString(string fileString)
        {
            var parts = fileString.Split('|');
            return new Movie(parts[0], parts[1], int.Parse(parts[2]), parts[3], int.Parse(parts[4]));
        }
    }
}
