using Telerik.XamarinForms.ConversationalUI;
using XFConvUITest.Models;
using XFConvUITest.ViewModels;

namespace XFConvUITest.Converters
{
    public class SimpleChatItemConverter : IChatItemConverter
    {
        public ChatItem ConvertToChatItem(object dataItem, ChatItemConverterContext context)
        {
            SimpleChatItem item = (SimpleChatItem)dataItem;
            if (item.Author == null)
            {
                TimeBreak timeBreak = new TimeBreak()
                {
                    Text = "Unread"
                };
                return timeBreak;
            }
            else
            {
                TextMessage textMessage = new TextMessage()
                {
                    Data = dataItem,
                    Author = item.Author,
                    Text = item.Text
                };
                return textMessage;
            }
        }

        public object ConvertToDataItem(object message, ChatItemConverterContext context)
        {
            ChatViewModel vm = (ChatViewModel)context.Chat.BindingContext;
            return new SimpleChatItem { Author = vm.Me, Text = (string)message, };
            //return null;
        }
    }
}
