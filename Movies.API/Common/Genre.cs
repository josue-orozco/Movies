using System.Text.Json.Serialization;

namespace Movies.API.Common
{
    /// <summary>
    /// Film genres used by IMDB to stylistically or thematically categorize movies.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Genre
    {
        Crime,
        Drama,
        Biography,
        History,
        Sport,
        War,
        Romance,
        Mystery,
        Adventure,
        Family,
        Fantasy,
        Thriller,
        Horror,
        Musical,
        Action,
        SciFi,
        Comedy
    }
}
