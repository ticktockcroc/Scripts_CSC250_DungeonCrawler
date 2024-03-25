using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster
{
    protected string monsterName;
    protected int hp;

    public Monster(int hp)
    {
        this.hp = hp;
        this.monsterName = "Monster";
    }
    public string getMonsterName()
    {
        return this.monsterName;
    }
    public int getHP()
    {
        return this.hp;
    }
}
