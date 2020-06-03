using System;
using System.Collections.Generic;

using Core.Users;
using Core.FlagUtil;

namespace Core.Posts
{
    public abstract class Post: IVotable
    {
        protected readonly User addedBy;
        protected readonly HashSet<User> upVotedBy;
        protected readonly HashSet<User> downVotedBy;
        protected List<Flag> flags;

        public string Id { get; }
        public bool IsDeleted { get; private set; } = false;
        public string Content { get; private set; }

        protected Post(User user, string content)
        {
            Id = Guid.NewGuid().ToString();

            addedBy = user;
            Content = content;
            upVotedBy = new HashSet<User>();
            downVotedBy = new HashSet<User>();
            flags = new List<Flag>();
        }

        public string Creator() => addedBy.Email;

        public void UpdateContent(string value) => Content = value;

        public void MarkAsDeleted() => IsDeleted = true;

        public void MarkAsNotDeleted() => IsDeleted = true;

        public void AddFlag(Flag flag) => flags.Add(flag);

        public void Upvote(User user)
        {
            RemoveDownvote(user);
            upVotedBy.Add(user);
        }

        public void RemoveUpvote(User user)
        {
            upVotedBy.Remove(user);
        }

        public void Downvote(User user)
        {
            RemoveUpvote(user);
            downVotedBy.Add(user);
        }

        public void RemoveDownvote(User user)
        {
            downVotedBy.Remove(user);
        }
    }
}
