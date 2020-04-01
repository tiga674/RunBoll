using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    float timer;
    GameObject randomObject;

    public Text timeText;
    public bool timeFlg = true;
    public GameObject player;
    public GameObject SDP;
    public GameObject SUP;
    public GameObject Goal;
    public GameObject[] Stages;
    public int StageLength;
   
    
    void Start()
    {
        StageGenerate();
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
        /*if (timer < 4)
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
        }*/
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

    void StageGenerate()
    {
        //生成するステージの個数を決める
        int StageCount = (int)Goal.transform.position.z / StageLength - 2;

        //ステージをランダムに生成
        for (int i = 0; i <= StageCount; i++)
        {
            int StageChip = Random.Range(0, Stages.Length);
            Instantiate
                (Stages[StageChip],
                new Vector3(0, 0, (i + 1) * 10),
                Quaternion.identity
                );
        }
    }
}
