using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    //タイムを表示するのに使う
    float timer;
    public Text timeText;
    public bool timeFlg = true;

    public GameObject player;
    public GameObject SDP;
    public GameObject SUP;
    GameObject randomObject;
    
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        //タイムを表示
        if (timeFlg)
        {
            timer += Time.fixedDeltaTime;
            timeText.text = this.timer.ToString("F1");
        }
        //コース上にSDPとSUPを置く
        if (timer < 4)
        {
            int random = Random.Range(1, 31);
            if (random <= 1)
            {
                randomObject = Instantiate(SUP) as GameObject;
            }
            else if (random == 2)
            {
                randomObject = Instantiate(SDP) as GameObject;
            }
            else
            {
                randomObject = null;
            }
            int x = Random.Range(-2, 2);
            int z = Random.Range(3, 40);
            if (randomObject != null)
            {
                randomObject.transform.position = new Vector3(x, 0, z);
            }
        } else if(timer >= 4 && timer < 10)
        {
            int random = Random.Range(1, 31);
            if (random == 1)
            {
                randomObject = Instantiate(SUP) as GameObject;
            }
            else if (random == 2)
            {
                randomObject = Instantiate(SDP) as GameObject;
            }
            else
            {
                randomObject = null;
            }
            int x = Random.Range(-2, 2);
            int z = Random.Range(41, 170);
            if (randomObject != null)
            {
                randomObject.transform.position = new Vector3(x, 0, z);
            }
        }
    }

    void Update()
    {
        
    }

    public void OnRetryButtonClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnResultButtonClick()
    {
        PlayerPrefs.SetFloat("goaltime",timer);
        SceneManager.LoadScene("ResultScene");
    }
}
