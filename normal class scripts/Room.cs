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
        }
    }

    public void addPellet(string name, string direction)
    {
        if (this.howManyPellets < this.thePellets.Length)
        {
            Pellet p = new Pellet(name, direction);
            this.thePellets[howManyPellets] = p;
            this.howManyPellets++;
        }
    }

    public void removePellet(string direction) //way to remove pellets once they have been collected
    {
        for(int pR = 0; pR < this.howManyPellets;  pR++)
        {
            if (this.thePellets[pR].getPelletDirection().Equals(direction))
            {
                this.thePellets[pR] = null;
            }
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
        for (int i = 0; i < this.howManyPellets; i++)
        {
            if (this.thePellets[i].getPelletDirection().Equals(direction))
            {
                return true;
            }
        }
        return false;
    }
}