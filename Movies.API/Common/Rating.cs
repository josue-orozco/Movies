using System.Text.Json.Serialization;

namespace Movies.API.Common
{
    /// <summary>
    /// The Motion Picture Association film rating system used to rate a movies suitability for certain audiences based on its content.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Rating
    {
        /// <summary>
        /// General audiences – All ages admitted.
        /// </summary>
        G,
        /// <summary>
        /// Parental guidance suggested – Some material may not be suitable for children.
        /// </summary>
        PG,
        /// <summary>
        ///  Parents strongly cautioned – Some material may be inappropriate for children under 13.
        /// </summary>
        PG13,
        /// <summary>
        /// Restricted – Under 17 requires accompanying parent or adult guardian.
        /// </summary>
        R,
        /// <summary>
        /// Adults Only – No one under 17 admitted.
        /// </summary>
        X
    }
}
