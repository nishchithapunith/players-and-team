using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentProject1
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int PlayerAge { get; set; }
    }

    public interface ITeam
    {
        void Add(Player player);
        void Remove(int playerId);
        Player GetPlayerById(int playerId);
        Player GetPlayerByName(string playerName);
        List<Player> GetAllPlayers();
    }

    public class OneDayTeam : ITeam
    {
        public static List<Player> oneDayTeam = new List<Player>();
        private const int TeamCapacity = 11;

        public OneDayTeam()
        {
            oneDayTeam.Capacity = TeamCapacity;
        }

        public void Add(Player player)
        {
            if (oneDayTeam.Count < TeamCapacity)
            {
                oneDayTeam.Add(player);
                Console.WriteLine("Player is added successfully");
            }
            else
            {
                Console.WriteLine("Team is already full. Cannot add more players.");
            }
        }

        public void Remove(int playerId)
        {
            Player playerToRemove = oneDayTeam.Find(p => p.PlayerId == playerId);
            if (playerToRemove != null)
            {
                oneDayTeam.Remove(playerToRemove);
                Console.WriteLine("Player is removed successfully");
            }
            else
            {
                Console.WriteLine("Player not found with given ID");
            }
        }

        public Player GetPlayerById(int playerId)
        {
            return oneDayTeam.Find(p => p.PlayerId == playerId);
        }

        public Player GetPlayerByName(string playerName)
        {
            return oneDayTeam.Find(p => p.PlayerName.Equals(playerName, StringComparison.OrdinalIgnoreCase));
        }

        public List<Player> GetAllPlayers()
        {
            return oneDayTeam;
        }
    }




    internal class Program
    {
        static void Main(string[] args)
        {
            OneDayTeam oneDayTeam = new OneDayTeam();

            string choice;
            do
            {
                Console.WriteLine("Enter 1: To Add Player 2: To Remove Player by Id 3: Get Player By Id 4: Get Player by Name 5: Get All Players");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter Player Id:");
                        int playerId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Player Name:");
                        string playerName = Console.ReadLine();
                        Console.WriteLine("Enter Player Age:");
                        int playerAge = int.Parse(Console.ReadLine());

                        Player newPlayer = new Player
                        {
                            PlayerId = playerId,
                            PlayerName = playerName,
                            PlayerAge = playerAge
                        };

                        oneDayTeam.Add(newPlayer);
                        break;

                    case 2:
                        Console.WriteLine("Enter Player Id to Remove:");
                        int removePlayerId = int.Parse(Console.ReadLine());
                        oneDayTeam.Remove(removePlayerId);
                        break;

                    case 3:
                        Console.WriteLine("Enter Player Id:");
                        int getPlayerById = int.Parse(Console.ReadLine());
                        Player playerById = oneDayTeam.GetPlayerById(getPlayerById);
                        if (playerById != null)
                        {
                            Console.WriteLine($"{playerById.PlayerId} {playerById.PlayerName} {playerById.PlayerAge}");
                        }
                        else
                        {
                            Console.WriteLine("Player not found with given ID");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Enter Player Name:");
                        string getPlayerByName = Console.ReadLine();
                        Player playerByName = oneDayTeam.GetPlayerByName(getPlayerByName);
                        if (playerByName != null)
                        {
                            Console.WriteLine($"{playerByName.PlayerId} {playerByName.PlayerName} {playerByName.PlayerAge}");
                        }
                        else
                        {
                            Console.WriteLine("Player not found with given Name");
                        }
                        break;

                    case 5:
                        List<Player> allPlayers = oneDayTeam.GetAllPlayers();
                        foreach (var player in allPlayers)
                        {
                            Console.WriteLine($"{player.PlayerId} {player.PlayerName} {player.PlayerAge}");
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }

                Console.WriteLine("Do you want to continue (yes/no)?");
                choice = Console.ReadLine().ToLower();
            } while (choice == "yes");
        }
    }
}