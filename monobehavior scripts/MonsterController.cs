using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public GameObject chick, monster, middle, playerPoint, monsterPoint;
    public TextMeshProUGUI chick_hp_TMP, monster_hp_TMP, chick_damage_TMP, monster_Damage_TMP;
    public GameObject currentAttacker;
    public float attackSpeed = 5.0f;
    private Animator theCurrentAnimator;
    private bool shouldAttack = true;
    // Start is called before the first frame update
    void Start()
    {
        int num = Random.Range(0, 2); //coin flip will produce 0 and 1
        displayTheText();

        if(num == 0)
        {
            this.currentAttacker = chick;
        }
        else
        {
            this.currentAttacker = monster;
        }

        StartCoroutine(fight());
    }
    
    IEnumerator fight()
    {
        yield return new WaitForSeconds(2);
        if (this.shouldAttack) 
        { 
            this.theCurrentAnimator = this.currentAttacker.GetComponent<Animator>();
            this.theCurrentAnimator.SetTrigger("attack");
            if (this.currentAttacker == this.chick)
            {
                this.currentAttacker = this.monster;
                this.tryAttack(MySingleton.thePlayer, MySingleton.bob);
                displayTheText();

                if (MySingleton.bob.getHP() <= 0)
                {
                    print("Hero Wins!");
                    this.shouldAttack = false;
                }
                else
                {
                    StartCoroutine(fight());
                }
            }
            else
            {
                this.currentAttacker = this.chick;
                this.tryAttack(MySingleton.bob, MySingleton.thePlayer);
                displayTheText();

                if (MySingleton.thePlayer.getHP() <= 0)
                {
                    print("Monster Wins!");
                    this.shouldAttack = false;
                }
                else
                {
                    StartCoroutine(fight());
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void displayTheText()
    {
        this.chick_hp_TMP.text = MySingleton.thePlayer.getMonsterName() + " : " + MySingleton.thePlayer.getHP();
        this.monster_hp_TMP.text = MySingleton.bob.getMonsterName() + " : " + MySingleton.bob.getHP();
    }
    private void tryAttack(Monster attacker, Monster defender)
    {
        // have attacker try to attack defender
        int attackRoll = Random.Range(0, 20) + 1;
        if (attackRoll >= defender.getArmor())
        {
            //the attacker will hit the defender for a random amount of damage
            int damageRoll = Random.Range(0, 4) + 2; //generates 0-3, adds 2 to get 2 - 5
            defender.takeDamage(damageRoll);
            this.chick_damage_TMP.text.SetActive("true");
            StartCoroutine(takeDamageChick());
            this.monster_Damage_TMP.text.SetActive("true");
            StartCoroutine(takeDamageMonster());
        }
        else
        {
            print("Attacker Missed!");
        }
    }
    IEnumerator takeDamageChick()
    {
        yield return new WaitForSeconds(1);
        this.chick_damage_TMP.text.SetActive("false");
    }
    IEnumerator takeDamageMonster()
    {
        yield return new WaitForSeconds(1);
        this.monster_Damage_TMP.text.SetActive("false");
    }

}
