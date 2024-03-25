using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobMonster : Monster
{
    public BlobMonster() : base(1)
    {
        base.hp = 5;
        base.monsterName = "Blob";
    }
}
