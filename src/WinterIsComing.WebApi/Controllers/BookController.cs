using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WinterIsComing.Data.Interfaces;
using WinterIsComing.WebApi.Models;
using WinterIsComing.Data.Models;
using WinterIsComing.Data.Repositories;
using WinterIsComing.WebApi.Services;

namespace WinterIsComing.WebApi.Controllers
{
    /// <summary>
    /// Book API - Returns information about the Books
    /// </summary>
    public class BookController : AbstractApiController
    {
        private IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
            : base()
        {
            _bookRepository = bookRepository;
        }

        public BookController() : this(new BookRepository())
        {

        }
 
        /// <summary>
        /// Returns the given book
        /// </summary>
        /// <param name="bookId">Identifier of the book</param>
        /// <returns>Book</returns>
        [HttpGet]
        [ActionName("Detail")]
        public BookModel Get(int bookId)
        {
            try
            {
                Logger.Trace("Begin => Get");
                Logger.DebugFormat("Parameters [bookId={0}]", bookId);

                Book result = _bookRepository.Get(bookId);

                if (result == null)
                {
                    Logger.DebugFormat("Book bookId={0} not found", bookId);
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                return BookModel.CopyFrom(result);
            }
            catch (Exception err)
            {
                Logger.Error("Error in Get", err);
                throw;
            }
            finally
            {
                Logger.Trace("End => Get");
            }
        }

        /// <summary>
        /// Returns a list of the characters in a given book
        /// </summary>
        /// <param name="bookId">Identifier of the book</param>
        /// <returns>Enumerable of Character</returns>         
        [HttpGet]
        [ActionName("Characters")]
        public IEnumerable<CharacterModel> ListCharactersInBook(int bookId)
        {
            try
            {
                Logger.Trace("Begin => ListCharactersInBook");
                IEnumerable<Character> results = _bookRepository.ListCharactersInBook(bookId);

                if (results == null)
                {
                    Logger.Debug("No Characters found for this Book");
                    throw new HttpResponseException(HttpStatusCode.NoContent);
                }

                return results.Select(t => CharacterModel.CopyFrom(t));
            }
            catch (Exception err)
            {
                Logger.Error("Error in ListCharactersInBook", err);
                throw;
            }
            finally
            {
                Logger.Trace("End => ListCharactersInBook");
            }
        }
    }
}
