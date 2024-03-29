﻿using ApiEBooks.Dto;

namespace ApiEBooks.Services
{
    public interface IBookService
    {
        public IEnumerable<BookDto> Get();
        public BookDto? Get(int id);

        BookDto Create(BookDto author);
        void Update(BookDto author);
        void Delete(int id);
    }
}


