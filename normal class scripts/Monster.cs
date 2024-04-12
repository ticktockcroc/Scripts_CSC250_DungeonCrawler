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
    public void setAttack(int attack)
    {
        this.attack = attack;
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
    public void takeDamage(int damage)
    {
        this.hp = this.hp - damage;
        setHP(this.hp);
    }
    public int returnAttack()
    {
        return this.attack;
    }
}
