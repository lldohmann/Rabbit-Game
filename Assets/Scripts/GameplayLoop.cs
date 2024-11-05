using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using TMPro;

public class GameplayLoop : MonoBehaviour
{
    public float jingleTimer = 10.0f;
    private float timer = 0.0f;
    public GameObject videoObj;
    public GameObject playerReadyText;
    public GameObject scoreText;
    public GameObject highScoreText;
    public float growthRate = 0.01f;
    private float scoreRaw = 0.0f;
    private int score = 0;
    private VideoPlayer videoPlayer;
    private bool isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = videoObj.GetComponent<VideoPlayer>();
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "APPLEBLOOM.mp4");
        Debug.Log(System.IO.Path.Combine(Application.streamingAssetsPath, "APPLEBLOOM.mp4"));
        videoPlayer.Pause();
        videoPlayer.loopPointReached += EndReached;
        highScoreText.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("HighScore", 123456).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // START - Timer is on, this is to make the player wait for jingle to end before playing
        timer += Time.deltaTime;
        if (timer >= jingleTimer)  // END - This is the check for when the jingle is done playing
        {
            playerReadyText.SetActive(false);
            if (Input.GetButton("Horizontal"))
            {
                    PlayVideo();
            }
            else if (Input.GetButtonUp("Horizontal"))
            {
                PauseVideo();
            }
            if (score >= PlayerPrefs.GetInt("HighScore", 123456)) // Check if player has beaten preset highscore
            {
                highScoreText.GetComponent<TextMeshProUGUI>().text = score.ToString();
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
    }
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        // Load to title screen
        SceneManager.LoadScene("Title");
    }
    public void PlayVideo()
    {
        if (timer >= jingleTimer)
        {
            videoPlayer.Play();
            scoreRaw += growthRate * Time.fixedDeltaTime;
            score += Mathf.RoundToInt(scoreRaw);
        }
        scoreText.GetComponent<TextMeshProUGUI>().text = score.ToString();
    }
    public void PauseVideo()
    {
        videoPlayer.Pause();
    }
}
