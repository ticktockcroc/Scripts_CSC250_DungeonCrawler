using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using UnityEditor.SceneManagement;

public class ShopController : MonoBehaviour
{
    public TextMeshProUGUI attackText = new TextMeshProUGUI();
    public TextMeshProUGUI hpText = new TextMeshProUGUI();
    public TextMeshProUGUI pelletAmount = new TextMeshProUGUI();
    private bool selection = false;
    // Start is called before the first frame update
    void Start()
    {
        this.attackText.color = Color.blue;
        this.attackText.text = "Attack Potion";
        this.hpText.color = Color.white;
        this.hpText.text = "HP Potion";
        this.pelletAmount.text = "Score: " + MySingleton.thePlayer.getScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow)) 
        {
            this.attackText.color = Color.white;
            this.hpText.color = Color.blue;
            this.selection = true;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            this.attackText.color = Color.blue;
            this.hpText.color = Color.white;
            this.selection = false;
        }
        if (Input.GetKeyUp(KeyCode.Y) && MySingleton.thePlayer.getScore() >= ItemSingleton.attackBoostCost && this.selection == false) // make sure the shop can be used
        {
            MySingleton.thePlayer.subtractScore(); // pay for buff
            MySingleton.thePlayer.attackIncrease(); // buff attack to player
            EditorSceneManager.LoadScene("DungeonCrawler"); // return to base scene
        }
        if (Input.GetKeyUp(KeyCode.Y) && MySingleton.thePlayer.getScore() >= ItemSingleton.hpBoostCost && this.selection == true) // make sure the shop can be used
        {
            MySingleton.thePlayer.subtractScore(); // pay for buff
            MySingleton.thePlayer.recover(); // buff attack to player
            EditorSceneManager.LoadScene("DungeonCrawler"); // return to base scene
        }
        else if(Input.GetKeyUp(KeyCode.N) && MySingleton.thePlayer.getScore() >= 1) // decide to not spend the point
        {
            print("did not spend point");
            EditorSceneManager.LoadScene("DungeonCrawler"); // return to base scene
        }
        else if(Input.GetKeyUp(KeyCode.Escape) && MySingleton.thePlayer.getScore() < 1)
        {
            print("you suck at this game");
            EditorSceneManager.LoadScene("DungeonCrawler"); // return to base scene
        }
    }
}
