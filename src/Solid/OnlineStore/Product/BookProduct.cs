using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore
{
    public class BookProduct : Product
    {
        public string Isbn { get; set; }

        public string Author { get; set; }

        public BookProduct(string code, string name, string description, string isbn, string author)
            : base(code, name, description)
        {
            Check.NotNull(isbn, nameof(isbn));
            Check.NotNull(author, nameof(author));

            Isbn = isbn;
            Author = author;
        }

        public BookProduct(string code, string name, string description)
            : base(code, name, description)
        {
        }

        public override Product Create(string code, string name, string description)
        {
            return new BookProduct(code, name, description);
        }

        public override string ToString()
        {
            return $"{ base.ToString() } Isbn: {Isbn}, Autor: {Author}";
        }
    }
}
