using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StarEnigma
{
    class StarEnigma
    {
        static void Main(string[] args)
        {
            int numberOfMessages = Int32.Parse(Console.ReadLine());
            string input = "";
            char[] keyLetters = { 's', 't', 'a', 'r' };
            int decryptionKey = 0;
            string decryptedMessage = "";
            string regex = @"\@[A-Za-z]+[^\@\-\!\:\>]*?\:\d+[^\@\-\!\:\>]*?\![A|D]\![^\@\-\!\:\>]*?\-\>\d+";
            string regexPlanetName = @"\@[A-Za-z]+";
            string regexPopulation = @"\:\d+";
            string regexAttackType = @"\![A|D]\!";
            string regexSoldierCount = @"\-\>\d+";
            List<Planet> planets = new List<Planet>();
            int attackedPlanetsCount = 0;
            int destroyedPlanetsCount = 0;

            for (int i = 0; i < numberOfMessages; i++)
            {
                input = Console.ReadLine();
                decryptionKey = GetDecryptionKey(input, keyLetters);
                decryptedMessage = DecryptMessage(input, decryptionKey);
                var match = Regex.Match(decryptedMessage, regex);
                if (match.Success == false)
                {
                    continue;
                }
                Planet currentPlanet = new Planet();
                currentPlanet.Name = Regex.Match(decryptedMessage, regexPlanetName).ToString().Split('@')[1];
                currentPlanet.Population = Int32.Parse(Regex.Match(decryptedMessage, regexPopulation).ToString().Split(':')[1]);
                currentPlanet.AttackType = Char.Parse(Regex.Match(decryptedMessage, regexAttackType).ToString().Split('!')[1]);
                currentPlanet.SoldierCount = Int32.Parse(Regex.Match(decryptedMessage, regexSoldierCount).ToString().Split('-', '>')[2]);
                planets.Add(currentPlanet);
                attackedPlanetsCount = PlanetCount(planets, 'A');
                destroyedPlanetsCount = PlanetCount(planets, 'D');
            }

            planets = planets.OrderBy(x => x.AttackType).ThenBy(y => y.Name).ToList();
            Console.WriteLine("Attacked planets: {0}", attackedPlanetsCount);
            for (int i = 0; i < attackedPlanetsCount; i++)
            {
                Console.WriteLine("-> {0}", planets[i].Name);
            }
            Console.WriteLine("Destroyed planets: {0}", destroyedPlanetsCount);
            for (int i = 0; i < destroyedPlanetsCount; i++)
            {
                Console.WriteLine("-> {0}", planets[i + attackedPlanetsCount].Name);
            }
        }

        static int PlanetCount(List<Planet> planets, char type)
        {
            int count = 0;
            foreach (var planet in planets)
            {
                if (planet.AttackType == type)
                {
                    count++;
                }
            }

            return count;
        }

        static int GetDecryptionKey(string message, char[] keyLetters)
        {
            int key = 0;
            char currentChar;

            for (int i = 0; i < message.Length; i++)
            {
                currentChar = Char.ToLower(message[i]);

                for (int j = 0; j < keyLetters.Length; j++)
                {
                    if (currentChar == keyLetters[j])
                    {
                        key++;
                    }
                }
            }
            return key;
        }

        static string DecryptMessage(string message, int key)
        {
            string decryptedMessage = "";

            for (int j = 0; j < message.Length; j++)
            {

                decryptedMessage += (char)(message[j] - key);
            }
            return decryptedMessage;
        }
    }
}
