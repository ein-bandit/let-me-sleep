using UnityEngine;
using System.Collections;

public class SaveHighscore : MonoBehaviour
{

    private string[] currentHighScores;

    // Use this for initialization
    void Start()
    {
        currentHighScores = GameManager.getHighscores();
        foreach (string str in currentHighScores)
        {
            Debug.Log(str);
        }
        Debug.Log("currentHighscoreLength " + currentHighScores.Length);
    }

    public void saveHighScore(string name, int score)
    {
        Debug.Log("trying to save highscore");
        int newHighscoreIndex = 0;

        int loop = 10;
        if (currentHighScores.Length < 10)
        {
            loop = currentHighScores.Length;
        }

        //find position for score
        for (int i = 0; i < loop; i++)
        {
            int temp = int.Parse(currentHighScores[i].Split(',')[1]);
            if (temp <= score)
            {
                newHighscoreIndex = i;
                break;
            }
        }

        Debug.Log("newHighscoreIndex " + newHighscoreIndex);

        string highscore = name + ',' + score.ToString();
        Debug.Log("new high score: " + highscore);
        //save last highscore at this position
        string nextValue = currentHighScores[newHighscoreIndex];
        Debug.Log("nextvalue: " + nextValue);
        //save new highscore at new position.
        currentHighScores[newHighscoreIndex] = highscore;

        //enlarge array if not 10
        if (currentHighScores.Length < 10)
        {
            string[] newArray = new string[currentHighScores.Length + 1];
            for (int i = 0; i < currentHighScores.Length; i++)
            {
                newArray[i] = currentHighScores[i];
            }
            currentHighScores = newArray;
        }

        

        for (int i = newHighscoreIndex + 1; i < loop; i++)
        {
                string temp = currentHighScores[i];
                currentHighScores[i] = nextValue;
                nextValue = temp;
        }

        GameManager.saveHighScores(currentHighScores);

    }
}
