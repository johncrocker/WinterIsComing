using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WinterIsComing.Data.Interfaces;
using WinterIsComing.Data.Models;
using WinterIsComing.Data.Repositories;
using WinterIsComing.WebApi.Models;
using WinterIsComing.WebApi.Services;

namespace WinterIsComing.WebApi.Controllers
{
    /// <summary>
    /// Book API - Returns information about the Books
    /// </summary>
    public class BooksController : AbstractApiController
    {
        private IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
            : base()
        {
            _bookRepository = bookRepository;
        }

        public BooksController() : this(new BookRepository())
        {

        }

        /// <summary>
        /// Returns a list of the books
        /// </summary>
        /// <returns>Enumerable of Book</returns>
        [HttpGet]
        public IEnumerable<BookModel> List()
        {
            try
            {
                Logger.Trace("Begin => List");
                IEnumerable<Book> results = _bookRepository.List();

                if (results == null)
                {
                    Logger.Debug("No books found");
                    throw new HttpResponseException(HttpStatusCode.NoContent);
                }

                return results.Select(t => BookModel.CopyFrom(t));
            }
            catch (Exception err)
            {
                Logger.Error("Error in List", err);
                throw;
            }
            finally
            {
                Logger.Trace("End => List");
            }
        }
    }
}
