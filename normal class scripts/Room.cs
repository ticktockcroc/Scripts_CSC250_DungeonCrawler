using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Room
{
    private string name;

    private Exit[] theExits = new Exit[4];
    private Pellet[] thePellets = new Pellet[4];
    private int howManyExits = 0;
    private int howManyPellets = 0;

    private Player currentPlayer;
    private Pellet northPellet = null; //does not violate abstract class due to being set to null
    private Pellet southPellet = null;
    private Pellet eastPellet = null;
    private Pellet westPellet = null;

    public Room(string name)
    {
        this.name = name;
        this.currentPlayer = null;
    }
    public void addPlayer(Player thePlayer)
    {
        this.currentPlayer = thePlayer;
        this.currentPlayer.setCurrentRoom(this);
    }

    public void removePlayer(string direction) //remove player from current room
    {
        Exit theExit = this.getExitGivenDirection(direction);
        Room destinationRoom = theExit.getDestinationRoom();
        destinationRoom.addPlayer(this.currentPlayer);
        this.currentPlayer = null; //finally remove player that just left from this room
    }

    private Exit getExitGivenDirection(string direction)
    {
        for (int i = 0; i < howManyExits; i++)
        {
            if (this.theExits[i].getDirection().Equals(direction))
            {
                return this.theExits[i]; //returns exit in given direction
            }
        }
        return null; //never found exit
    }
    public void addExit(string direction, Room destinationRoom)
    {
        if (this.howManyExits < this.theExits.Length)
        {
            Exit e = new Exit(direction, destinationRoom);
            this.theExits[howManyExits] = e;
            this.howManyExits++;

            if(direction.Equals("north"))
            {
                this.northPellet = new ArmorPellet();
            }
            else if (direction.Equals("south")) // else statements in front of ifs makes questioning more efficient, if using just ifs each question will be asked every time
            {
                this.southPellet = new ArmorPellet();
            }
            else if (direction.Equals("east"))
            {
                this.eastPellet = new ArmorPellet();
            }
            else if (direction.Equals("west"))
            {
                this.westPellet = new ArmorPellet();
            }
        }
    }

    public void addPellet(Pellet p, string direction) // also not instance of Pellet, just and empty variable
    {
        if(direction.Equals("north"))
        {
            this.northPellet = p;
        }
        else if (direction.Equals("south"))
        {
            this.southPellet = p;
        }
        else if (direction.Equals("east"))
        {
            this.eastPellet = p;
        }
        else if (direction.Equals("west"))
        {
            this.westPellet = p;
        }
        else
        {
            Debug.Log("Invalid direction");
        }
    }

    public void removePellet(string direction) //way to remove pellets once they have been collected
    {
        if (direction.Equals("north"))
        {
            this.northPellet = null;
        }
        else if (direction.Equals("south"))
        {
            this.southPellet = null;
        }
        else if (direction.Equals("east"))
        {
            this.eastPellet = null;
        }
        else if (direction.Equals("west"))
        {
            this.westPellet = null;
        }
        else
        {
            Debug.Log("Invalid direction");
        }
    }
    public bool hasExit(string direction)
    {
        for (int i = 0; i < this.howManyExits; i++)
        {
            if (this.theExits[i].getDirection().Equals(direction))
            {
                return true;
            }
        }
        return false;
    }
    public bool hasPellet(string direction)
    {
        if (direction.Equals("north"))
        {
            return this.northPellet != null;
        }
        else if (direction.Equals("south"))
        {
            return this.southPellet != null;
        }
        else if (direction.Equals("east"))
        {
            return this.eastPellet != null;
        }
        else if (direction.Equals("west"))
        {
            return this.westPellet != null;
        }
        else
        {
            Debug.Log("Invalid direction");
            return false; // could also put at the end of function outside of if-else statements to guaruntee, but code might not like it
        }
    }
}