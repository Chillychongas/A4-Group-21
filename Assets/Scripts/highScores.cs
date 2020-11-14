using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class highScores : MonoBehaviour
{

    public GameObject textObject;
    string filePath = "Assets/Files/scores.csv";

    void Start()
    {
        if (!File.Exists(filePath))
        {
            string[] createText = { "Bubble Popper,0", "Painting,0"};
            File.WriteAllLines(filePath, createText);
        }

        string[] fileLines = File.ReadAllLines(filePath);

        foreach (string line in fileLines)
        {
            string[] words = line.Split(',');

            textObject.GetComponent<Text>().text += words[0] + " score: " + words[1] + "\n";
        }
    }

}
