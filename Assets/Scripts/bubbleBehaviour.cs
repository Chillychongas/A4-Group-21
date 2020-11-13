using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleBehaviour : MonoBehaviour
{
    Vector3 target, x, y;
    int timer;
    bool alive;
    float seconds = 1.0f;

    void Start()
    {
        alive = true;
        target = transform.position;
        target *= -1;
        target.z = 0;

        timer = 0;
        StartCoroutine(despawn());
    }
    void OnMouseUpAsButton()
    {
        UI.scoreCounter++;
        Destroy(gameObject);
        spawnBubble.onScreenBubbles--;
    }
    void Update()
    {
        transform.position += transform.TransformDirection(target.normalized * 2) * Time.deltaTime;
        if (!alive)
        {
            StopCoroutine(despawn());
            Destroy(gameObject);
            UI.missedCounter++;
            spawnBubble.onScreenBubbles--;
        }
    }
    
    IEnumerator despawn()
    {
        while (alive)
        {
            yield return new WaitForSeconds(seconds);
            timer++;
            if(timer == 10)
                alive = false;
        }
    }
}
