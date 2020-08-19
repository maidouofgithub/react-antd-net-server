﻿using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using ReactAntdServer.Model;
using ReactAntdServer.Model.Config;

namespace ReactAntdServer.Services
{
    public class BookService
    {
        private readonly IMongoCollection<Book> _books;

        public BookService(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<Book>(settings.BooksCollectionName);
        }

        public List<Book> Get() =>
            _books.Find(book => true).ToList();

        public Book Get(string id) =>
            _books.Find(book => book.Id == id).FirstOrDefault();

        public Book Create(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        public void Update(string id, Book bookNew) =>
            _books.ReplaceOne(book => book.Id == id, bookNew);

        public void Remove(string id) =>
            _books.DeleteOne(b => b.Id == id);

        public void Remove(Book bookIn) =>
          _books.DeleteOne(book => book.Id == bookIn.Id);
    }
}
