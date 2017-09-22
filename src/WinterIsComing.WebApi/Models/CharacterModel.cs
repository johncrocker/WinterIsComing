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
    public class CharacterModel
    {
        /// <summary>
        /// Identifier of Character
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Character Aliases
        /// </summary>
        [JsonProperty(PropertyName = "aliases")]
        public IEnumerable<string> Aliases { get; set; }

        /// <summary>
        /// Character name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Character played by in TV Series
        /// </summary>
        [JsonProperty(PropertyName = "playedBy")]
        public IEnumerable<string> PlayedBy { get; set; }

        /// <summary>
        /// Character Titles
        /// </summary>
        [JsonProperty(PropertyName = "titles")]
        public IEnumerable<string> Titles { get; set; }


        /// <summary>
        /// Converts the given Character into a CharacterModel
        /// </summary>
        /// <param name="character">Source Character</param>
        /// <returns>ChracterModel of Character</returns>
        public static CharacterModel CopyFrom(Character character)
        {
            return new CharacterModel()
            {
                Aliases = character.Aliases,
                Id = character.Id,
                Name = character.Name,
                PlayedBy = character.PlayedBy,
                Titles = character.Titles
            };
        }
    }
}