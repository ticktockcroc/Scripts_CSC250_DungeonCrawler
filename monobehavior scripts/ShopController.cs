using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using UnityEditor.SceneManagement;
using System.IO; // need this for files
using System; // need this for try-catch statements

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

        this.readItemsData(); //read plain text file

        string jsonString = this.readItemsDataJson(); //read JSON file with serialization

        RootObject root = JsonUtility.FromJson<RootObject>(jsonString); //parse the JSON string

        foreach (var item in root.items) //output data to the console
        {
            print($"Name: {item.name}, Stat Impacted: {item.stat_impacted}, Modifier: {item.modifier}");
        }
    }

    private void readItemsData()
    {
        string filePath = "Assets/Data Files/items_data.txt";
        string answer = "";

        if(File.Exists(filePath)) // check if file exists
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath)) // open file to read from
                {
                    string line;
                    string[] itemParts = new string[3];
                    int pos = 0;

                    while((line = reader.ReadLine()) != null) // read lines from the file until the end of the file is reached
                    {
                        string[] parts = line.Split(",");
                        for(int i = 0; i < parts.Length; i++)
                        {
                            print(parts[i]);
                            itemParts[pos % 3] = parts[i];
                            pos++;
                        }
                        print("Manually parsed with item object");
                        Item theItem = new Item(itemParts[0], itemParts[1], int.Parse(itemParts[2]));
                        theItem.display();
                    }
                }
            }
            catch (Exception ex)
            {
                print("An error occurred while reading the file");
                print(ex.Message);
            }
        }
        else
        {
            print("The File does not exist");
        }

    }

    private string readItemsDataJson()
    {
        string filePath = "Assets/Data Files/items_data_json.txt";
        string answer = "";

        if(File.Exists(filePath))
        {
            try
            {
                print("Serialized JSON Parsing");

                using (StreamReader reader = new StreamReader(filePath)) // open file to read from
                {
                    string line;
                    while((line = reader.ReadLine()) != null)
                    {
                        answer = answer + line;
                    }
                    return answer;
                }
            }
            catch(Exception ex) // display any errors that occurred during file reading
            {
                print("An error occurred while reading the file");
                print(ex.Message);
                return null;
            }
        }
        else
        {
            print("The File does not exist");
            return null;
        }
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
