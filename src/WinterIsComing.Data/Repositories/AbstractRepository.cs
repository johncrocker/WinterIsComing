using Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Data.Factories;
using WinterIsComing.Data.Interfaces;

namespace WinterIsComing.Data.Repositories
{
    public abstract class AbstractRepository
    {
        protected IGraphDatabaseFactory DatabaseFactory;
        protected ILog Logger;

        public AbstractRepository(IGraphDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            Logger = LogManager.GetLogger(GetType());
        }

        public AbstractRepository() : this(new GraphDatabaseFactory())
        {

        }
    }
}
