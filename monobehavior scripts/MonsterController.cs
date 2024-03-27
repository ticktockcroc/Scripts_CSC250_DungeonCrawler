using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public GameObject chick, monster, middle, playerPoint, monsterPoint;
    public TextMeshProUGUI chick_hp_TMP, monster_hp_TMP;
    public BlobMonster bob;
    public float attackSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        displayTheText();
    }

    // Update is called once per frame
    void Update()
    {
        this.chick.transform.LookAt(this.middle.transform.position);
        this.chick.transform.position = Vector3.MoveTowards(this.chick.transform.position, this.playerPoint.transform.position, this.attackSpeed * Time.deltaTime);
        this.monster.transform.LookAt(this.middle.transform.position);
        this.monster.transform.position = Vector3.MoveTowards(this.monster.transform.position, this.monsterPoint.transform.position, this.attackSpeed * Time.deltaTime);

        while (MySingleton.thePlayer.getHP() > 0 || MySingleton.bob.getHP() > 0)
        {
            displayTheText();
            if (MySingleton.thePlayer.offensive() > MySingleton.bob.getArmor())
            {
                this.chick.transform.position = Vector3.MoveTowards(this.chick.transform.position, this.middle.transform.position, this.attackSpeed * Time.deltaTime);
                MySingleton.bob.takeDamage();
                this.chick.transform.position = Vector3.MoveTowards(this.chick.transform.position, this.playerPoint.transform.position, this.attackSpeed * Time.deltaTime);
            }
            else
            {
                this.monster.transform.position = Vector3.MoveTowards(this.monster.transform.position, this.middle.transform.position, this.attackSpeed * Time.deltaTime);
                MySingleton.thePlayer.takeDamage();
                this.monster.transform.position = Vector3.MoveTowards(this.monster.transform.position, this.monsterPoint.transform.position, this.attackSpeed * Time.deltaTime);
            }
        }
        if(MySingleton.thePlayer.getHP() <= 0)
        {
            MySingleton.thePlayer.setHP(0);
        }
        else if (MySingleton.bob.getHP() <= 0)
        {
            MySingleton.bob.setHP(0);
        }
    }
    void displayTheText()
    {
        this.chick_hp_TMP.text = MySingleton.thePlayer.getMonsterName() + " : " + MySingleton.thePlayer.getHP();
        this.monster_hp_TMP.text = MySingleton.bob.getMonsterName() + " : " + MySingleton.bob.getHP();
    }
}
