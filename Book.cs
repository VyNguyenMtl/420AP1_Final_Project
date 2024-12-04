using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420AP1_Final_Project
{
    
        internal struct Book
        {
            public const int Minimum_Publication_Year = -8000;


            public string Title;
            public string Author;
            public int PublishedYear;
            public int OwnedCopies;
            public int RentedCopies;

            public Book(string title, string author, int publishedYear, int ownedCopies = 1, int rentedCopies = 0)
            {

                this.Title = title;
                this.Author = author;
                this.PublishedYear = publishedYear;
                this.OwnedCopies = ownedCopies;
                this.RentedCopies = rentedCopies;
            }
            public Book AddCopy()
            {
                this.OwnedCopies++;
            return this;
            }
            public Book RemoveCopy()
            {
            if (this.OwnedCopies < 0)
            { Console.WriteLine("There is no copy left to be removed."); }
            else
            {
                this.OwnedCopies--;
            }
             return this;
             }
        
        
            public bool CanBeRented()
            {
                return this.OwnedCopies > 0 && this.OwnedCopies > this.RentedCopies;

            }
            public Book RentCopy()
            {
                if (this.CanBeRented())
                {
                    this.RentedCopies++;

                }
                else { Console.WriteLine("No more book available."); }
                return this;
            }
            public bool CanBeReturned()
            {
                return this.RentedCopies > 0;
            }
            public Book ReturnRentedCopy()
            {
                if (this.CanBeReturned())
                {
                    this.RentedCopies--;

                }
                else { Console.WriteLine("No book to return."); }
                return this;
            }
            public void DisplayBook()
            { Console.WriteLine($"Title: {this.Title}, Author: {this.Author}, Published Year: {this.PublishedYear}, Owned Copies: {this.OwnedCopies}, RentedCopies: {this.RentedCopies}"); }
        }
 
}



