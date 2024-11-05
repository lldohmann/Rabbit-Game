using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviewMessage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.stage == 1)
        {
            gameObject.GetComponent<Text>().text = "MYSTERY ADVENTURE AWAITS...";
        }
        else if (GameManager.Instance.stage == 2)
        {
            GameObject.Find("Message").GetComponent<Text>().text = "INTO THE DARK CAVE...";
        }
        else if (GameManager.Instance.stage == 3)
        {
            GameObject.Find("Message").GetComponent<Text>().text = "FALLING DOWN THE RABBIT HOLE...";
        }
        else if (GameManager.Instance.stage == 4)
        {
            GameObject.Find("Message").GetComponent<Text>().text = "QUIZ TIME!";
        }
        else if (GameManager.Instance.stage == 5)
        {
            GameObject.Find("Message").GetComponent<Text>().text = "SWIMMING IN A RIVER OF TEARS";
        }
        else if (GameManager.Instance.stage == 6)
        {
            GameObject.Find("Message").GetComponent<Text>().text = "HIGH UP IN THE SKY...";
        }
        else if (GameManager.Instance.stage == 7)
        {
            GameObject.Find("Message").GetComponent<Text>().text = "WRONG";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
