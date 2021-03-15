using System.ComponentModel.DataAnnotations;

namespace Timewaster.Web.ViewModels
{
    public class IssueViewModel
    {
        public int? Id { get; set; }
        public string PartitionKey { get; set; }
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
        [MaxLength(450)]
        public string Description { get; set; }
        [Required]
        public int StoryId { get; set; }
        [Required]
        public int StatusId { get; set; }
        [Required]
        public int SprintId { get; set; }

    }
}
