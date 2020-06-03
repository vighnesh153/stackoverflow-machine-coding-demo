using System.Collections.Generic;

using Core.FlagUtil;
using Core.Posts;

namespace Core.Users
{
    public abstract class User
    {
        public string Username { get; }
        public string Email { get; }
        public int Reputation { get; private set; } = 0;
        
        protected HashSet<Badge> Badges;
        public User(string username, string email)
        {
            Username = username;
            Email = email;

            Badges = new HashSet<Badge>();
        }

        public void AwardPoints(int amount) => Reputation += amount;

        public void AddQuestion(Question question)
        {
            Badges.Add(Badge.Student);
            AppManager.Instance.AddQuestion(question);
        }

        public void AddBounty(Question question, int bounty)
        {
            question.AddBounty(bounty);
        }

        public void AddAnswer(Question question, Answer answer)
        {
            Badges.Add(Badge.Teacher);
            question.AddAnswer(answer);
        }

        public void AddComment(ICommentable commentable, Comment comment)
        {
            commentable.AddComment(comment);
        }

        public void Upvote(IVotable votable)
        {
            Badges.Add(Badge.Supporter);
            votable.Upvote(this);
        }

        public void RemoveUpvote(IVotable votable)
        {
            votable.RemoveUpvote(this);
        }

        public void Downvote(IVotable votable)
        {
            Badges.Add(Badge.Critic);
            votable.Downvote(this);
        }

        public void RemoveDownvote(IVotable votable)
        {
            votable.RemoveDownvote(this);
        }

        public void AddFlag(IFlagable flagable, Flag flag)
        {
            flagable.AddFlag(flag);
        }

        public void AddTag(Question question, string tag)
        {
            question.AddTag(tag);
        }
    }
}
