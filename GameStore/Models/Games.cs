using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace GameStore.Models
{
    public class Games
    {
        public string ID { get; set; }
        public string? Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
        public decimal Price { get; set; }

        public Games()
        {
            this.ID = Guid.NewGuid().ToString();
        }
    }
}
