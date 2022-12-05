namespace Book.Tests
{
    using System;

    using NUnit.Framework;
    using static System.Net.Mime.MediaTypeNames;

    public class Tests
    {
        [Test]
        public void BookNameIsValid()
        {
            const string name = "Dido";
            const string author = "Dido1";
            Book book = new Book(name, author);
            Assert.AreEqual(name, book.BookName);
        }
        [Test]
        public void BookNameIsInvalidWithNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(null, "Author");
            });
        }
        [Test]
        public void BookNameIsEmptyString()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(String.Empty, "Author");
            });
        }

        [Test]
        public void AuthorShouldBeValid()
        {
            const string name = "Dido";
            const string author = "Dido1";
            Book book = new Book(name, author);
            Assert.AreEqual(author, book.Author);
        }
        [Test]
        public void AuthorShouldBeNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("Name", null);
            });
        }
        [Test]
        public void AuthorShouldBeEmptyString()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("Name", String.Empty);
            });
        }

        [Test]
        public void AddFootNoteSouldWork()
        {
            Book book = new Book("Name", "Author");
            book.AddFootnote(1, "Text");
            book.AddFootnote(2, "Text1");
            Assert.AreEqual(2, book.FootnoteCount);
        }
        [Test]
        public void AddFootNoteShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var book = new Book("Name", "Author");
                book.AddFootnote(1, "Text");
                book.AddFootnote(1, "Text1");
            });
        }

        [Test]
        public void FindFootnoteShouldWork()
        {
            Book book = new Book("Name", "Author");
            book.AddFootnote(1, "Text");
            var footnote = book.FindFootnote(1);
            Assert.AreEqual("Footnote #1: Text", footnote);
        }
        [Test]
        public void FindFootnoteShouldNotWork()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Book book = new Book("Name", "Author");
                book.AddFootnote(1, "Text");
                var footnote = book.FindFootnote(2);
                Assert.AreEqual("Footnote #1: Text", footnote);
            });
        }
    }
}