using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelect : MonoBehaviour
{
    public void bubblePopper() 
    {
        SceneManager.LoadScene("BubblePopper");    
    }

    public void Painting() 
    {
        SceneManager.LoadScene("Painting");
    }

    public void highScores() 
    {
        SceneManager.LoadScene("HighScores");
    }

    public void mainMenu() 
    {
        SceneManager.LoadScene("Menu");
    }
}
