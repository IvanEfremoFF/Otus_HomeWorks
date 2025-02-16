using System;
using System.Collections.Concurrent;
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
        private ConcurrentDictionary<string, int> _books;

        public Library() 
        {
            _books = new ConcurrentDictionary<string, int>();
        }

        public void AddBook(string name) 
        {
            
            if (_books.ContainsKey(name) || string.IsNullOrEmpty(name))
                return;

            _books.TryAdd(name, 0);
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
                if (book.Value + 1 <= 100)
                {
                    _books[book.Key] = book.Value + 1;
                }
                else
                {
                    _books.TryRemove(book);
                }
            }

        }
    }
}

