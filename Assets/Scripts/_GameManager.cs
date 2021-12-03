using UnityEngine.UI;
using UnityEngine;

public class _GameManager : MonoBehaviour
{

    public GameObject endUI;
    public GameObject inGameUI;
    public GameObject startGameUI;
    public Text scoreText;

    private int platformUnder = 0;
    private int score = 0;
    public int endScore = 0;

    public int PlatformUnder
    {
        get
        {
            return platformUnder;
        }
        set
        {
            platformUnder = value;
        }
    }

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            scoreText.text = score.ToString();

        }
    }


}
