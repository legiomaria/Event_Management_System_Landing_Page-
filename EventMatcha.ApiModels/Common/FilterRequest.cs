
namespace EventMatcha.ApiModels.Common
{
    public class FilterRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool IsDeleted { get; set; }
    }
}
