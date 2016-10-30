using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    private UnityEngine.UI.Button audioButton;
    private UnityEngine.UI.Button highScoreButton;
    private UnityEngine.UI.Button startButton;
    private UnityEngine.UI.Button howToButton;
    private bool soundMuted = false;


    // Use this for initialization
    void Start () {
        audioButton = GameObject.FindGameObjectWithTag("MuteButton").GetComponent<Button>();
        highScoreButton = GameObject.FindGameObjectWithTag("Highscore").GetComponent<Button>();
        startButton = GameObject.FindGameObjectWithTag("Game").GetComponent<Button>();
        howToButton = GameObject.FindGameObjectWithTag("HowTo").GetComponent<Button>();
        audioButton.onClick.AddListener(() => ToggleMuteSound());
        highScoreButton.onClick.AddListener(() => loadScene("Highscore"));
        startButton.onClick.AddListener(() => loadScene("Game"));
        howToButton.onClick.AddListener(() => loadScene("HowTo"));
        GameManager.startMusic();
    }


    void loadScene(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
    

    void ToggleMuteSound()
    {
        soundMuted = !soundMuted;
        AudioListener.volume = soundMuted ? 0 : 1;
        Debug.Log("sound is muted: " + soundMuted);
    }
}
