using System;
using Telerik.XamarinForms.ConversationalUI;

namespace XFConvUITest.Models
{
    public class SimpleChatItem
    {
        public Author Author { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
