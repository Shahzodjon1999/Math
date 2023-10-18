using Math.WebApi.Controllers;
using Math.WebApi.Model;
using Math.WebApi.Services;
using Microsoft.AspNetCore.Mvc;


namespace Math.Tests
{
    public class BooksControllerTest
    {
        BooksController _controller;

        IBookService _service;

        public BooksControllerTest()
        {
            _service = new BookService();
            _controller = new BooksController(_service);

        }
        
        [Fact]
        public void GetAllTest()
        {
            //Arrange
            //Act
            var result = _controller.Get();
            //Assert
            Assert.IsType<OkObjectResult>(result.Result);

            var list = result.Result as OkObjectResult;

            Assert.IsType<List<Book>>(list.Value);

            //
            //Act
            Guid guid = Guid.Parse("d81e0829-55fa-4c37-b62f-f578c692af78");

            var resultTest = _controller.Get(guid);
            //Assert
            Assert.IsType<OkObjectResult>(resultTest.Result);

            var GetBook = resultTest.Result as OkObjectResult;

            var resName = GetBook.Value as Book;
            

            Assert.Equal("The Lessons of History", resName.Title);
            //


            var listBooks = list.Value as List<Book>;

            Assert.Equal(5, listBooks.Count);
        }
    }
}
