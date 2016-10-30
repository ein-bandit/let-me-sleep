using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class HighscoreScript : MonoBehaviour
{

    private string[] currentHighScores;
    private GameObject highScoreLine;

    private Button backButton;

    // Use this for initialization
    void Start()
    {
        backButton = GameObject.FindGameObjectWithTag("Back").GetComponent<Button>();
        backButton.onClick.AddListener(() => SceneManager.LoadScene("Menu"));

        //get playerrefsx data for highscores
        highScoreLine = (GameObject)Resources.Load("HighscoreLinePrefab", typeof(GameObject));
        currentHighScores = GameManager.getHighscores();
        generateCurrentHighScores();
    }

    private void generateCurrentHighScores()
    {
        for (int i = 0; i < currentHighScores.Length; i++)
        {
            GameObject highScoreClone =
                (GameObject)Instantiate(highScoreLine, highScoreLine.transform.position, highScoreLine.transform.rotation);


            //edit text data
            foreach (Text t in highScoreClone.GetComponentsInChildren<Text>())
            {                
                if (t.name == "Position")
                {                  
                    t.text = (i + 1).ToString();
                }
                else if (t.name == "Name")
                {
                    t.text = currentHighScores[i].Split(',')[0];
                }
                else if (t.name == "Score")
                {
                    t.text = currentHighScores[i].Split(',')[1];
                }
            }
            highScoreClone.transform.SetParent(GameObject.FindGameObjectWithTag("HighscoreList").transform);
        }

    }

}
