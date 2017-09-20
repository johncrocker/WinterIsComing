using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4jClient;

namespace WinterIsComing.Data.Interfaces
{
    public interface IGraphDatabaseFactory
    {
        IGraphClient CreateReader();

        IGraphClient CreateWriter();

        IGraphClient Create(Uri host, string username, string password, bool isWriter);
    }
}
