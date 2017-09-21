using Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WinterIsComing.WebApi.Services
{
    public abstract class AbstractApiController : ApiController
    {
        protected ILog Logger;

        public AbstractApiController()
        {
            Logger = LogManager.GetLogger(GetType());
        }
    }
}