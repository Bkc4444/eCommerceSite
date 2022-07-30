using System.ComponentModel.DataAnnotations;

namespace eCommerceSite.Models
{
    /// <summary>
    /// Represents a single song for purchase
    /// </summary>
    public class Music
    {
        /// <summary>
        /// The unique identifier for each song for sale
        /// </summary>
        [Key]// type this and go to the light bulb and select the using
        public int MusicID { get; set; }

        /// <summary>
        /// The official title of the song
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// The sales price
        /// </summary>
        [Range(0, 2_000_000)]
        public double Price { get; set; }

        // Todo: Add genre
    }
}
