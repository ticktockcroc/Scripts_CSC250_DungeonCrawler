using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using UnityEditor.SceneManagement;

public class ShopController : MonoBehaviour
{
    public TextMeshProUGUI attackText = new TextMeshProUGUI();
    // Start is called before the first frame update
    void Start()
    {
        this.attackText.color = Color.red;
        this.attackText.text = "Attack Potion";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Y) && MySingleton.thePlayer.getScore() >= 1) // make sure the shop can be used
        {
            MySingleton.thePlayer.subtractScore(); // pay for buff
            MySingleton.thePlayer.attackIncrease(); // buff attack to player
            EditorSceneManager.LoadScene("DungeonCrawler"); // return to base scene
        }
        else if(Input.GetKeyUp(KeyCode.N) && MySingleton.thePlayer.getScore() >= 1) // decide to not spend the point
        {
            print("did not spend point");
            EditorSceneManager.LoadScene("DungeonCrawler"); // return to base scene
        }
        else if(Input.GetKeyUp(KeyCode.S) && MySingleton.thePlayer.getScore() < 1)
        {
            print("you suck at this game");
            EditorSceneManager.LoadScene("DungeonCrawler"); // return to base scene
        }
    }
}
