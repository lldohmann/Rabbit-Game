using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

using System.Collections;

/// <summary>
///  Class <c>GameManager</c> is a singleton that holds 
///  game data (Lives, Coins, Timer, Score, High Score) &
///  Basic scene management functions (NewGame, ResetGame, LoadPreview, LoadLevel)
///  Other gameobjects call this class to affect game flow or add to data. 
/// </summary>
public class GameManager : MonoBehaviour
{
    public AudioSource coinSound;
    public AudioSource extraLifeSound;
    public AudioSource clockSound;
    public static GameManager Instance { get; private set; }
    public Canvas canvas;

    public int world { get; private set; }
    public int stage { get; private set; }
    public int lives { get; private set; }
    public int coins { get; private set; }
    public int score { get; private set; }
    public int highscore { get; private set; }
    public float timer { get; private set; }

    /// <summary>
    /// Method <c>Awake</c> creates singleton model. 
    /// </summary>
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            DestroyObject(gameObject);
        }
        DontDestroyOnLoad(gameObject);  
    }

    private void OnDestroy()
    {
        if (Instance == this) {
            Instance = null;
        }
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        if (SceneManager.GetActiveScene().name == "Title")
        {
            timer = 0;
            //GameObject.Find("Timer").GetComponent<Text>().text = timer.ToString();
        }
        if (SceneManager.GetActiveScene().name == "Game Over")
        {
            SceneManager.LoadScene("Title");
        }
    }
    /// <summary>
    /// Method <c>Update</c> just updates stage timer.
    /// </summary>
    public void Update()
    {
        if (SceneManager.GetActiveScene().name == "Title")
        {

        }
        else if (SceneManager.GetActiveScene().name == "Game Over")
        {
            
        }
        else if (SceneManager.GetActiveScene().name == "Level Preview")
        {
            //GameObject.Find("Coin").GetComponent<Text>().text = string.Format("{0:00}", coins);//coins.ToString();
            //GameObject.Find("Score").GetComponent<Text>().text = string.Format("{0:00000000}", score); //score.ToString();
            //GameObject.Find("Lifes").GetComponent<Text>().text = lives.ToString();
        }
        else
        {
            //GameObject.Find("Coin").GetComponent<Text>().text = string.Format("{0:00}", coins);//coins.ToString();
            //GameObject.Find("Score").GetComponent<Text>().text = string.Format("{0:00000000}", score); //score.ToString();
            //if (GameObject.Find("Timer"))
            //{
                //GameObject.Find("Timer").GetComponent<Text>().text = timer.ToString();
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                if (world == 1 && stage == 7)
                {
                    stage = 4;
                    LoadPreview();
                }
                    ResetLevel();
                }
            //}
        }
    }

    /// <summary>
    /// Method <c>NewGame</c> Loads first level data and resets all data but highscore.
    /// Then calls the LevelPreview scene of the first level.
    /// </summary>
    public void NewGame()
    {
        lives = 3;
        coins = 0;
        timer = 255;
        world = 1;
        stage = 1;
        score = 0;

        LoadPreview(5);
    }

    /// <summary>
    /// Method <c>LoadLevel</c> sets the world and stage variables
    /// and loads the level scene immediately. No Preview. :(
    /// </summary>
    /// <param name="world"></param>
    /// <param name="stage"></param>
    public void LoadLevel(int world, int stage)
    {
        this.world = world;
        this.stage = stage;

        SceneManager.LoadScene($"{world}-{stage}");

        //GameObject.Find("Scene").GetComponent<Text>().text = this.world.ToString() + "-" + this.stage.ToString();
    }

    public void LoadLevel()
    {

        SceneManager.LoadScene($"{world}-{stage}");

        //GameObject.Find("Scene").GetComponent<Text>().text = this.world.ToString() + "-" + this.stage.ToString();
    }

    public void LoadPreview(int delay)
    {
        SceneManager.LoadScene("Level Preview");
        CancelInvoke(nameof(LoadPreview));
        Invoke(nameof(LoadLevel), delay);
    }
    public void LoadPreview()
    {
        SceneManager.LoadScene("Level Preview");

        //StartCoroutine(Waiting(5));

        LoadLevel(world, stage);
    }

    IEnumerator Waiting(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

    public void ChangeLevel(int newWorld)
    {
        world = newWorld;
        //stage = newStage;
        LoadLevel(world, stage);
    }

    public void NextLevel()
    {
        stage++;
        timer = 255;
        // TO DO IF STATEMENTS FOR SPECIFIC STAGES WITH LESS TIME THAN NORMAL
        if (stage > 5)
        {
            GameOver(10);
        }
        LoadPreview(5);
    }

    public void KickHisSorryAss()
    {
        world = 1;
        stage = 7;
        timer = 33;
        
        LoadPreview(5);
    }

    public void ResetLevel(float delay)
    {
        CancelInvoke(nameof(ResetLevel));
        Invoke(nameof(ResetLevel), delay);
    }

    public void GameOver(int delay)
    {
        SceneManager.LoadScene("Game Over");
        CancelInvoke(nameof(GameOver));
        Invoke(nameof(Start), delay);
    }

    public void ResetLevel()
    {
        lives--;
        timer = 256;

        if (lives > 0) {
            LoadPreview(5);
        } else {
            //SceneManager.LoadScene("Game Over");
            GameOver(10);
        }
    }

    // ITEMS & SCORE

    public void AddCoin()
    {
        coins++;
        Debug.Log(coins.ToString());
        coinSound.Play();
        //GameObject.Find("Coin").GetComponent<Text>().text = coins.ToString();
        if (coins == 100)
        {
            coins = 0;
            AddLife();
        }
    }

    public void AddLife()
    {
        lives++;
        extraLifeSound.Play();
        Debug.Log("Life: " + lives.ToString());
    }

    public void AddScore(int points)
    {
        score += points;
        //GameObject.Find("Score").GetComponent<Text>().text = score.ToString();
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("highscore", score);
            Debug.Log("Highscore: " + highscore.ToString());
        }
        Debug.Log("Score: " + score.ToString());
    }

    public void AddTime()
    {
        timer += 50.0f;
        clockSound.Play();
    }
}
