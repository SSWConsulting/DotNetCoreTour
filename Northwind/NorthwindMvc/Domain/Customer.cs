using System.ComponentModel.DataAnnotations;

namespace NorthwindMvc.Domain
{
    public partial class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [MaxLength(24)]
        public string Phone { get; set; }

        [MaxLength(255)]
        public string Website { get; set; }
    }
}
