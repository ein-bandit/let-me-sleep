using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class HighscoreScript : MonoBehaviour {

    private  const string playerPrefsKey = "LetMeSleepHighScores";
    private string[] currentHighScores;
    private GameObject highScoreLine;


    private UnityEngine.UI.Button backButton;

    // Use this for initialization
    void Start () {
        backButton = GameObject.FindGameObjectWithTag("Back").GetComponent<Button>();
        backButton.onClick.AddListener(() => UnityEngine.SceneManagement.SceneManager.LoadScene("Menu"));


        //get playerrefsx data for highscores
        highScoreLine = (GameObject)Resources.Load("HighScoreLinePrefab", typeof(GameObject));
        currentHighScores = PlayerPrefsX.GetStringArray(playerPrefsKey);


        int highScoreLength = 10;
        if (currentHighScores.Length <= 10)
        {
            highScoreLength = currentHighScores.Length;
        }

        for ( int i = 0; i < highScoreLength; i++)
        {
            //get prefab
            GameObject highScoreClone = (GameObject)Instantiate(highScoreLine, highScoreLine.transform.position, highScoreLine.transform.rotation);
            Vector3 temp = highScoreClone.transform.position;
            temp.y -= 10;

            //edit text data
            foreach ( Text t in highScoreLine.GetComponentsInChildren<Text>())
            {
                if (t.name == "Position")
                {
                    t.text = i.ToString();
                } else if(t.name == "Name")
                {
                    t.text = currentHighScores[i].Split(',')[0];
                } else if(t.name == "Score")
                {
                    t.text = currentHighScores[i].Split(',')[1];
                }
            }
        }
	}
	
}
