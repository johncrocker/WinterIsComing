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
    public class TvSeriesRepository : AbstractRepository, ITvSeriesRepository
    {
        public TvSeries Get(int season)
        {
            try
            {
                Logger.Trace("Begin -> Get");
                Logger.DebugFormat("Parameters [season={0}]", season);

                using (IGraphClient client = DatabaseFactory.CreateReader())
                {
                    TvSeries result = client.Cypher
                        .Match(
                            "(series:TvSeries {name: {name} })")
                        .WithParams(new Dictionary<string, object>
                        {
                            {"name", string.Format("Season {0}", season)}
                        })
                        .Return(series => series.As<TvSeries>())
                        .OrderBy(new[] { "series.name" })
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

        public IEnumerable<TvSeries> List()
        {
            try
            {
                Logger.Trace("Begin -> List");

                using (IGraphClient client = DatabaseFactory.CreateReader())
                {
                    IEnumerable<TvSeries> results = client.Cypher
                        .Match("(series:TvSeries)")
                        .Return(series => series.As<TvSeries>())
                        .OrderBy(new[] { "series.name" })
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

        public IEnumerable<Character> ListCharactersInSeason(int season)
        {
            try
            {
                Logger.Trace("Begin -> ListCharactersInSeries");
                Logger.DebugFormat("Parameters [season={0}]", season);

                using (IGraphClient client = DatabaseFactory.CreateReader())
                {
                    IEnumerable<Character> results = client.Cypher
                        .Match("(series:TvSeries {name: {name} })-[APPEAREDIN]-(character:Character)")
                        .WithParams(new Dictionary<string, object>
                        {
                            {"name", string.Format("Season {0}", season)}
                        })
                        .Return(character => character.As<Character>())
                        .OrderBy(new[] { "character.name" })
                        .Results;

                    Logger.Trace("End -> ListCharactersInSeries");
                    return results;
                }
            }
            catch (Exception err)
            {
                Logger.Error("Error in ListCharactersInSeries", err);
                throw;
            }
        }
    }
}
