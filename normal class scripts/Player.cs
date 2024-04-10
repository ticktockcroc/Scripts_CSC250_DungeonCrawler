using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class Player : Monster
{
    private int score;

    public Player(string name) : base(name)
    {
        base.monsterName = name;
        base.hp = (int)Random.Range(10.0f, 20.0f); //Unity random number generator
        base.armor = 8;
        base.attack = 1;
        this.score = 0;
    }
    public int getScore()
    {
        return this.score;
    }
    public void addScore()
    {
        this.score += 1;
    }
    public void subtractScore()
    {
        this.score -= 1;
    }
    public void recover()
    {
        base.hp = base.hp + 10;
    }
    public void attackIncrease()
    {
        base.attack = base.attack + 1;
    }
    public void display()
    {
        
    }

}
