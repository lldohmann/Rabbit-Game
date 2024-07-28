using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Canvas canvas;

    public int world { get; private set; }
    public int stage { get; private set; }
    public int lives { get; private set; }
    public int coins { get; private set; }
    public int score { get; private set; }
    public int highscore { get; private set; }
    public float timer { get; private set; }

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

        }
        else
        {
            NewGame();
        }
    }

    public void Update()
    {
        if (GameObject.Find("Timer"))
        {
            GameObject.Find("Timer").GetComponent<Text>().text = timer.ToString();
            timer -= Time.deltaTime;
            if (timer == 0)
            {
                ResetLevel();
            }
        }
    }

    public void NewGame()
    {
        lives = 3;
        coins = 0;
        timer = 255;

        LoadLevel(1, 1);
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Game Over");

        StartCoroutine(Waiting(10));

        //SceneManager.LoadScene("Title");
    }

    public void LoadLevel(int world, int stage)
    {
        this.world = world;
        this.stage = stage;

        SceneManager.LoadScene($"{world}-{stage}");

        //GameObject.Find("Scene").GetComponent<Text>().text = this.world.ToString() + "-" + this.stage.ToString();
    }

    public void LoadPreview(int world, int stage)
    {
        SceneManager.LoadScene("Level Preview");

        StartCoroutine(Waiting(5));

        LoadLevel(world, stage);
    }

    IEnumerator Waiting(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

    public void NextLevel()
    {
        LoadLevel(world, stage + 1);
    }

    public void ResetLevel(float delay)
    {
        CancelInvoke(nameof(ResetLevel));
        Invoke(nameof(ResetLevel), delay);
    }

    public void ResetLevel()
    {
        lives--;

        if (lives > 0) {
            LoadPreview(world, stage);
        } else {
            GameOver();
        }
    }

    public void AddCoin()
    {
        coins++;
        Debug.Log(coins.ToString());
        GameObject.Find("Coin").GetComponent<Text>().text = coins.ToString();
        if (coins == 100)
        {
            coins = 0;
            AddLife();
        }
    }

    public void AddLife()
    {
        lives++;
        Debug.Log("Life: " + lives.ToString());
    }

    public void AddScore(int points)
    {
        score += points;
        GameObject.Find("Score").GetComponent<Text>().text = score.ToString();
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("highscore", score);
            Debug.Log("Highscore: " + highscore.ToString());
        }
        Debug.Log("Score: " + score.ToString());
    }

}
