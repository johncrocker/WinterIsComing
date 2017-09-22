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
    public class CultureController : AbstractApiController
    {
        private ICultureRepository _cultureRepository;

        public CultureController(ICultureRepository cultureRepository)
            : base()
        {
            _cultureRepository = cultureRepository;
        }

        public CultureController() : this(new CultureRepository())
        {

        }

        /// <summary>
        /// Returns a list of characters in the given culture
        /// </summary>
        /// <param name="name">Culture name</param>
        /// <returns>Book</returns>
        [HttpGet]
        [ActionName("Characters")]
        public IEnumerable<CharacterModel> ListCharactersInCulture(string name)
        {
            try
            {
                Logger.Trace("Begin => ListCharactersInCulture");
                Logger.DebugFormat("Parameters [name={0}]", name);

                IEnumerable<Character> results = _cultureRepository.ListCharactersInCulture(name);

                if (results == null)
                {
                    Logger.DebugFormat("Culture name={0} not found", name);
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                return results.Select(t => CharacterModel.CopyFrom(t));
            }
            catch (Exception err)
            {
                Logger.Error("Error in ListCharactersInCulture", err);
                throw;
            }
            finally
            {
                Logger.Trace("End => ListCharactersInCulture");
            }
        }
    }
}
