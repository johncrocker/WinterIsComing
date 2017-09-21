using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WinterIsComing.Data.Models;

namespace WinterIsComing.WebApi.Models
{
    /// <summary>
    /// Represents a Book
    /// </summary>
    public class BookModel
    {
        /// <summary>
        /// Identifier of Book
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Published Country
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        /// <summary>
        /// Number of pages
        /// </summary>
        [JsonProperty(PropertyName = "pages")]
        public Int16 Pages { get; set; }

        /// <summary>
        /// ISBN number
        /// </summary>
        [JsonProperty(PropertyName = "ISBN")]
        public string ISBN { get; set; }

        /// <summary>
        /// Publish date
        /// </summary>
        [JsonProperty(PropertyName = "releaseDate")]
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Title of book
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Publisher of book
        /// </summary>
        [JsonProperty(PropertyName = "publisher")]
        public string Publisher { get; set; }

        /// <summary>
        /// Authors of book
        /// </summary>
        [JsonProperty(PropertyName = "authors")]
        public IEnumerable<string> Authors { get; set; }


        /// <summary>
        /// Converts the given Book into a BookModel
        /// </summary>
        /// <param name="book">Source Book</param>
        /// <returns>BookModel of Book</returns>
        public static BookModel CopyFrom(Book book)
        {
            return new BookModel()
            {
                Authors = book.Authors,
                Country = book.Country,
                Id = book.Id,
                ISBN = book.ISBN,
                Name = book.Name,
                Pages = book.Pages,
                Publisher = book.Publisher,
                ReleaseDate = book.ReleaseDate
            };
        }
    }
}