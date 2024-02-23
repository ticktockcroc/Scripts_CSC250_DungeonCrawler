using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonMaster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Room r = new Room("roomA");
        MySingleton.addRoom(r);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
