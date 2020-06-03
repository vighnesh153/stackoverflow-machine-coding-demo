using System;

using Core.Users;

namespace Core.FlagUtil
{
    public class Flag
    {
        private readonly User flaggedBy;

        public string Id { get; }
        public FlagType Type { get; }
        public string ReferenceLink { get; private set; }
        public string MoreInfo { get; private set; }
        public bool IsApproved { get; private set; } = false;
        public Moderator ApprovedBy { get; private set; } = null;

        public Flag(User flaggedBy, FlagType type)
        {
            Id = Guid.NewGuid().ToString();
            this.flaggedBy = flaggedBy;
            Type = type;
        }

        public void ModeratorApproval(Moderator moderator)
        {
            IsApproved = true;
            ApprovedBy = moderator;
        }

        public string GetFlagRaiser()
        {
            return flaggedBy.Email;
        }

        public Flag SetReferenceLink(string value)
        {
            ReferenceLink = value;
            return this;
        }

        public Flag SetMoreInfo(string value)
        {
            MoreInfo = value;
            return this;
        }
    }
}
