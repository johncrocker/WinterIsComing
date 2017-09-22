using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4jClient;
using WinterIsComing.Data.Models;

namespace WinterIsComing.Data.Interfaces
{
    public interface ITvSeriesRepository
    {
        TvSeries Get(int season);

        IEnumerable<TvSeries> List();

        IEnumerable<Character> ListCharactersInSeason(int season);
    }
}
