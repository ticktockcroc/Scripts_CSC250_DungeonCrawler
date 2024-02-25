using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonMaster : MonoBehaviour
{
    public GameObject[] closedDoors;
    public bool previousExit = false;
    // Start is called before the first frame update
    private string mapIndexToStringForExit(int index)
    {
        if (index == 0)
        {
            return "north";
        }
        if (index == 1)
        {
            return "south";
        }
        if (index == 2)
        {
            return "east";
        }
        if (index == 3)
        {
            return "west";
        }
        else
        {
            return "?";
        }
    }
    void Start()
    {
        MySingleton.theCurrentRoom = new Room("roomA");
        MySingleton.addRoom(MySingleton.theCurrentRoom);
        
        int openDoorIndex = UnityEngine.Random.Range(0, 4);
        this.closedDoors[openDoorIndex].SetActive(false);
        MySingleton.theCurrentRoom.setOpenDoor(this.mapIndexToStringForExit(openDoorIndex));

        for (int i = 0; i < 4; i++)
        {
            if (openDoorIndex != i)
            {
                int coinFlip = UnityEngine.Random.Range(0, 2);
                if (coinFlip == 1)
                {
                    this.closedDoors[i].SetActive(false);
                    MySingleton.theCurrentRoom.setOpenDoor(this.mapIndexToStringForExit(openDoorIndex));
                }
            }
        }
        if (!MySingleton.currentDirection.Equals("?")) //open exits entered from*****************************************************************************
        {
            if (MySingleton.currentDirection.Equals("north")) //ensure south exit is open visually
            {
                this.closedDoors[1].SetActive(false);
                previousExit = true;
            }
            if (MySingleton.currentDirection.Equals("south")) //ensure north exit is open visually
            {
                this.closedDoors[0].SetActive(false);
                previousExit = true;
            }
            if (MySingleton.currentDirection.Equals("east")) //ensure west exit is open visually
            {
                this.closedDoors[3].SetActive(false);
                previousExit = true;
            }
            if (MySingleton.currentDirection.Equals("west")) //ensure south exit is open visually
            {
                this.closedDoors[2].SetActive(false);
                previousExit = true;
            }
        } //*************************************************************************************************************************************************
        if (previousExit == true) //shift to previous room on array
        {
            MySingleton.shiftRoom(MySingleton.theCurrentRoom);
        }
    }
                // Update is called once per frame
            void Update()
    {
        
    }
}
