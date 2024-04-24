using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectionManager : MonoBehaviour
{
    public GameObject pill1, pill2, pill3, pill4;
    public string name1, name2, name3, name4;
    public string cost1, cost2, cost3, cost4;
    private int selector;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemCost;
    private string jsonString;
    public RootObject root = new RootObject();

    // Start is called before the first frame update
    void Start()
    {
        this.jsonString = MySingleton.readItemsDataJson(); //read JSON file with serialization

        this.root = JsonUtility.FromJson<RootObject>(jsonString); //parse the JSON string

        this.selector = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (selector == 0)
        {
            this.pill1.gameObject.SetActive(true);
            this.pill2.gameObject.SetActive(false);
            this.pill3.gameObject.SetActive(false);
            this.pill4.gameObject.SetActive(false);
            this.itemName.text = name1;
            this.itemCost.text = cost1;
        }
        else if (selector == 1)
        {
            this.pill1.gameObject.SetActive(false);
            this.pill2.gameObject.SetActive(true);
            this.pill3.gameObject.SetActive(false);
            this.pill4.gameObject.SetActive(false);
            this.itemName.text = name2;
            this.itemCost.text = cost2;
        }
        else if (selector == 2)
        {
            this.pill1.gameObject.SetActive(false);
            this.pill2.gameObject.SetActive(false);
            this.pill3.gameObject.SetActive(true);
            this.pill4.gameObject.SetActive(false);
            this.itemName.text = name3;
            this.itemCost.text = cost3;
        }
        else if (selector == 3)
        {
            this.pill1.gameObject.SetActive(false);
            this.pill2.gameObject.SetActive(false);
            this.pill3.gameObject.SetActive(false);
            this.pill4.gameObject.SetActive(true);
            this.itemName.text = name4;
            this.itemCost.text = cost4;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) && selector < 3)
        {
            this.selector++;
        }
        else if(Input.GetKeyUp(KeyCode.LeftArrow) && selector > 0)
        {
            this.selector--;
        }
        else if(Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            print("cannot move further");
        }

        if (Input.GetKeyUp(KeyCode.A) && pill1.activeSelf == true)
        {
            Debug.Log("attack boost");
        }
        else if (Input.GetKeyUp(KeyCode.A) && pill2.activeSelf == true)
        {
            Debug.Log("max hp boost");
        }
        else if (Input.GetKeyUp(KeyCode.A) && pill3.activeSelf == true)
        {
            Debug.Log("armor boost");
        }
        else if (Input.GetKeyUp(KeyCode.A) && pill4.activeSelf == true)
        {
            Debug.Log("hp recovery");
        }
    }
}
