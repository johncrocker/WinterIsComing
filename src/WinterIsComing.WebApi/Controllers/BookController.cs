using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WinterIsComing.Data.Interfaces;
using WinterIsComing.Data.Models;
using WinterIsComing.Data.Repositories;

namespace WinterIsComing.WebApi.Controllers
{
    public class BookController : ApiController
    {
        private IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public BookController() : this(new BookRepository())
        {

        }

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            IEnumerable<Book>  results = _bookRepository.List();

            if (results == null)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return results;
        }

        [HttpGet]
        public Book Get(int bookId)
        {
            Book result = _bookRepository.Get(bookId);

            if (result == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return result;
        }
    }
}
