using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Dungeon
{
    private string name;
    private Room startRoom;
    private Room currentRoom;
    private Player thePlayer;

    public Dungeon(string name)
    {
        this.name = name;
    }
    public void setStartRoom(Room r)
    {
        this.startRoom = r;
    }

    public void setSecondRoom(Room r) //add way to keep track of current room in a dungeon
    {
        this.currentRoom = r;
    }
    public Room getSecondRoom() 
    {
        return this.currentRoom;
    }
    public void addPlayer(Player thePlayer) 
    { 
        this.thePlayer = MySingleton.thePlayer;
        this.startRoom.addPlayer(this.thePlayer);
    }

}
