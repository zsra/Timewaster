using System.ComponentModel.DataAnnotations;

namespace Timewaster.Web.ViewModels
{
    public class StoryViewModel
    {
        public int? Id { get; set; }
        public string PartitionKey { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(450)]
        public string Description { get; set; }
        [Required]
        public int SprintId { get; set; }
    }
}
