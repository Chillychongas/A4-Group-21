using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class drawSphere : MonoBehaviour
{

    public GameObject sphere;
    public Material curMat;

    Ray ray;
    RaycastHit hit;

    private int score;

    private string Line1;
    private string Line2;
    string filePath = "Assets/Files/scores.csv";

    void Start()
    {
        score = 0;

        StartCoroutine(createSphere());

        if (!File.Exists(filePath))
        {
            string[] createText = { "Bubble Popper,0", "Painting,0"};
            File.WriteAllLines(filePath, createText);
        }
    }

    void scoreCheck() 
    {
        string[] fileLines = File.ReadAllLines(filePath);

        foreach (string line in fileLines)
        {
            string[] words = line.Split(',');

            if (words[0] == "Painting")
            {
                if (int.Parse(words[1]) < score)
                {
                    words[1] = score.ToString();

                    Line2 = words[0] + "," + words[1];
                    string strout = Line1 + '\n' + Line2;
                    File.WriteAllText(filePath, strout);
                }
            }
            else { Line1 = line; }
        }
    }


    IEnumerator createSphere() {
        while (true) 
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (Input.GetMouseButton(0))
                {
                    if (hit.collider.tag.Equals("canvas") || hit.collider.tag.Equals("sphere"))
                    {
                        score++;
                        GameObject dot = Instantiate(sphere, new Vector3(hit.point.x, hit.point.y, 4), Quaternion.identity) as GameObject;
                        dot.GetComponent<MeshRenderer>().material = curMat;
                        scoreCheck();
                    }
                    else if (hit.collider.tag.Equals("color_select"))
                    {
                        curMat = hit.collider.gameObject.GetComponent<MeshRenderer>().material;

                    }

                    yield return new WaitForSeconds(0.1f);
                }
                else if (Input.GetMouseButton(1))
                {
                    if (hit.collider.tag.Equals("sphere"))
                    {
                        Destroy(hit.transform.gameObject);
                    }
                }
            }

            yield return null;
        }
    }
}
