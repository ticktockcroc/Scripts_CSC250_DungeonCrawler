using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public GameObject chick, monster, middle, playerPoint, monsterPoint;
    public TextMeshProUGUI chick_hp_TMP, monster_hp_TMP, battleCommentary;
    private GameObject currentAttacker;
    public float attackSpeed = 5.0f;
    private Animator theCurrentAnimator;
    private bool shouldAttack = true;
    // Start is called before the first frame update
    void Start()
    {
        this.battleCommentary.text = "";
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
        yield return new WaitForSeconds(1);
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
                    this.monster.transform.Rotate(-90, 0, 0);
                    this.battleCommentary.color = Color.yellow;
                    this.battleCommentary.text = "You Win!";
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
                    this.chick.transform.Rotate(90, 0, 0);
                    this.battleCommentary.color = Color.black;
                    this.battleCommentary.text = "You died...";
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
        if(MySingleton.thePlayer.getHP() <=0) //returns player to the scene without score increase and pellet removal
        {
            MySingleton.thePlayer.setHP((int)Random.Range(10.0f, 20.0f));
            EditorSceneManager.LoadScene("DungeonCrawler");
            
        }
        else if(MySingleton.bob.getHP() <= 0) //returns player to the scene with score increase and pellet removal
        {
            MySingleton.getsPellet = true;
            MySingleton.thePlayer.addScore();
            MySingleton.bob.setHP((int)Random.Range(10.0f, 20.0f));
            EditorSceneManager.LoadScene("DungeonCrawler");
        }
    }
    void displayTheText()
    {
        this.chick_hp_TMP.text = MySingleton.thePlayer.getMonsterName() + " : " + MySingleton.thePlayer.getHP();
        this.monster_hp_TMP.text = MySingleton.bob.getMonsterName() + " : " + MySingleton.bob.getHP();
    }
    private void tryAttack(Monster attacker, Monster defender)
    {
        // have attacker try to attack defender
        this.battleCommentary.text = "";
        int attackRoll = Random.Range(0, 20) + 1;
        if (attackRoll >= defender.getArmor())
        {
            //the attacker will hit the defender for a random amount of damage
            int damageRoll = Random.Range(0, 4) + 2; //generates 0-3, adds 2 to get 2 - 5
            defender.takeDamage(damageRoll);
            this.battleCommentary.color = Color.red;
            this.battleCommentary.text = "Attack did " + damageRoll + " damage";
        }
        else
        {
            this.battleCommentary.color = Color.blue;
            this.battleCommentary.text = "Attacker Missed!";
        }
    }
}
