using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster
{
    protected string monsterName;
    protected int hp;
    protected int armor;
    protected Room currentRoom;
    protected int damage;
    protected int attack;

    public Monster(string name)
    {
        this.monsterName = name;
        this.currentRoom = null;
    }
    public string getMonsterName()
    {
        return this.monsterName;
    }
    public int getHP()
    {
        return this.hp;
    }
    public void setHP(int hp)
    {
        this.hp = hp;
    }
    public int getArmor()
    {
        return this.armor;
    }
    public Room getCurrentRoom()
    {
        return this.currentRoom;
    }
    public void setCurrentRoom(Room r)
    {
        this.currentRoom = r;
    }
    public void takeDamage()
    {
        this.damage = (int)Random.Range(0.0f, 6.0f);
        this.hp = this.hp - this.damage;
    }
    public int offensive()
    {
        this.attack = (int)Random.Range(0.0f, 20.0f);
        return this.attack;
    }
}
