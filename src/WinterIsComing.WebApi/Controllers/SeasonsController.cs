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
    public class SeasonsController : AbstractApiController
    {
        private ITvSeriesRepository _tvSeriesRepository;

        public SeasonsController(ITvSeriesRepository tvSeriesRepository)
            : base()
        {
            _tvSeriesRepository = tvSeriesRepository;
        }

        public SeasonsController() : this(new TvSeriesRepository())
        {

        }

        /// <summary>
        /// Returns a list of the Television Seasons
        /// </summary>
        /// <returns>Enumerable of Season</returns>
        [HttpGet]
        public IEnumerable<TvSeriesModel> List()
        {
            try
            {
                Logger.Trace("Begin => List");
                IEnumerable<TvSeries> results = _tvSeriesRepository.List();

                if (results == null)
                {
                    Logger.Debug("No Television Seasons found");
                    throw new HttpResponseException(HttpStatusCode.NoContent);
                }

                return results.Select(t => TvSeriesModel.CopyFrom(t));
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
