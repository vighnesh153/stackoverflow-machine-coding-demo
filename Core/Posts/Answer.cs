using System;
using System.Collections.Generic;

using Core.Users;

namespace Core.Posts
{
    public class Answer : Post, ICommentable
    {
        private readonly List<Comment> comments;
        public bool IsAccepted { get; private set; }

        public Answer(User creator, string content) : base(creator, content)
        {
            comments = new List<Comment>();
        }

        public void MarkAsAccepted(int points) 
        {
            IsAccepted = true;
            addedBy.AwardPoints(points);
        }

        public IReadOnlyCollection<Comment> GetComments()
        {
            return comments.AsReadOnly();
        }

        public void AddComment(Comment comment)
        {
            comments.Add(comment);
        }

        public void DeleteComment(string id)
        {
            foreach (var comment in comments)
            {
                if (comment.Id == id)
                    comment.MarkAsDeleted();
            }
        }
    }
}
