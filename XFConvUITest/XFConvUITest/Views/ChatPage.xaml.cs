using System.Collections.Specialized;
using Telerik.XamarinForms.ConversationalUI;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFConvUITest.Services;

namespace XFConvUITest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        private RepeatBotService botService;
        private Author botAuthor;

        public ChatPage()
        {
            InitializeComponent();

            botService = new RepeatBotService();
            //botService.AttachOnReceiveMessage(OnBotMessageReceived);
            botAuthor = new Author { Name = "botty" };

            //((INotifyCollectionChanged)this.chat.Items).CollectionChanged += ChatPage_CollectionChanged;
        }

        private void ChatPage_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                TextMessage chatMessage = (TextMessage)e.NewItems[0];
                if (chatMessage.Author == chat.Author)
                {
                    this.botService.SendToBot(chatMessage.Text);
                }
            }
        }

        private void OnBotMessageReceived(string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                TextMessage textMessage = new TextMessage();
                textMessage.Data = message;
                textMessage.Author = this.botAuthor;
                textMessage.Text = message;
                chat.Items.Add(textMessage);
            });
        }
    }
}