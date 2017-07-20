using System.Collections.Generic;

namespace Solid.SingleResponsibilityPrinciple
{
  public class Library
  {
    private readonly Dictionary<string, Book> books;

    public Library()
    {
      this.books = new Dictionary<string, Book>();
    }

    public Book BorrowBook(string isbn, Person borrower)
    {
      if (books.ContainsKey(isbn))
      {
        Book book = books[isbn];
        book.BorrowedBy = borrower;
        return book;
      }
      throw new System.InvalidOperationException();
    }

    public void ReturnBook(Book book)
    {
      book.BorrowedBy = null;
      books[book.ISBN] = book;
    }

  }

  public class Book
  {
    public Book(string title, Person author, string isbn)
    {
      this.Title = title;
      this.Author = author;
      this.ISBN = isbn;
    }

    public string Title { get; private set; }
    public Person Author { get; private set; }
    public string ISBN { get; private set; }
    public Person BorrowedBy { get; internal set; }
  }

  public class Person
  {
    public Person(string firstName, string lastName)
    {
      this.FirstName = firstName;
      this.LastName = lastName;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
  }
}