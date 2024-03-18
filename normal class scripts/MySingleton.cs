using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class MySingleton
{
    // Start is called before the first frame update
    public static string currentDirection = "?";
    public static Player thePlayer;
    public static int score = 0;
    public static Dungeon theDungeon = MySingleton.generateDungeon();
    public static bool isPelletActive = true;

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

        r1.addPellet("p1", "north"); //adds pellets to each room
        r2.addPellet("p2", "north");
        r2.addPellet("p3", "south");
        r3.addPellet("p4", "north");
        r3.addPellet("p5", "south");
        r3.addPellet("p6", "east");
        r3.addPellet("p7", "west");
        r4.addPellet("p8", "east");
        r5.addPellet("p9", "west");
        r6.addPellet("p10", "south");

        /*r1.removePellet("p1"); //all these must go in an if statement determining whether or not a pellet gameObject has been deactivated
        r2.removePellet("p2");
        r2.removePellet("p3");
        r3.removePellet("p4");
        r3.removePellet("p5");
        r3.removePellet("p6");
        r3.removePellet("p7");
        r4.removePellet("p8");
        r5.removePellet("p9");
        r6.removePellet("p10");*/

        return theDungeon;
    }
}
