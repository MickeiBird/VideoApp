using System;
using System.Collections.Generic;
using VideoAppBLL;

namespace VideoAppUI
{
    class Program
    {
        static BLLFacade bllFacade = new BLLFacade();
        static void Main(string[] args)
        {
            string[] menuItems = {
                "List of all videos",
                "Add video",
                "Delete video",
                "Edit video",
                "Exit"
            };


            var selection = Menu(menuItems);

            while (selection != 5)
            {
                switch (selection)
                {
                    case 1:
                        Console.WriteLine("\nShowing list of all videos...\n");
                        ListVideos(videoList);
                        break;
                    case 2:
                        Console.WriteLine("\nAdd videos...\n");


                        AddVideo(videoList);
                        break;
                    case 3:
                        Console.WriteLine("Delete video...");
                        DeleteVideo(videoList);
                        break;
                    case 4:
                        Console.WriteLine("Edit video...");
                        EditVideo(videoList);

                        break;
                    case 5:
                        Console.WriteLine("Exiting...");
                        break;
                }

                Console.WriteLine("------------------------------------");
                Console.WriteLine("Press enter to select another option");
                Console.ReadLine();

                selection = Menu(menuItems);
            }


            Console.ReadLine();
        }

        private static void EditVideo(List<Video> videoList)
        {
            int selected;
            string tempName;
            foreach (var video in videoList)
            {
                Console.WriteLine(video.Id + " : " + video.Name);

            }

            Console.Write("\nChoose the video to edit : ");

            while (!int.TryParse(Console.ReadLine(), out selected) || selected < videoList[0].Id || selected > videoList.Count)
            {
                Console.WriteLine("You need to select a number from {0}-{1}", videoList[0].Id, videoList.Count);
            }

            Console.WriteLine("Please Write the new name of the video");
            tempName = videoList[selected - 1].Name;
            videoList[selected - 1].Name = videoList[selected - 1].Name.Replace(videoList[selected - 1].Name, Console.ReadLine());
            Console.WriteLine("\nThe video named : '{0}', was changed to : '{1}'", tempName, videoList[selected - 1].Name);
        }

        private static int Menu(string[] menuItems)
        {
            int selection;
            Console.Clear();
            Console.WriteLine("Select what you want to do: \n");
            Console.WriteLine("---------------------------\n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{i + 1} : {menuItems[i]} \n");
            }

            while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > 5)
            {
                Console.WriteLine("You need to select a number from 1-5");
            }

            Console.WriteLine("\nSelection : " + selection);
            return selection;
        }

        private static List<Video> AddVideo(List<Video> videoList)
        {
            string name;
            string genre;
            int year;
            Video video = new Video();
            Console.Write("Please type the name of the video : ");
            name = Console.ReadLine();
            video.Name = name;
            Console.Write("\nWhat genre does this video belong in? : ");
            genre = Console.ReadLine();
            video.Genre = genre;
            Console.Write("\nWhat year is it from? : ");
            year = Convert.ToInt32(Console.ReadLine());
            video.Year = year;

            videoList.Add(video);
            for (int i = 0; i < videoList.Count; i++)
            {
                if (!video.Id.Equals(i + 1))
                {

                    videoList[i].Id = i + 1;

                }
            }
            Console.WriteLine("\n{0} was added to videos\n ", name);
            return videoList;
        }

        private static void ListVideos(List<Video> videoes)
        {
            int counter = 1;
            int selection;
            foreach (var video in videoes)
            {
                Console.WriteLine(video.Id + " : " + video.Name + "\n" + "Genre - " + video.Genre + " : " + "Year - " + video.Year +
                    "\n-------------------------------------");
            }

            Console.WriteLine("Do you want to search for videoes?");
            Console.WriteLine("\n1 - Yes \n2 - No");

            while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > 2)
            {
                Console.WriteLine("You need to select either 1 or 2");
            }
            if (selection == 1)
            {

                Console.Write("\nWrite a word to search for : ");
                var namePlaceHolder = Console.ReadLine();


                foreach (var video in videoes)
                {
                    var matchingName = videoes.Where(x => x.Name.Contains(namePlaceHolder));

                    if (video.Name.Contains(namePlaceHolder) || video.Genre.Contains(namePlaceHolder))
                    {
                        Console.WriteLine(counter + " : " + video.Name);
                        counter++;
                    }
                }
                Console.ReadLine();
            }
        }

        private static void DeleteVideo(List<Video> videoes)
        {
            int selected;
            Console.WriteLine("What video do you whant to delete?");
            for (int i = 0; i < videoes.Count; i++)
            {
                Console.WriteLine((i + 1) + " : " + videoes[i].Name);
            }
            Console.Write("\nType the number of the video you want to delete : ");
            while (!int.TryParse(Console.ReadLine(), out selected) || selected < videoes[0].Id || selected > videoes.Count)
            {
                Console.WriteLine("You need to select a number from {0}-{1}", videoes[0].Id, videoes.Count);
            }

            videoes.RemoveAt(selected - 1);
        }
    }
}