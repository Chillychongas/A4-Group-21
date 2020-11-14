using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class UI : MonoBehaviour
{
    GameObject[] bubbles;
    public Text score;
    public Text missed;
    public static int scoreCounter;
    public static int missedCounter;

    public GameObject btn;

    private string Line1;
    private string Line2;
    string filePath = "Assets/Files/scores.csv";

    void Start()
    {
        btn.gameObject.SetActive(false);

        bubbles = new GameObject[spawnBubble.onScreenBubbles];
        scoreCounter = 0;
        missedCounter = 0;

        score.text = "";
        missed.text = "";

        //checks to make sure file exists
        if (!File.Exists(filePath))
        {
            string[] createText = { "Bubble Popper,0", "Painting,0" };
            File.WriteAllLines(filePath, createText);
        }
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreCounter;
        missed.text = "Missed: " + missedCounter;
        if (missedCounter >= 10)
        {
            //compares score to that on file, if greater then overwrites file
            //---------------------------------------------------------------------------
            string[] fileLines = File.ReadAllLines(filePath);

            foreach (string line in fileLines)
            {
                string[] words = line.Split(',');

                if (words[0] == "Bubble Popper")
                {
                    if (int.Parse(words[1]) < scoreCounter)
                    {
                        words[1] = scoreCounter.ToString();
                    }

                    Line1 = words[0] + "," + words[1];
                }
                else
                {
                    Line2 = line;
                    string strout = Line1 + '\n' + Line2;
                    File.WriteAllText(filePath, strout);
                }
            }
            //---------------------------------------------------------------------------

            btn.gameObject.SetActive(true);
            spawnBubble.running = false;
            bubbles = GameObject.FindGameObjectsWithTag("bubble");
            foreach (GameObject bub in bubbles)
                Destroy(bub);


        }
        
    }
}
