using System.Collections;
using System.Collections.Generic;
using System.Net;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Networking;

public class pokemonAPI : MonoBehaviour
{
    public CollectionOfPokemon allPokemon = new CollectionOfPokemon();
    private string pokeString;
    private int tracker;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRequest("https://pokeapi.co/api/v2/pokemon/?offset=0&limit=2000"));

        this.tracker = 0;
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {

            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                print("Error: " + webRequest.error);
            }
            else
            {
                // Show results as text
                print(webRequest.downloadHandler.text);
                // Or retrieve results as binary data
                //byte[] results = webRequest.downloadHandler.data;
                this.pokeString = webRequest.downloadHandler.text;

                this.allPokemon = JsonUtility.FromJson<CollectionOfPokemon>(this.pokeString);
            }
        }
    }
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space)) 
        {
            while (tracker < 1302)
            {
                Debug.Log("Name of Pokemon = " + this.allPokemon.results[tracker].name + " URL = " + this.allPokemon.results[tracker].url);
                tracker++;
            }
        }
    }
}
