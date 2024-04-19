using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionManager : MonoBehaviour
{
    public GameObject pill1, pill2, pill3, pill4;
    private int selector;
    private int[] itemSets = new int[100];
    private int tracker = 0;
    // Start is called before the first frame update
    void Start()
    {
        string jsonString = MySingleton.readItemsDataJson(); //read JSON file with serialization

        RootObject root = JsonUtility.FromJson<RootObject>(jsonString); //parse the JSON string

        this.selector = Random.Range(0, 4);

        itemSets[this.tracker] = this.selector;
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
        }
        else if (selector == 1)
        {
            this.pill1.gameObject.SetActive(true);
            this.pill2.gameObject.SetActive(true);
            this.pill3.gameObject.SetActive(false);
            this.pill4.gameObject.SetActive(false);
        }
        else if (selector == 2)
        {
            this.pill1.gameObject.SetActive(true);
            this.pill2.gameObject.SetActive(true);
            this.pill3.gameObject.SetActive(true);
            this.pill4.gameObject.SetActive(false);
        }
        else if (selector == 3)
        {
            this.pill1.gameObject.SetActive(true);
            this.pill2.gameObject.SetActive(true);
            this.pill3.gameObject.SetActive(true);
            this.pill4.gameObject.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            this.selector = Random.Range(0, 4);
            this.tracker++;
            itemSets[this.tracker] = this.selector;
        }
        else if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            this.selector = Random.Range(0, 4);
            this.tracker--;
            itemSets[this.tracker] = this.selector;
        }

        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            Debug.Log("attack boost");
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            Debug.Log("max hp boost");
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            Debug.Log("armor boost");
        }
        else if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            Debug.Log("hp recovery");
        }
    }
}
