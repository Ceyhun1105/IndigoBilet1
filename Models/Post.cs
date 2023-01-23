using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndigoBilet1.Models
{
    public class Post
    {
        public int Id { get; set; }
        [StringLength(maximumLength:200)]
        public string? Imageurl{ get; set; }
        [StringLength(maximumLength: 100)]
        public string Title { get; set; }
        [StringLength(maximumLength: 1500)]
        public string Description { get; set; }
        [StringLength(maximumLength: 200)]
        public string LearnMoreurl { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
