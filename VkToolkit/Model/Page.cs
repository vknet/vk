using System;

using VkToolkit.Utils;

namespace VkToolkit.Model
{
    public class Page
    {
        public long? Id { get; set; }
        public long? GroupId { get; set; }
        public long? CreatorId { get; set; }
        public string Title { get; set; }
        public string Source { get; set; }
        public bool CurrentUserCanEdit { get; set; }
        public bool CurrentUserCanEditAccess { get; set; }

        public int? WhoCanView { get; set; } // TODO: int -> enum
        public int? WhoCanEdit { get; set; } // TODO: int -> enum
        public long? EditorId { get; set; }
        public DateTime? Edited { get; set; }
        public DateTime? Created { get; set; }
        public string Parent { get; set; }
        public string Parent2 { get; set; }

        internal static Page FromJson(VkResponse page)
        {
            var result = new Page();

            result.Id = page["pid"];
            result.GroupId = page["group_id"];
            result.CreatorId = page["creator_id"];
            result.Title = page["title"];
            result.Source = page["source"];
            result.CurrentUserCanEdit = page["current_user_can_edit"];
            result.CurrentUserCanEditAccess = page["current_user_can_edit_access"];
            result.WhoCanView = page["who_can_view"];
            result.WhoCanEdit = page["who_can_edit"];
            result.EditorId = page["editor_id"];
            result.Parent = page["parent"];
            result.Parent2 = page["parent2"];
            result.Edited = page["edited"];
            result.Created = page["created"];

            return result;            
        }       
    }
}