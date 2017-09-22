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
    /// Cultures API Returns information on the Cultures present
    /// </summary>
    public class CulturesController : AbstractApiController
    {
        private ICultureRepository _cultureRepository;

        public CulturesController(ICultureRepository cultureRepository)
            : base()
        {
            _cultureRepository = cultureRepository;
        }

        public CulturesController() : this(new CultureRepository())
        {

        }

        /// <summary>
        /// Returns a list of the Cultures
        /// </summary>
        /// <returns>Enumerable of Cultures</returns>
        [HttpGet]
        public IEnumerable<string> List()
        {
            try
            {
                Logger.Trace("Begin => List");
                IEnumerable<Culture> results = _cultureRepository.List();

                if (results == null)
                {
                    Logger.Debug("No books found");
                    throw new HttpResponseException(HttpStatusCode.NoContent);
                }

                return results.Select(t => t.Name);
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
