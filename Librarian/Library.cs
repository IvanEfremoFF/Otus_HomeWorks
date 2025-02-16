using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarian
{
    internal class Library
    {
        private ImmutableDictionary<string, int> _books;

        public Library() 
        {
            _books = ImmutableDictionary.Create<string, int>();
        }

        public void AddBook(string name) 
        {
            
            if (_books.ContainsKey(name) || string.IsNullOrEmpty(name))
                return;

            _books = _books.Add(name, 0);
        }

        public string GetUnreadBooks()
        {
            var listOfUnreadBooks = "";
            foreach (var book in _books)
            {
                listOfUnreadBooks += $"{book.Key} - {book.Value}%\n";
            }

            return listOfUnreadBooks;
        }

        public void RecalculatePercentage() 
        {
            
            foreach (var book in _books)
            {
                _books = _books.Remove(book.Key);                
                if (book.Value + 1 <= 100)
                {
                    _books = _books.Add(book.Key, book.Value + 1);
                }
            }

        }
    }
}

