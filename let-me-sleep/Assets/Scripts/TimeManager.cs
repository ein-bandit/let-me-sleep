using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TimeManager : MonoBehaviour
{

    public Text uiText;
    public InputField playerName;
    public SaveHighscore saveHighscoreScript;
    public GameObject scoreCanvas;

    public GameObject GameOver;

    //dummy init
    private int points_hits = 0;
    private int points_misses = 0;

    bool stopTime;
    bool showScore;
    float timeLasted = 0.0f; // used for score
    float remainingTime = 15.4f; // used to determine how long game lasts
    float bonusTime = 1.0f; // amount of time bonus you get on shot

    // Use this for initialization
    void Start()
    {

        GameOver.GetComponent<SpriteRenderer>().enabled = false;
        stopTime = false;
        showScore = false;
        Time.timeScale = 1.0f;

        //override points if not first time in scene;
        points_hits = 0;
        points_misses = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopTime)
        {
            remainingTime -= Time.deltaTime;
            timeLasted += Time.deltaTime;
            GameObject.FindGameObjectWithTag("AlarmTime").GetComponent<Text>().text = remainingTime.ToString("#");
            //uiText.text = remainingTime.ToString("#");

            // if time runs out -> show score canvas with input field for player
            if (remainingTime <= 0.0f)
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

        if (showScore)
        {

            GameOver.GetComponent<SpriteRenderer>().enabled = true;

            if (Input.GetKeyDown("return"))
            {
                //implement a crazy function using points_ vars and timelasted.
                //int highscoreToSafe = (int) Mathf.Round(timeLasted);
                saveHighscoreScript.saveHighScore(playerName.text, points_hits);
                SceneManager.LoadScene("Highscore");
            }
        }
    }


    public void addClick(bool hit)
    {
        if (hit)
        {
            points_hits += 1;
            remainingTime += bonusTime;
        }
        else
        {
            points_misses += 1;
        }
    }

    public bool timeHasStopped()
    {
        return stopTime;
    }
}
