

public class GameManager
{
    private GameManager _instance;

    private const string playerPrefsKey = "LetMeSleepHighScores";
    private static string[] highscores = null;
    
    public GameManager instance
    {
        get
        {
            if (_instance == null)
                _instance = new GameManager();
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
    
}