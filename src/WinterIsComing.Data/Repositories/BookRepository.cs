using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Data.Factories;
using WinterIsComing.Data.Interfaces;
using WinterIsComing.Data.Models;

namespace WinterIsComing.Data.Repositories
{
    public class BookRepository : AbstractRepository, IBookRepository
    {

        public Book Get(int bookId)
        {
            try
            {
                Logger.Trace("Begin -> Get");
                Logger.DebugFormat("Parameters [bookId={0}]", bookId);

                using (IGraphClient client = DatabaseFactory.CreateReader())
                {
                    Book result = client.Cypher
                        .Match(
                            "(book:Book {id: {id} })")
                        .WithParams(new Dictionary<string, object>
                        {
                            {"id", bookId}
                        })
                        .Return(book => book.As<Book>())
                        .OrderBy(new[] { "book.id" })
                        .Results.FirstOrDefault();

                    Logger.Trace("End -> Get");
                    return result;
                }
            }
            catch (Exception err)
            {
                Logger.Error("Error in Get", err);
                throw;
            }
        }

        public IEnumerable<Book> List()
        {
            try
            {
                Logger.Trace("Begin -> List");

                using (IGraphClient client = DatabaseFactory.CreateReader())
                {
                    IEnumerable<Book> results = client.Cypher
                        .Match("(book:Book)")
                        .Return(book => book.As<Book>())
                        .OrderBy(new[] { "book.name" })
                        .Results;

                    Logger.Trace("End -> List");
                    return results;
                }
            }
            catch (Exception err)
            {
                Logger.Error("Error in List", err);
                throw;
            }
        }

        public IEnumerable<Character> ListCharactersInBook(int bookId)
        {
            try
            {
                Logger.Trace("Begin -> ListCharactersInBook");
                Logger.DebugFormat("Parameters [bookId={0}]", bookId);

                using (IGraphClient client = DatabaseFactory.CreateReader())
                {
                    IEnumerable<Character> results = client.Cypher
                        .Match("(book:Book {id: {id} })-[APPEARS]-(character:Character)")
                        .WithParams(new Dictionary<string, object>
                        {
                            {"id", bookId}
                        })
                        .Return(character => character.As<Character>())
                        .OrderBy(new[] { "character.name" })
                        .Results;

                    Logger.Trace("End -> ListCharactersInBook");
                    return results;
                }
            }
            catch (Exception err)
            {
                Logger.Error("Error in ListCharactersInBook", err);
                throw;
            }
        }
    }
}
