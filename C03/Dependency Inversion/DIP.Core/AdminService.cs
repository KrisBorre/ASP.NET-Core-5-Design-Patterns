﻿using DependencyInversionPrinciple.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple.Core
{
    public class AdminService
    {
        public IBookReader _bookReader;
        public IBookWriter _bookWriter;

        public Task<IEnumerable<Book>> FindAllAsync()
        {
            return Task.FromResult(_bookReader.Books);
        }

        public Task<Book> FindAsync(int bookId)
        {
            var book = _bookReader.Find(bookId);
            return Task.FromResult(book);
        }

        public Task CreateAsync(Book book)
        {
            _bookWriter.Create(book);
            return Task.CompletedTask;
        }

        public Task RemoveAsync(Book book)
        {
            _bookWriter.Remove(book);
            return Task.CompletedTask;
        }

        public Task ReplaceAsync(Book book)
        {
            _bookWriter.Replace(book);
            return Task.CompletedTask;
        }
    }
}
