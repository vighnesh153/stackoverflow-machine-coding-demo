using Core.Users;

namespace Core.Posts
{
    public interface IVotable
    {
        void Upvote(User user);
        void RemoveUpvote(User user);
        void Downvote(User user);
        void RemoveDownvote(User user);
    }
}
