using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class MySingleton
{
    // Start is called before the first frame update
    public static string currentDirection = "?";
    public static Player thePlayer;
    public static BlobMonster bob;
    public static int score = 0;
    public static Dungeon theDungeon = MySingleton.generateDungeon();
    public static bool isPelletActive = true;
    public static bool firstDungeonEntry = true;
    public static bool getsPellet = false;
    public static int playerAttack;

    public static string readItemsDataJson()
    {
        string filePath = "Assets/Data Files/items_data_json.txt";
        string answer = "";

        if (File.Exists(filePath))
        {
            try
            {

                using (StreamReader reader = new StreamReader(filePath)) // open file to read from
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        answer = answer + line;
                    }
                    return answer;
                }
            }
            catch (Exception ex) // display any errors that occurred during file reading
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }
    public static string flipDirection(string direction)
    {
        if (direction.Equals("north"))
        {
            return "south";
        }
        else if (direction.Equals("south"))
        {
            return "north";
        }
        else if (direction.Equals("east"))
        {
            return "west";
        }
        else if (direction.Equals("west"))
        {
            return "east";
        }
        else
        {
            return "n/a";
        }
    }

    private static Dungeon generateDungeon()
    {
        Room r1 = new Room("R1"); //adds rooms to the dungeon
        Room r2 = new Room("R2");
        Room r3 = new Room("R3");
        Room r4 = new Room("R4");
        Room r5 = new Room("R5");
        Room r6 = new Room("R6");

        MySingleton.theDungeon = new Dungeon("superHappyFunFunLand");
        theDungeon.setStartRoom(r1);
        MySingleton.thePlayer = new Player("John");
        MySingleton.bob = new BlobMonster("Bob");
        theDungeon.addPlayer(MySingleton.thePlayer);

        r1.addExit("north", r2); //adds exits to the rooms
        r2.addExit("south", r1);
        r2.addExit("north", r3);
        r3.addExit("south", r2);
        r3.addExit("west", r4);
        r3.addExit("north", r6);
        r3.addExit("east", r5);
        r4.addExit("east", r3);
        r5.addExit("west", r3);
        r6.addExit("south", r3);

        return theDungeon;
    }
}
