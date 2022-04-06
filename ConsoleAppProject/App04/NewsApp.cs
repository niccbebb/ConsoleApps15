using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App04
{
    public class NewsApp
    {
        public NewsList NewsList { get; set; } = new NewsList();

        string[] choices =
        {
            "Add a Messgae Post",
            "Add a Photo Post",
            "Display All Post",
            "Remove A Post",
            "Add Comments to s post",
            "Like A Post",
            "Unlike A Post",
            "Quit A Post"
        };

        public void Run()
        {
            MessagePost message = new MessagePost("nicole", "hello");
            NewsList.AddPost(message);

            bool quit = false;
            while (!quit)
                {
                    int choice = ConsoleHelper.SelectChoice(choices);
                    if (choice == 1)
                    {
                        AddMessgae();
                    }
                    else if (choice == 2)
                    {
                        AddPhoto();
                    }
                    else if (choice == 3)
                    {
                        DisplayPosts();
                    }
                }
        }

        private void DisplayPosts()
        {
            NewsList.Display();
        }

        private void AddPhoto()
        {
            throw new NotImplementedException();
        }

        private void AddMessgae()
        {
            Console.Write(" Please enter your name > ");
            string name = Console.ReadLine();

            Console.Write(" Please enter your message > ");
            string message = Console.ReadLine();

            MessagePost post = new MessagePost(name, message);
            NewsList.AddPost(post);
        }
    }
}
