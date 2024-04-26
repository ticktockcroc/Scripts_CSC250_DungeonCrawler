using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

public class CryptoAPI : MonoBehaviour
{
    public Crypto theCrypto;
    private string cryptoJSON;
    // Start is called before the first frame update
    void Start()
    {
        readCryptoData();
    }

    public void readCryptoData()
    {
        string filePath = "Assets/Data Files/crypto_data.txt";
        string answer = "";

        if (File.Exists(filePath))
        {
            try
            {

                using (StreamReader reader = new StreamReader(filePath)) // open file to read from
                {
                    string line;
                    string[] cryptoParts = new string[2];
                    string[] cryptoTotal = new string[24];
                    int pos = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(":");
                        for(int i = 0; i < cryptoParts.Length; i++)
                        {
                            print(parts[i]);
                            cryptoParts[pos % 2] = parts[i];
                            cryptoTotal[pos] = cryptoParts[pos % 2];
                            pos++;
                        }

                    }
                    this.theCrypto = new Crypto(cryptoTotal[1], cryptoTotal[3], cryptoTotal[5], cryptoTotal[7], cryptoTotal[9], cryptoTotal[11], cryptoTotal[13], cryptoTotal[15], cryptoTotal[17], cryptoTotal[19], cryptoTotal[21], cryptoTotal[23]);
                    this.theCrypto.display();
                }
            }
            catch (Exception ex) // display any errors that occurred during file reading
            {
                print("error has occured");
                print(ex.Message);
            }
        }
        else
        {
            print("file does not exist");
        }
    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
