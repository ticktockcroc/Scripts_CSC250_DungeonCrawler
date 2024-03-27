using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobMonster : Monster
{
    public BlobMonster(string name) : base(name)
    {
        base.monsterName = name;
        base.hp = 15;
        base.armor = 7;
    }
}
