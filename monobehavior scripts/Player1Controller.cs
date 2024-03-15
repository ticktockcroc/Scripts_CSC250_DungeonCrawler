using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEditor.Experimental.GraphView;

public class Player1Controller : MonoBehaviour //operations below are all performed due to being inherited from class MonoBehavior
{
    public float speed = 5.0f;
    public GameObject northExit;
    public GameObject southExit;
    public GameObject eastExit;
    public GameObject westExit;


    public TextMeshProUGUI playerName;
    public TextMeshProUGUI playerHp;
    public GameObject stopPoint;
    private bool amMoving = false;
    private bool amAtStop = false;

    private void turnOffExits()
    {
        this.northExit.gameObject.SetActive(false);
        this.southExit.gameObject.SetActive(false);
        this.eastExit.gameObject.SetActive(false);
        this.westExit.gameObject.SetActive(false);
    }

    private void turnOnExits()
    {
        this.northExit.gameObject.SetActive(true);
        this.southExit.gameObject.SetActive(true);
        this.eastExit.gameObject.SetActive(true);
        this.westExit.gameObject.SetActive(true);
    }

    void Start()
    {
        SetCountText();
        this.turnOffExits();
        this.stopPoint.SetActive(false);

        if(!MySingleton.currentDirection.Equals("?"))
        {
            this.amMoving = true;
            this.stopPoint.SetActive(true);
            this.amAtStop = false;

            if (MySingleton.currentDirection.Equals("north"))
            {
                this.gameObject.transform.position = this.southExit.transform.position;
                this.gameObject.transform.LookAt(this.stopPoint.transform.position);
            }
            else if (MySingleton.currentDirection.Equals("south"))
            {
                this.gameObject.transform.position = this.northExit.transform.position;
                this.gameObject.transform.LookAt(this.stopPoint.transform.position);
            }
            else if (MySingleton.currentDirection.Equals("east"))
            {
                this.gameObject.transform.position = this.westExit.transform.position;
                this.gameObject.transform.LookAt(this.stopPoint.transform.position);
            }
            else if (MySingleton.currentDirection.Equals("west"))
            {
                this.gameObject.transform.position = this.eastExit.transform.position;
                this.gameObject.transform.LookAt(this.stopPoint.transform.position);
            }
        }
        else
        {
            this.amMoving = false;
            this.amAtStop = true;
            this.stopPoint.SetActive(false);
            this.gameObject.transform.position = this.stopPoint.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other) //updated to include scene shift back if entered a previous exit
    {
        if (other.CompareTag("door"))
        {
            EditorSceneManager.LoadScene("DungeonCrawler");
        }
        else
        {
            if(other.CompareTag("atStop") && !MySingleton.currentDirection.Equals("?"))
            {
                this.stopPoint.SetActive(false);
                this.turnOnExits();
                print("At Middle of the Room");
                this.amAtStop = true;
                this.amMoving = false;
                MySingleton.currentDirection = "middle";
            }
        }
    }
   
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow) && !this.amMoving && MySingleton.thePlayer.getCurrentRoom().hasExit("north"))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "north";
            this.gameObject.transform.LookAt(this.northExit.transform.position);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) && !this.amMoving && MySingleton.thePlayer.getCurrentRoom().hasExit("south"))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "south";
            this.gameObject.transform.LookAt(this.southExit.transform.position);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && !this.amMoving && MySingleton.thePlayer.getCurrentRoom().hasExit("east"))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "east";
            this.gameObject.transform.LookAt(this.eastExit.transform.position);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) && !this.amMoving && MySingleton.thePlayer.getCurrentRoom().hasExit("west"))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "west";
            this.gameObject.transform.LookAt(this.westExit.transform.position);
        }

        if (MySingleton.currentDirection.Equals("north"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.northExit.transform.position, this.speed * Time.deltaTime);
        }
        if (MySingleton.currentDirection.Equals("south"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.southExit.transform.position, this.speed * Time.deltaTime);
        }
        if (MySingleton.currentDirection.Equals("east"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.eastExit.transform.position, this.speed * Time.deltaTime);
        }
        if (MySingleton.currentDirection.Equals("west"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.westExit.transform.position, this.speed * Time.deltaTime);
        }
    }

    void SetCountText()
    {
        this.playerName.text = MySingleton.thePlayer.getName();
        this.playerHp.text = "HP : " + MySingleton.thePlayer.getHP().ToString();
    }
}
