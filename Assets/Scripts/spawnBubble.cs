using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBubble : MonoBehaviour
{

    public GameObject bubblePrefab;
    public float respawnTime = 2.0f;
    private Vector3 outOfScreen;

    int tempX, tempY, counter;
    float x, y;
    void Start()
    {
        counter = 0;
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
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawn();
            counter++;
            if (counter == 5 && respawnTime - 0.1 > 1.1)
            {
                respawnTime -= 0.1f;
                counter = 0;
            }
            Debug.Log(respawnTime);
        }
    }



    
}
