using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class Player
{
    private string name;
    private int hp;
    private Room currentRoom;

    public Player(string name)
    {
        this.hp = (int)Random.Range(10.0f, 20.0f); //Unity random number generator
        this.name = name;
        this.currentRoom = null;
    }
    public string getName()
    {
        return this.name;
    }
    public int getHP()
    {
        return this.hp;
    }
    public Room getCurrentRoom() 
    { 
        return this.currentRoom;
    }
    public void setCurrentRoom(Room r)
    {
        this.currentRoom = r;
    }
    public void display()
    {
        
    }

}
