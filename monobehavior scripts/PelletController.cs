using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletController : MonoBehaviour
{
    public GameObject northPellet, southPellet, eastPellet, westPellet;
    // Start is called before the first frame update
    void Start()
    {
        Room theCurrentRoom = MySingleton.thePlayer.getCurrentRoom();

        if (theCurrentRoom.hasPellet("north"))
        {
            this.northPellet.SetActive(true);
        }
        if (theCurrentRoom.hasPellet("south"))
        {
            this.southPellet.SetActive(true);
        }
        if (theCurrentRoom.hasPellet("east"))
        {
            this.eastPellet.SetActive(true);
        }
        if (theCurrentRoom.hasPellet("west"))
        {
            this.westPellet.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
