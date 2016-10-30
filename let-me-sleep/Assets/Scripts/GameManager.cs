using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    private static AudioSource _audio;

    private const string playerPrefsKey = "LetMeSleepHighScores";
    private static string[] highscores = null;
    
    
    void Awake()
    {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            _instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }


    public static GameManager instance
    {
        get
        {
            return _instance;
        }
    }

    public static string[] getHighscores()
    {
        if (highscores == null)
        {
            highscores = PlayerPrefsX.GetStringArray(playerPrefsKey);
        }
        //resetHighscores();
        return highscores;
    }

    public static void saveHighScores(string[] newscores)
    {
        PlayerPrefsX.SetStringArray(playerPrefsKey, newscores);
        highscores = newscores;
    }

    public static void resetHighscores()
    {
        saveHighScores(new string[0]);
    }

    public static void startMusic()
    {
        if (_audio == null)
        {
            _audio = GameManager.instance.GetComponentInChildren<AudioSource>();
            _audio.Play();
        }
    }

}