namespace MutliShop.Comment.Entites
{
    public class UserComment
    {
        public int UserCommentId { get; set; }
        public string NameSurname { get; set; }
        public string? ImageUrl { get; set; }
        public string Email { get; set; }
        public string CommentDetail { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool status { get; set; }
        public string ProductId { get; set; }
    }
}
