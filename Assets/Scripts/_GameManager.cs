using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _GameManager : MonoBehaviour
{

    public GameObject endUI;
    public GameObject inGameUI;
    public GameObject startGameUI;
    public Text scoreText;

    private int platformUnder = 0;
    private int score = 0;
    public int endScore = 0;

    public bool endgame = false;
    public bool Ispaused = true;

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

    public void Playbutton()
    {
        
        startGameUI.SetActive(false);
        Ispaused = false;
    }

    void Start()
    {
        startGameUI.SetActive(true);
        inGameUI.SetActive(false);
        endUI.SetActive(false);
    }
    void Update()
    {
        

        if (endgame == true)
        {
            endUI.SetActive(true);
        }

        else
        {
            endUI.SetActive(false);
        }

        if (Ispaused == true)
        {
            Time.timeScale = 0;
            Time.fixedDeltaTime = 0;

        }
        else
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f;
        }

    }



}
