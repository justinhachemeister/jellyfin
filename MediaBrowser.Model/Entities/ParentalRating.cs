namespace MediaBrowser.Model.Entities
{
    /// <summary>
    /// Class ParentalRating
    /// </summary>
    public class ParentalRating
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value { get; set; }

        public ParentalRating()
        {

        }

        public ParentalRating(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}
