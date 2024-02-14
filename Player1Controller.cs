using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;

public class Player1Controller : MonoBehaviour //operations below are all performed due to being inherited from class MonoBehavior
{
    private Player thePlayer;
    public float speed = 5.0f;


    public TextMeshProUGUI playerName;
    public TextMeshProUGUI playerHp;
    public GameObject destinationGO;

    void Start()
    {
        this.thePlayer = new Player("John");
        SetCountText();
    }

    void Update()
    {
        this.thePlayer.display();
        if (Vector3.Distance(this.gameObject.transform.position, this.destinationGO.transform.position) > 1.0f)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.destinationGO.transform.position, this.speed * Time.deltaTime);
        }
    }

    void SetCountText()
    {
        this.playerName.text = thePlayer.getName();
        this.playerHp.text = "HP : " + thePlayer.getHP().ToString();
    }
}
