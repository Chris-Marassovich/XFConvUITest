using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Telerik.XamarinForms.ConversationalUI;
using Xamarin.Forms;
using XFConvUITest.Models;

namespace XFConvUITest.ViewModels
{
    public class ChatViewModel : BaseViewModel
    {
        public ChatViewModel()
        {
            Title = "Chat";
            Me = new Author { Name = "Chris" };
            Bot = new Author { Name = "Botty" };

            NewMessageCommand = new Command(NewMessageCommandExecute);

            GenData();
        }


        private void GenData()
        {
            Items = new ObservableCollection<SimpleChatItem>();
            Items.Add(new SimpleChatItem { Author = Me, Text = "First Message", DateCreated = DateTime.Now });

            for (int i = 0; i < 30; i++)
            {
                if ((i % 2) == 0)
                    Items.Add(new SimpleChatItem { Author = Me, Text = $"Message Number : {i.ToString()}", DateCreated = DateTime.Now.AddDays(i) });
                else
                    Items.Add(new SimpleChatItem { Author = Bot, Text = $"Message Number : {i.ToString()}", DateCreated = DateTime.Now.AddDays(i) });

            }
            Items.Add(new SimpleChatItem { Author = null }); //indicates a time break.
            Items.Add(new SimpleChatItem { Author = Me, Text = "Last Message", DateCreated = DateTime.Now });
        }

        private Author me;
        public Author Me
        {
            get { return me; }
            set { SetProperty(ref me, value); }
        }

        private Author bot;
        public Author Bot
        {
            get { return bot; }
            set { SetProperty(ref bot, value); }
        }

        public ObservableCollection<SimpleChatItem> Items { get; set; }

        public ICommand NewMessageCommand { get; set; }
        private void NewMessageCommandExecute(object obj)
        {
            //Items.Add(new SimpleChatItem { Author = Me, Text = (string)obj });
        }
    }
}
