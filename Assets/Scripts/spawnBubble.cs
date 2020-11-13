using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBubble : MonoBehaviour
{
    public static bool running;
    public GameObject bubblePrefab;
    
    public float respawnTime = 1.5f;
    private Vector3 outOfScreen;

    public static int onScreenBubbles;
    int tempX, tempY, speedCounter, spawnCounter, respawnCounter;

    float x, y;
    void Start()
    {
        onScreenBubbles = 0;
        running = true;
        speedCounter = 0;
        spawnCounter = 0;
        respawnCounter = 1;
        outOfScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        

        StartCoroutine(bubbles());
    }
    private void spawn()
    {
        

        GameObject temp = Instantiate(bubblePrefab) as GameObject;
        tempX = Random.Range(0, 2);
        tempY = Random.Range(0, 2);

        if(tempX == 0)
        {
            if(tempY == 0)
                x = outOfScreen.x;
            else
                x = -outOfScreen.x;


            y = Random.Range(-outOfScreen.y, outOfScreen.y);
        }
        else
        {
            if (tempY == 0)
                y = outOfScreen.y;
            else
                y = -outOfScreen.y;
            
            x = Random.Range(-outOfScreen.x, outOfScreen.x);
        }


        temp.transform.position = new Vector3(x, y, -4.5f);


    }
    
    IEnumerator bubbles()
    {
        while (running)
        {
            /*
             * spawn a bubble * respawnCounter every respawnTime seconds
             * after every bubble spawns, reduce respawnTime by 0.1
             * after 15 bubbles have spawned, respawnTime gets set back to 1.5 but respawnCounter gets increased by 1
             */ 
            yield return new WaitForSeconds(respawnTime);
            
            for (int i = 0; i < respawnCounter; i++)
            {
                spawn();
                onScreenBubbles++;
            }
            spawnCounter++;
            if (spawnCounter == 15)
            {
                spawnCounter = 0;
                respawnCounter++;
                respawnTime = 1.5f;
            }

            speedCounter++;
            if (speedCounter == 5 && respawnTime - 0.1 > 1.1)
            {
                respawnTime -= 0.1f;
                speedCounter = 0;
            }
        }
    }



    
}
