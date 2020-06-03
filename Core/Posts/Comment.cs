using Core.Users;

namespace Core.Posts
{
    public class Comment : Post
    {
        public Comment(User user, string content): base(user, content)
        {

        }
    }
}
