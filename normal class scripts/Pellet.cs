using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet
{
    private string pelletName;
    private string direction;

    public Pellet (string name, string direction)
    {
        this.pelletName = name;
        this.direction = direction;
    }

    public string getPelletName()
    {
        return this.pelletName;
    }

    public string getPelletDirection()
    {
        return this.direction;
    }

}
