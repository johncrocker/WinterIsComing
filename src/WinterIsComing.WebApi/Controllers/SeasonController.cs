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
    /// Television Season API Returns information about the Broadcast Television Seasons
    /// </summary>
    public class SeasonController : AbstractApiController
    {
        private ITvSeriesRepository _tvSeriesRepository;

        public SeasonController(ITvSeriesRepository tvSeriesRepository)
            : base()
        {
            _tvSeriesRepository = tvSeriesRepository;
        }

        public SeasonController() : this(new TvSeriesRepository())
        {

        }
    
        /// <summary>
        /// Returns the Television Season
        /// </summary>
        /// <param name="season">Season number</param>
        /// <returns>Season</returns>
        [HttpGet]
        [ActionName("Detail")]
        public TvSeriesModel Get(int season)
        {
            try
            {
                Logger.Trace("Begin => Get");
                Logger.DebugFormat("Parameters [season={0}]", season);

                TvSeries result = _tvSeriesRepository.Get(season);

                if (result == null)
                {
                    Logger.DebugFormat("Season season={0} not found", season);
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                return TvSeriesModel.CopyFrom(result);
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
        /// Returns a list of the characters in a Television Season
        /// </summary>
        /// <param name="season">Season</param>
        /// <returns>Enumerable of Character</returns>         
        [HttpGet]
        [ActionName("Characters")]
        public IEnumerable<CharacterModel> ListCharactersInSeason(int season)
        {
            try
            {
                Logger.Trace("Begin => ListCharactersInSeason");
                IEnumerable<Character> results = _tvSeriesRepository.ListCharactersInSeason(season);

                if (results == null)
                {
                    Logger.Debug("No Characters found for this Season");
                    throw new HttpResponseException(HttpStatusCode.NoContent);
                }

                return results.Select(t => CharacterModel.CopyFrom(t));
            }
            catch (Exception err)
            {
                Logger.Error("Error in ListCharactersInSeason", err);
                throw;
            }
            finally
            {
                Logger.Trace("End => ListCharactersInSeason");
            }
        }
    }
}
