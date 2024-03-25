using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pellet
{
    protected string pelletName;
    private string direction;
    protected int bonus;

    public Pellet (int bonus)
    {
        this.bonus = bonus;
        this.pelletName = "Pellet";
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
