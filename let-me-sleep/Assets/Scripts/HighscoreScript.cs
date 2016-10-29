using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class HighscoreScript : MonoBehaviour
{

    private string[] currentHighScores;
    private GameObject highScoreLine;

    private UnityEngine.UI.Button backButton;

    // Use this for initialization
    void Start()
    {
        Debug.Log("start highscore script");
        backButton = GameObject.FindGameObjectWithTag("Back").GetComponent<Button>();
        backButton.onClick.AddListener(() => UnityEngine.SceneManagement.SceneManager.LoadScene("Menu"));

        //get playerrefsx data for highscores
        highScoreLine = (GameObject)Resources.Load("HighscoreLinePrefab", typeof(GameObject));
        currentHighScores = GameManager.getHighscores();
        generateCurrentHighScores();
    }

    private void generateCurrentHighScores()
    {

        Debug.Log("printing # highscores " + currentHighScores.Length);
        for (int i = 0; i < currentHighScores.Length; i++)
        {
            GameObject highScoreClone =
                (GameObject)Instantiate(highScoreLine, highScoreLine.transform.position, highScoreLine.transform.rotation);


            //edit text data
            Debug.Log("text childs " + highScoreClone.GetComponentsInChildren<Text>().Length);
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
