using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Timer").GetComponent<Text>().text = string.Format("{0:000}", GameManager.Instance.timer); ;
        GameObject.Find("Coin").GetComponent<Text>().text = string.Format("{0:00}", GameManager.Instance.coins);//coins.ToString();
        if (SceneManager.GetActiveScene().name == "Title")
        {
            GameObject.Find("Score").GetComponent<Text>().text = string.Format("{0:00000000}", GameManager.Instance.highscore);
        }
        else
        {
            GameObject.Find("Score").GetComponent<Text>().text = string.Format("{0:00000000}", GameManager.Instance.score);
        }
        if (SceneManager.GetActiveScene().name == "LevelPreview")
        {
            //GameObject.Find("Lives").GetComponent<Text>().text = GameManager.Instance.lives.ToString();
            GameObject.Find("Scene").GetComponent<Text>().text = $"{GameManager.Instance.world}-{GameManager.Instance.stage}";
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("Timer").GetComponent<Text>().text = string.Format("{0:000}", GameManager.Instance.timer); ;
        GameObject.Find("Coin").GetComponent<Text>().text = string.Format("{0:00}", GameManager.Instance.coins);//coins.ToString();
        if (SceneManager.GetActiveScene().name == "Title")
        {
            GameObject.Find("Score").GetComponent<Text>().text = string.Format("{0:00000000}", GameManager.Instance.highscore);
        } else
        {
            GameObject.Find("Score").GetComponent<Text>().text = string.Format("{0:00000000}", GameManager.Instance.score);
        }
    }
}
