using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArmorPellet : Pellet
{
    public ArmorPellet() : base(1)
    {
        //we already have our instance of Pellet
        //differentiate our ArmorPellet from a normal Pellet
        base.bonus = base.bonus * 2;
        base.pelletName = "ArmorPellet";
    }
}
