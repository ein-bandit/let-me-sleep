using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeManager : MonoBehaviour {

    bool stopTime = false;
    bool showScore = false;
    float timeLasted = 0.0f;
    float remainingTime = 5.4f;
    float bonusTime = 3.0f;
    public Text uiText;
    public Text totalScore;
    public InputField playerName;
    public SaveHighscore saveHighscoreScript;
    public GameObject scoreCanvas;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if(!stopTime)
        {
            remainingTime -= Time.deltaTime;
            timeLasted += Time.deltaTime;
            uiText.text = remainingTime.ToString("#");
            if(remainingTime <= 0.0f)
            {
                showScore = true;
                Time.timeScale = 0f;
                stopTime = true;
                
            }
        }

        scoreCanvas.SetActive(showScore);
        if(showScore && Input.GetKeyDown("return"))
        {
            int highscoreToSafe = (int) Mathf.Round(timeLasted);
            saveHighscoreScript.saveHighScore(playerName.text,highscoreToSafe);
        }

	}

    public void addTime()
    {
        remainingTime += bonusTime;
    }
}
