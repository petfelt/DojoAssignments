using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class dataType{
        public dataType (string name) {
            Name = name;

        }
        public string Name {get; set;}
    }
    public class Program
    {
        
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            
            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            Artist mtVernon = Artists.Where(artist => artist.Hometown == "Mount Vernon").Single();
            Console.WriteLine("Name: " + mtVernon.ArtistName + ",  Age: " + mtVernon.Age + " years old.");
            //Who is the youngest artist in our collection of artists?
            Artist youngest = Artists.OrderBy(artist => artist.Age).First();
            Console.WriteLine("Name: " + youngest.ArtistName + ",  Age: " + youngest.Age + " years old.");

            //Display all artists with 'William' somewhere in their real name
            List<Artist> william = Artists.Where(artist => artist.RealName.Contains("William")).ToList();
            foreach(Artist item in william){
                Console.WriteLine("Real Name: " + item.RealName + ",  Artist Name: " + item.ArtistName);
            }
            //Display the 3 oldest artist from Atlanta
            List<Artist> oldest = Artists.OrderByDescending(artist => artist.Age).Take(3).ToList();
            foreach(Artist artist in oldest){
                Console.WriteLine("Name: " + artist.ArtistName + ",  Artist Age: " + artist.Age + " years old.");
            }
            // Display artist groups with less than 8 characters in their name
            List<Group> eight_char = Groups.Where(group => group.GroupName.Length < 8).ToList();
            foreach(Group group in eight_char){
                Console.WriteLine("Group Name: " + group.GroupName);
            }

            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            var not_ny = (from item1 in Groups
            join item2 in Artists 
            on item1.Id equals item2.GroupId
            where(item2.Hometown == "New York City")
            group item1 by item1.GroupName into g
            select new dataType(g.Key));
            System.Console.WriteLine();
            foreach(dataType o in not_ny){
                Console.WriteLine("Group Name: " + o.Name);
            }

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            Console.WriteLine();
            Console.WriteLine("Wu-Tang Clan Members:");
            var wutang = (from item1 in Groups
            join item2 in Artists
            on item1.Id equals item2.GroupId
            where(item1.GroupName=="Wu-Tang Clan")
            group item2 by item2.ArtistName into g
            select new dataType(g.Key)
            );
            foreach(dataType o in wutang){
                Console.WriteLine("Name: "+o.Name);
            }
        }
    }
}
