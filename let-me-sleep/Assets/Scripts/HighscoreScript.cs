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
        backButton = GameObject.FindGameObjectWithTag("Back").GetComponent<Button>();
        backButton.onClick.AddListener(() => UnityEngine.SceneManagement.SceneManager.LoadScene("Menu"));
        
        //get playerrefsx data for highscores
        highScoreLine = (GameObject)Resources.Load("HighScoreLinePrefab", typeof(GameObject));
        currentHighScores = GameManager.getHighscores();

        Debug.Log("inside highscore start");
        generateCurrentHighScores();
    }

    private void generateCurrentHighScores()
    {
        Debug.Log("printing # highscores " + currentHighScores.Length);
        for (int i = 0; i < currentHighScores.Length; i++)
        {
            //get prefab
            GameObject highScoreClone = (GameObject)Instantiate(highScoreLine, highScoreLine.transform.position, highScoreLine.transform.rotation);
            Vector3 temp = highScoreClone.transform.position;
            temp.y -= 10;

            //edit text data
            Debug.Log("text childs " + highScoreLine.GetComponentsInChildren<Text>().Length);
            foreach (Text t in highScoreLine.GetComponentsInChildren<Text>())
            {
                Debug.Log(t.name);
                if (t.name == "Position")
                {
                    Debug.Log("setting pos");
                    t.text = (i + 1).ToString();
                }
                else if (t.name == "Name")
                {
                    Debug.Log("setting Name");
                    t.text = currentHighScores[i].Split(',')[0];
                }
                else if (t.name == "Score")
                {
                    Debug.Log("setting Score");
                    t.text = currentHighScores[i].Split(',')[1];
                }
                Debug.Log(t.text);
            }
            highScoreClone.transform.SetParent(GameObject.FindGameObjectWithTag("HighscoreList").transform);
        }
    }

}
