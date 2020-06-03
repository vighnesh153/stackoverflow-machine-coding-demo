namespace Core.Posts
{
    public interface ICommentable
    {
        void AddComment(Comment comment);
        void DeleteComment(string id);
    }
}
