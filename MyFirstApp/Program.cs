using MyFirstApp.Model;
using System;
//Memory bazasini yaratmaq
Book[] books = new Book[100];

int count = 0;

while (true)
{
    Console.ForegroundColor = ConsoleColor.Cyan;

    Console.WriteLine("\n========= LIBRARY MENU =========");
    Console.WriteLine("1. Add Book");
    Console.WriteLine("2. Show All Books");
    Console.WriteLine("3. Search Book");
    Console.WriteLine("4. Update Book");
    Console.WriteLine("5. Delete Book");
    Console.WriteLine("6. Borrow Book");
    Console.WriteLine("7. Return Book");
    Console.WriteLine("8. Show Available Books");
    Console.WriteLine("9. Show Borrowed Books");
    Console.WriteLine("0. Exit");
    Console.Write("Choose: ");

    string choice = Console.ReadLine();

    Console.ResetColor();

    switch (choice)
    {
        case "1":
            AddBook();
            break;

        case "2":
            ShowBooks();
            break;

        case "3":
            SearchBook();
            break;

        case "4":
            UpdateBook();
            break;

        case "5":
            DeleteBook();
            break;

        case "6":
            BorrowBook();
            break;

        case "7":
            ReturnBook();
            break;

        case "8":
            ShowAvailableBooks();
            break;

        case "9":
            ShowBorrowedBooks();
            break;

        case "0":
            Console.WriteLine("Program finished.");
            return;

        default:
            Console.WriteLine("Wrong choice!");
            break;
    }
}

void AddBook()
{
    Console.Write("Enter Id: ");
    int id = int.Parse(Console.ReadLine());

    // Unique ID check
    for (int i = 0; i < count; i++)
    {
        if (books[i].Id == id)
        {
            Console.WriteLine("This ID already exists!");
            return;
        }
    }

    Console.Write("Enter Name: ");
    string name = Console.ReadLine();

    Console.Write("Enter Author: ");
    string author = Console.ReadLine();

    Console.Write("Enter Year: ");
    int year = int.Parse(Console.ReadLine());

    books[count] = new Book()
    {
        Id = id,
        Name = name,
        Author = author,
        Year = year,
        IsBorrowed = false
    };

    count++;

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Book added successfully!");
    Console.ResetColor();
}

void ShowBooks()
{
    if (count == 0)
    {
        Console.WriteLine("No books found.");
        return;
    }

    for (int i = 0; i < count; i++)
    {
        Console.WriteLine("\n---------------------");
        Console.WriteLine($"ID: {books[i].Id}");
        Console.WriteLine($"Name: {books[i].Name}");
        Console.WriteLine($"Author: {books[i].Author}");
        Console.WriteLine($"Year: {books[i].Year}");
        Console.WriteLine($"Status: {(books[i].IsBorrowed ? "Borrowed" : "Available")}");
    }
}

void SearchBook()
{
    Console.Write("Enter book name: ");
    string search = Console.ReadLine().ToLower();

    bool found = false;

    for (int i = 0; i < count; i++)
    {
        if (books[i].Name.ToLower().Contains(search))
        {
            Console.WriteLine("\nBook Found:");
            Console.WriteLine($"ID: {books[i].Id}");
            Console.WriteLine($"Name: {books[i].Name}");
            Console.WriteLine($"Author: {books[i].Author}");
            Console.WriteLine($"Year: {books[i].Year}");

            found = true;
        }
    }

    if (!found)
    {
        Console.WriteLine("Book not found.");
    }
}

void UpdateBook()
{
    Console.Write("Enter Book ID: ");
    int id = int.Parse(Console.ReadLine());

    for (int i = 0; i < count; i++)
    {
        if (books[i].Id == id)
        {
            Console.Write("New Name: ");
            books[i].Name = Console.ReadLine();

            Console.Write("New Author: ");
            books[i].Author = Console.ReadLine();

            Console.Write("New Year: ");
            books[i].Year = int.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Book updated successfully!");
            Console.ResetColor();

            return;
        }
    }

    Console.WriteLine("Book not found.");
}

void DeleteBook()
{
    Console.Write("Enter Book ID: ");
    int id = int.Parse(Console.ReadLine());

    for (int i = 0; i < count; i++)
    {
        if (books[i].Id == id)
        {
            for (int j = i; j < count - 1; j++)
            {
                books[j] = books[j + 1];
            }

            books[count - 1] = null;
            count--;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Book deleted successfully!");
            Console.ResetColor();

            return;
        }
    }

    Console.WriteLine("Book not found.");
}

void BorrowBook()
{
    Console.Write("Enter Book ID: ");
    int id = int.Parse(Console.ReadLine());

    for (int i = 0; i < count; i++)
    {
        if (books[i].Id == id)
        {
            if (books[i].IsBorrowed)
            {
                Console.WriteLine("This book is already borrowed.");
            }
            else
            {
                books[i].IsBorrowed = true;

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Book borrowed successfully!");
                Console.ResetColor();
            }

            return;
        }
    }

    Console.WriteLine("Book not found.");
}

void ReturnBook()
{
    Console.Write("Enter Book ID: ");
    int id = int.Parse(Console.ReadLine());

    for (int i = 0; i < count; i++)
    {
        if (books[i].Id == id)
        {
            if (!books[i].IsBorrowed)
            {
                Console.WriteLine("This book is already available.");
            }
            else
            {
                books[i].IsBorrowed = false;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Book returned successfully!");
                Console.ResetColor();
            }

            return;
        }
    }

    Console.WriteLine("Book not found.");
}

void ShowAvailableBooks()
{
    bool found = false;

    for (int i = 0; i < count; i++)
    {
        if (!books[i].IsBorrowed)
        {
            Console.WriteLine("\n---------------------");
            Console.WriteLine($"ID: {books[i].Id}");
            Console.WriteLine($"Name: {books[i].Name}");
            Console.WriteLine($"Author: {books[i].Author}");

            found = true;
        }
    }

    if (!found)
    {
        Console.WriteLine("No available books.");
    }
}

void ShowBorrowedBooks()
{
    bool found = false;

    for (int i = 0; i < count; i++)
    {
        if (books[i].IsBorrowed)
        {
            Console.WriteLine("\n---------------------");
            Console.WriteLine($"ID: {books[i].Id}");
            Console.WriteLine($"Name: {books[i].Name}");
            Console.WriteLine($"Author: {books[i].Author}");

            found = true;
        }
    }

    if (!found)
    {
        Console.WriteLine("No borrowed books.");
    }
}