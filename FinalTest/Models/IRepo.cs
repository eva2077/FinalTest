using System;
namespace FinalTest.Models
{
	public interface IRepo
	{
        IQueryable<Book> Books { get; }

        //allow you to add record
        void Add(Book response);
        //allow you to edit by grabbing id
        Book GetById(int id);
        //edit (update list)
        void UpdateBook(Book response);
        //delete
        void Delete(Book response);
    }
}

