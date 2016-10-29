using UnityEngine;
using System.Collections;

public class SaveHighscore : MonoBehaviour {

    private const string playerPrefsKey = "LetMeSleepHighScores";
    private string[] currentHighScores;

    // Use this for initialization
    void Start () {
        currentHighScores = PlayerPrefsX.GetStringArray(playerPrefsKey);
    }
	
	void saveHighScore(string name, int score)
    {
        var highscoreIndex = 0;
        var loop = 10;
        if (currentHighScores.Length <= 10)
        {
            loop = currentHighScores.Length;
        }
        //find position for score
        for (int i = 0; i < loop; i++)
        {
            int temp = int.Parse( currentHighScores[i].Split(',')[1]);
            if (temp <= score)
            {
                highscoreIndex = i;
            }
        }

        string highscore = name + ',' + score.ToString();

        //save last highscore at this position
        string nextValue = currentHighScores[highscoreIndex];
        //save new highscore at new position.
        currentHighScores[highscoreIndex] = highscore;

        //loop for highscores on indices highscoreindex ++ and set the respective last highscore at i+1.
        int restOfArray = loop - highscoreIndex;
        //loop (10 or less) - highscoreIndex (pos of new highscore) - 1 (last highscore will drop out if highscore already full (10)).
        if (loop == 10)
        {
            restOfArray -= 1;
        }
        for (int i = highscoreIndex + 1; i < restOfArray; i++)
        {
            string temp = currentHighScores[i];
            currentHighScores[i] = nextValue;
            nextValue = temp;
        }

        PlayerPrefsX.SetStringArray(playerPrefsKey, currentHighScores);

    }
}
