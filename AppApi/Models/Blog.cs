namespace AppApi.Models
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public byte[] Image { get; set; }
    }
}
