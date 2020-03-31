using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultScript : MonoBehaviour
{
    public Text fastTimeText;
    public Text newTimeText;
    private float goalTime;
    private float fastTime;
    void Start()
    {
        goalTime = PlayerPrefs.GetFloat("goaltime");

        if (PlayerPrefs.HasKey("fasttime"))
        {
            fastTime = PlayerPrefs.GetFloat("fasttime");
        }
        else
        {
            fastTime = 0;
        }
    }
    void Update()
    {
        if (fastTime == 0 || goalTime < fastTime)
        {
            fastTimeText.text = "Fasttime:" + goalTime.ToString("F1");
            newTimeText.text = "Nowtime:" + goalTime.ToString("F1");
            PlayerPrefs.SetFloat("fasttime", goalTime);
        }
        else
        {
            fastTimeText.text = "Fasttime:" + fastTime.ToString("F1");
            newTimeText.text = "Nowtime:" + goalTime.ToString("F1");
        }

    }

    public void OnRetryButtonClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    //　ゲーム終了ボタンを押したら実行する
    public void EndGame()
    {
        Application.Quit();
    }
}
