using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Data.Models;

namespace WinterIsComing.Data.Interfaces
{
    public interface IBookRepository
    {
        Book Get(int id);

        IList<Book> List();

    }
}
