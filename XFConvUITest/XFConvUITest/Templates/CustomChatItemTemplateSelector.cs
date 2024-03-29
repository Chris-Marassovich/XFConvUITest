﻿using Telerik.XamarinForms.ConversationalUI;
using Xamarin.Forms;
using XFConvUITest.Models;

namespace XFConvUITest.Templates
{
    public class CustomChatItemTemplateSelector : ChatItemTemplateSelector
    {
        public DataTemplate MeMessageTemplate { get; set; }
        public DataTemplate OtherMessageTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            ChatItem chatItem = item as ChatItem;
            var myItem = chatItem?.Data as SimpleChatItem;
            if (myItem != null)
            {
                if (myItem.Author.Name == "Chris")
                    return MeMessageTemplate;
                else
                    return OtherMessageTemplate;
            }
            return base.OnSelectTemplate(item, container);
        }
    }
}
