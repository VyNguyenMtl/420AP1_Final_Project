using System;
using System.ComponentModel.Design;
using System.Reflection;

namespace _420AP1_Final_Project
{
    internal class Program
    {
        public static List<Book> Books = new List<Book>();
        static void Main()
        {
            while (true)
            {
                //DISPLAY MAIN MENU//
                DisplayMenu();

                //REQUEST USER CHOICE//
                int choice = InputNumber("Please enter the function's number of your choice:  ", 1, 7);

                //PROCESS USER CHOICE//

                if (choice == 1) //CREATE BOOK//
                {
                    CreateBook();
                    Pause();
                
                }
                else if (choice == 2) //DISPLAY DETAILS OF A SPECIFIC BOOK//
                {
                    DisplayDetailsOfBook();
                    Pause();
                  
                }
                else if (choice == 3) //ADD COPY OF A BOOK//
                {
                    AddCopyOfBook();
                    Pause();
                  
                }
                else if (choice == 4) //REMOVE COPY OF A BOOK//
                {
                    RemoveCopyOfBook();
                    Pause();
                  
                }
                else if (choice == 5) //RENT COPY OF A BOOK//
                {
                    RentCopyOfBook();
                    Pause();
                   
                }
                else if (choice == 6) //RETURN COPY OF A BOOK//
                {
                    ReturnCopyOfBook();
                    Pause();
                    
                }
                else if (choice == 7) //EXIT PROGRAM//
                { break; }
            }
        }
        //VALIDATE USER INPUT//
        static int InputNumber(string message, int minimumValue = int.MinValue, int maximumValue = int.MaxValue)
        {
            int input = 0;
            bool isValid= false;

            while (!isValid) 
            {

                Console.WriteLine(message);

                if (int.TryParse(Console.ReadLine(), out input))
                {
                    if (input >= minimumValue && input <= maximumValue)
                    { 
                        isValid = true; 
                    }                  
                    else
                    { 
                        Console.WriteLine($"The input must be a number between {minimumValue} and {maximumValue}");
                    }
                }
                else 
                { 
                    Console.WriteLine("Invalid input. Please enter a valid number."); 
                }
            }
            return input;
        }
        static string StringInput(string message, int minLength = 0, int maxLength = int.MaxValue)
        {
            Console.WriteLine(message);

            string input = Console.ReadLine();

            if (input.Length < minLength || input.Length > maxLength) 
            { 
                Console.WriteLine($"The input must be words with length between {minLength} and {maxLength} ");
            }
            else 
            { 
                return input; 
            };
            return input;
        }
        //BOOK FUNCTIONS
        static void DisplayMenu()
        {
            Console.Clear();    
            Console.WriteLine("***** LIBRARY MAIN MENU*****");
            Console.WriteLine(" ");
            Console.WriteLine("1. Create new book ");
            Console.WriteLine("2. Show existing book details ");
            Console.WriteLine("3. Add new copy of a book ");
            Console.WriteLine("4. Remove copy of a book ");
            Console.WriteLine("5. Rent book copy ");
            Console.WriteLine("6. Return book copy ");
            Console.WriteLine(" ");
            Console.WriteLine("7. Exit program ");
            Console.WriteLine(" ");
            Console.WriteLine("*******************************");
        }
      

        static void CreateBook()
        {
            Console.Clear();
            string title = StringInput("Please enter the title of the book: ", 0, 256);
            string author = StringInput("Please enter the author of the book: ", 0, 128);
            int publishedYear = InputNumber("Please enter the published year: ", -8000, DateTime.Now.Year);
            Book book = new Book(title, author, publishedYear);
            Books.Add(book);
            Console.WriteLine(" ");
            Console.WriteLine("New book is created and added in the booklist with details below: ");
            book.DisplayBook();
            Console.WriteLine(" ");
        }
        
        static int SelectBookIndex()
        {
            for (int index = 0; index < Books.Count; index++)
            {
                Console.WriteLine($"#{index}.{Books[index].Title} by {Books[index].Author}");
            }
            Console.WriteLine(" ");
            int selectedIndex = InputNumber("Please select a book of your choice: ", 0, Books.Count - 1);
            return selectedIndex;

        }
        static void DisplayDetailsOfBook()
        {
            Console.Clear();
            Console.WriteLine("List of books in summary: ");
            int index = SelectBookIndex();
            Console.WriteLine(" ");
            Console.WriteLine("Here are more details of the book you chose: ");
            Books[index].DisplayBook();
            Console.WriteLine(" ");
        }

        static void AddCopyOfBook()
        {

            Console.Clear();
            Console.WriteLine("List of books in summary: ");
            int index = SelectBookIndex();
            Books[index] = Books[index].AddCopy();
           
            Console.WriteLine(" ");
            Console.WriteLine("A copy of the chosen book has been added. See details below: ");
            Console.WriteLine(" ");
            Books[index].DisplayBook();
            Console.WriteLine(" ");
        }

        static void RemoveCopyOfBook()
        {

            Console.Clear();
            Console.WriteLine("List of books in summary: ");
            int index = SelectBookIndex();
            Books[index] = Books[index].RemoveCopy();
          
            Console.WriteLine(" ");
            Console.WriteLine("A copy of the chosen book has been removed. See details below: ");
            Console.WriteLine(" ");
            Books[index].DisplayBook();
            Console.WriteLine(" ");
            if (Books[index].OwnedCopies <= 0)
            {
                Books.RemoveAt(index);
            }
            Console.WriteLine("The book has been removed from the list since it has no copies left.");
            Console.WriteLine(" ");
        }

        static void RentCopyOfBook()
        {

            Console.Clear();
            Console.WriteLine("List of books available to rent: ");
            for (int index = 0; index < Books.Count; index++) 
            {
                if (Books[index].OwnedCopies > 0 && Books[index].CanBeRented())
                { 
                    Console.WriteLine($"#{index}.{Books[index].Title} by {Books[index].Author}"); 
                } 
            }
            Console.WriteLine(" ");
            int chooseIndex = InputNumber("Please choose a book to rent its copy:", 0, Books.Count-1);
            Books[chooseIndex] = Books[chooseIndex].RentCopy();
            Console.WriteLine(" ");
            Console.WriteLine("A copy of the chosen book has been rented. See details below: ");
            Console.WriteLine(" ");
            Books[chooseIndex].DisplayBook();
            Console.WriteLine(" ");
        }

        static void ReturnCopyOfBook()
        {

            Console.Clear();
            Console.WriteLine("List of books available to rent: ");
            for (int index = 0; index < Books.Count; index++)
            {
                if (Books[index].CanBeReturned())
                { 
                    Console.WriteLine($"#{index}.{Books[index].Title} by {Books[index].Author}"); 
                }
            }
            Console.WriteLine(" ");
            int chooseIndex = InputNumber("Please choose a book to rent its copy:", 0, Books.Count - 1);
            Books[chooseIndex] = Books[chooseIndex].ReturnRentedCopy();
            Console.WriteLine(" ");
            Console.WriteLine("A copy of the chosen book has been returned. See details below: ");
            Console.WriteLine(" ");
            Books[chooseIndex].DisplayBook();
            Console.WriteLine(" ");
        }

        static void Pause()
        {         
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

    } 
}
