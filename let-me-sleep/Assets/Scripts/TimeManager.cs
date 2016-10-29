using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TimeManager : MonoBehaviour {

    public Text uiText;
    public InputField playerName;
    public SaveHighscore saveHighscoreScript;
    public GameObject scoreCanvas;


    bool stopTime;
    bool showScore;
    float timeLasted = 0.0f; // used for score
    float remainingTime = 5.4f; // used to determine how long game lasts
    float bonusTime = 1.0f; // amount of time bonus you get on shot

	// Use this for initialization
	void Start () {
        
        stopTime = false;
        showScore = false;
        Time.timeScale = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if(!stopTime)
        {
            remainingTime -= Time.deltaTime;
            timeLasted += Time.deltaTime;
            uiText.text = remainingTime.ToString("#");

            // if time runs out -> show score canvas with input field for player
            if(remainingTime <= 0.0f)
            {
                // set canvas score variable to true
                showScore = true;

                // stop game times
                Time.timeScale = 0f;
                stopTime = true;
                
            }
        }
        // show canvas for player name
        scoreCanvas.SetActive(showScore);
        // set focus on player input field
        EventSystem.current.SetSelectedGameObject(playerName.gameObject, null);
        playerName.OnPointerClick(new PointerEventData(EventSystem.current));

        if (showScore && Input.GetKeyDown("return"))
        {
            int highscoreToSafe = (int) Mathf.Round(timeLasted);
            saveHighscoreScript.saveHighScore(playerName.text,highscoreToSafe);
            SceneManager.LoadScene("Highscore");
        }
	}

    public void addTime()
    {
        remainingTime += bonusTime;
    }
}
