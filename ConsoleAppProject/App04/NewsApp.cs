using System;
using System.Collections.Generic;
using System.Text;

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
            "Unlike A Post"
        };

        public void Run()
        {
            AddMessgae();

        }

        private void AddMessgae()
        {
            Console.Write(" Please enter your name > ");
            string name = Console.ReadLine();

            Console.Write(" Please enter your name > ");
            string message = Console.ReadLine();

            MessagePost post = new MessagePost(name, message);
            NewsList.AddPost(post);
        }
    }
}
