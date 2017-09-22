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
    public class CultureRepository : AbstractRepository, ICultureRepository
    {
        public IEnumerable<Culture> List()
        {
            try
            {
                Logger.Trace("Begin -> List");

                using (IGraphClient client = DatabaseFactory.CreateReader())
                {
                    IEnumerable<Culture> results = client.Cypher
                        .Match("(culture:Culture)")
                        .Return(culture => culture.As<Culture>())
                        .OrderBy(new[] { "culture.name" })
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

        public IEnumerable<Character> ListCharactersInCulture(string name)
        {
            try
            {
                Logger.Trace("Begin -> ListCharactersInCulture");
                Logger.DebugFormat("Parameters [name={0}]", name);

                using (IGraphClient client = DatabaseFactory.CreateReader())
                {
                    IEnumerable<Character> results = client.Cypher
                        .Match("(culture:Culture {name: {name} })-[MEMBER]-(character:Character)")
                        .WithParams(new Dictionary<string, object>
                        {
                            {"name", name}
                        })
                        .Return(character => character.As<Character>())
                        .OrderBy(new[] { "character.name" })
                        .Results;

                    Logger.Trace("End -> ListCharactersInCulture");
                    return results;
                }
            }
            catch (Exception err)
            {
                Logger.Error("Error in ListCharactersInCulture", err);
                throw;
            }
        }
    }
}
