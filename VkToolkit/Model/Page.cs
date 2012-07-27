using System;

namespace VkToolkit.Model
{
    public class Page
    {
        public long? Id { get; set; }
        public long? GroupId { get; set; }
        public long? CreatorId { get; set; }
        public string Title { get; set; }
        public string Source { get; set; }
        public bool? CurrentUserCanEdit { get; set; }
        public bool? CurrentUserCanEditAccess { get; set; }

        public int? WhoCanView { get; set; } // todo int -> enum
        public int? WhoCanEdit { get; set; } // todo int -> enum
        public long? EditorId { get; set; }
        public DateTime? Edited { get; set; }
        public DateTime? Created { get; set; }
        public string Parent { get; set; }
        public string Parent2 { get; set; }
    }
}