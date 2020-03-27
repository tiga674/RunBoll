using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultScript : MonoBehaviour
{
    public Text fasttimetext;
    public Text newtimetext;
    private float goaltime;
    private float fasttime;
    void Start()
    {
        goaltime = PlayerPrefs.GetFloat("goaltime");

        if (PlayerPrefs.HasKey("fasttime"))
        {
            fasttime = PlayerPrefs.GetFloat("fasttime");
        }
        else
        {
            fasttime = 0;
        }
    }
    void Update()
    {
        if (fasttime == 0 || goaltime < fasttime)
        {
            fasttimetext.text = "Fasttime:" + goaltime.ToString("F1");
            newtimetext.text = "Nowtime:" + goaltime.ToString("F1");
            PlayerPrefs.SetFloat("fasttime", goaltime);
        }
        else
        {
            fasttimetext.text = "Fasttime:" + fasttime.ToString("F1");
            newtimetext.text = "Nowtime:" + goaltime.ToString("F1");
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
