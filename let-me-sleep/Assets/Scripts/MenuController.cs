using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    private Button audioButton;
    private Button highScoreButton;
    private Button startButton;
    private Button howToButton;
    private bool soundMuted = false;


    // Use this for initialization
    void Start () {
        audioButton = GameObject.FindGameObjectWithTag("MuteButton").GetComponent<Button>();
        highScoreButton = GameObject.FindGameObjectWithTag("Highscore").GetComponent<Button>();
        startButton = GameObject.FindGameObjectWithTag("Game").GetComponent<Button>();
        howToButton = GameObject.FindGameObjectWithTag("HowTo").GetComponent<Button>();
        audioButton.onClick.AddListener(() => ToggleMuteSound());
        highScoreButton.onClick.AddListener(() => SceneManager.LoadScene("Highscore"));
        startButton.onClick.AddListener(() => SceneManager.LoadScene("Game"));
        howToButton.onClick.AddListener(() => SceneManager.LoadScene("HowTo"));
        GameManager.startMusic();
    }
        

    void ToggleMuteSound()
    {
        soundMuted = !soundMuted;
        AudioListener.volume = soundMuted ? 0 : 1;
    }
}
