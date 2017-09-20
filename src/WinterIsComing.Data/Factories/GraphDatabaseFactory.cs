using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Data.Interfaces;
using Neo4jClient;
using System.Configuration;
using Common.Logging;

namespace WinterIsComing.Data.Factories
{
    public class GraphDatabaseFactory : IGraphDatabaseFactory
    {
        private static GraphClient _readerClient;
        private static GraphClient _writerClient;
        private static readonly object _lock = new object();
        private ILog _logger;

        public GraphDatabaseFactory()
        {
            _logger = LogManager.GetLogger(GetType());
        }

        public IGraphClient CreateReader()
        {
            return Create(new Uri(ConfigurationManager.AppSettings["Neo4jReaderUrl"]),
                ConfigurationManager.AppSettings["UserName"], ConfigurationManager.AppSettings["Password"], false);
        }

        public IGraphClient CreateWriter()
        {
            return Create(new Uri(ConfigurationManager.AppSettings["Neo4jWriterUrl"]),
                ConfigurationManager.AppSettings["UserName"], ConfigurationManager.AppSettings["Password"], true);
        }

        public IGraphClient Create(Uri host, string username, string password, bool isWriter)
        {

            _logger.Trace("Begin => Create");

            try
            {
                lock (_lock)
                {
                    _logger.DebugFormat("Create Parameters [host={0}, username={1}, isWriter={2}]", host.ToString(), username,
                        isWriter);

                    if (isWriter)
                    {
                        if (_writerClient == null)
                            _writerClient = new GraphClient(host, username, password);

                        if (!_writerClient.IsConnected)
                            _writerClient.Connect();

                        return _writerClient;
                    }

                    if (_readerClient == null)
                        _readerClient = new GraphClient(host, username, password);

                    if (!_readerClient.IsConnected)
                        _readerClient.Connect();

                    return _readerClient;
                }
            }
            catch (Exception err)
            {
                _logger.Error("Error creating connection", err);
                _logger.Trace("End => Create");
                throw;
            }
            finally
            {
                _logger.Trace("End => Create");
            }

        }
    }
}
