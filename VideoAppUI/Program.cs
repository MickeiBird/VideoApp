using System;
using System.Collections.Generic;
using System.Linq;
using VideoAppBLL;
using VideoAppEntity;

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
                        ListVideos();
                        break;
                    case 2:
                        Console.WriteLine("\nAdd videos...\n");
                        AddVideo();
                        break;
                    case 3:
                        Console.WriteLine("Delete video...");
                        DeleteVideo();
                        break;
                    case 4:
                        Console.WriteLine("Edit video...");
                        EditVideo();
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

        private static void EditVideo()
        {
            List<Video> videoes = bllFacade.VideoService.GetAll();

          
            Console.WriteLine("What video do you want to edit: ");
            for (int i = 0; i < videoes.Count; i++)
                {
                    Console.WriteLine((i + 1) + " : " + videoes[i].Name);
                }

            var video = FindVideoById();
            if (video != null)
            {
                Console.Write("\nName : ");
                video.Name = Console.ReadLine();
                Console.Write("\nGenre : ");
                video.Genre = Console.ReadLine();
                Console.Write("\nYear : ");
                video.Year = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Video not found");
            }
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

        private static void AddVideo()
        {
            Console.WriteLine("Name: ");
            var name = Console.ReadLine();

            Console.WriteLine("Genre: ");
            var genre = Console.ReadLine();

            Console.WriteLine("Year : ");
            var year = Convert.ToInt32(Console.ReadLine());

            bllFacade.VideoService.Create(new Video()
            {
           
                Name = name,
                Genre = genre,
                Year = year
                
            });
        }

        private static void ListVideos()
        {
            int anotherCounter = 1;
            int counter = 1;
            int selection;

            Console.WriteLine("\nList of videoes");
            foreach (var video in bllFacade.VideoService.GetAll())
            {
                Console.WriteLine(anotherCounter + " : " + video.Name + "\n" + "Genre - " + video.Genre + " : " + "Year - " + video.Year +
                     "\n-------------------------------------");
                anotherCounter++;
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


                foreach (var video in bllFacade.VideoService.GetAll())
                {
                    var matchingName = bllFacade.VideoService.GetAll().Where(x => x.Name.Contains(namePlaceHolder));

                    if (video.Name.Contains(namePlaceHolder) || video.Genre.Contains(namePlaceHolder))
                    {
                        Console.WriteLine(counter + " : " + video.Name);
                        counter++;
                    }
                }
                Console.ReadLine();
            }
        }

        private static Video FindVideoById()
        {


            Console.WriteLine("Insert video Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id)) 
            {
                Console.WriteLine("Please type a number");
            }
            return bllFacade.VideoService.Get(id);


        }

        private static void DeleteVideo()
        {
            List<Video> videoes = bllFacade.VideoService.GetAll();

           

            Console.WriteLine("What video do you whant to delete?");
            for (int i = 0; i < videoes.Count; i++)
            {
                Console.WriteLine((i + 1) + " : " + videoes[i].Name);
            }
            var videoFound = FindVideoById();
            if (videoFound != null)
            {
                bllFacade.VideoService.Delete(videoFound.Id);
            }

            var response = videoFound == null ?
                "Video not Found" : "Video was Deleted";
           
        }
    }
}