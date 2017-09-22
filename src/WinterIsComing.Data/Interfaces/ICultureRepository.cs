using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Data.Models;

namespace WinterIsComing.Data.Interfaces
{
    public interface ICultureRepository
    {
        IEnumerable<Culture> List();

        IEnumerable<Character> ListCharactersInCulture(string name);
    }
}
