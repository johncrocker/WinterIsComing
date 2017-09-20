using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Data.Factories;
using WinterIsComing.Data.Interfaces;
using WinterIsComing.Data.Models;

namespace WinterIsComing.Data.Repositories
{
    public class BookRepository : AbstractRepository, IBookRepository
    {

        public Book Get(int id)
        {
            return null;
        }

        public IList<Book> List()
        {
            return null;
        }
    }
}
