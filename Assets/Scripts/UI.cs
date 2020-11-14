using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI : MonoBehaviour
{
    GameObject[] bubbles;
    public Text score;
    public Text missed;
    public static int scoreCounter;
    public static int missedCounter;
    void Start()
    {
        bubbles = new GameObject[spawnBubble.onScreenBubbles];
        scoreCounter = 0;
        missedCounter = 0;

        score.text = "";
        missed.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreCounter;
        missed.text = "Missed: " + missedCounter;
        if (missedCounter == 10)
        {
            spawnBubble.running = false;
            bubbles = GameObject.FindGameObjectsWithTag("bubble");
            foreach (GameObject bub in bubbles)
                Destroy(bub);


        }
        
    }
}
