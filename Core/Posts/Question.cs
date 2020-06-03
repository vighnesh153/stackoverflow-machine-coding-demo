using System;
using System.Linq;
using System.Collections.Generic;

using Core.Users;

namespace Core.Posts
{
    public class Question: Post, ICommentable
    {
        private readonly List<Answer> answers;
        private readonly List<Comment> comments;
        private readonly HashSet<string> tags;
        
        public string Title { get; private set; }
        public int Bounty { get; private set; } = 0;
        public bool IsClosed { get; private set; } = false;

        public Question(User creator, string title, string content): base(creator, content)
        {
            answers = new List<Answer>();
            comments = new List<Comment>();
            tags = new HashSet<string>();

            Title = title;
        }

        public void UpdateTitle(string value) => Title = value;

        public void Close() => IsClosed = true;

        public void AddBounty(int amount) => Bounty += amount;

        public void AcceptAnswer(User user, string answerId)
        {
            if (Creator() != user.Email)
                return;

            Answer answerToBeAccepted = null;
            foreach(var answer in answers)
            {
                if (answer.IsAccepted)
                {
                    throw new Exception("This question already has an accepted answer.");
                }
                if (answer.Id == answerId)
                {
                    answerToBeAccepted = answer;
                }
            }

            if (answerToBeAccepted != null)
            {
                answerToBeAccepted.MarkAsAccepted(Bounty);
                Bounty = 0;
            }
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

        public IReadOnlyCollection<Answer> GetAnswers()
        {
            return answers.AsReadOnly();
        }

        public void AddAnswer(Answer newAnswer)
        {
            foreach (var answer in answers)
            {
                if (answer.Creator() == newAnswer.Creator())
                {
                    throw new Exception("User already has answered this question.");
                }
            }
            answers.Add(newAnswer);
        }

        public void DeleteAnswer(string id)
        {
            foreach(var answer in answers)
            {
                if (answer.Id == id)
                {
                    answer.MarkAsDeleted();
                }
            }
        }

        public void UpdateAnswer(string userEmail, string answerId, string content)
        {
            foreach (var answer in answers)
            {
                if (answer.Id != answerId)
                    continue;

                if (answer.Creator() != userEmail)
                    throw new Exception("Unauthorized user.");

                answer.UpdateContent(content);
            }
        }

        public IEnumerable<string> GetTags()
        {
            return tags.AsEnumerable();
        }

        public void AddTag(string tag)
        {
            tags.Add(tag);
        }

        public void RemoveTag(string tag)
        {
            tags.Remove(tag);
        }
    }
}
