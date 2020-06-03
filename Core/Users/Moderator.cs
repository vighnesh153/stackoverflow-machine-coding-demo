using Core.Posts;

namespace Core.Users
{
    public class Moderator: User
    {
        public Moderator(string username, string email) : base(username, email) { }

        public void CloseQuestion(Question question)
        {
            question.Close();
        }

        public void UnDeleteQuestion(Question question)
        {
            question.MarkAsNotDeleted();
        }
    }
}
