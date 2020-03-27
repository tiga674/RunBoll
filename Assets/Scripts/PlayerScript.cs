using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody rg;
    public float playersp = 50f; //プレイヤーの速度
    public Text goaltext;
    public GameObject retrybutton;
    public GameObject resultbutton;

    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        //プレイヤーの左右移動
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += transform.right * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= transform.right * Time.deltaTime;
        }

        //プレイヤーが前進
        if (Input.GetKey(KeyCode.Z))
        {
            rg.AddForce(new Vector3(0, 0, playersp));
        }

        //落下したらゲームオーバー
        if (transform.position.y < -10)
        {
            goaltext.text = "GAMEOVER";
            retrybutton.SetActive(true);
            rg.velocity = Vector3.zero;
        }

        if (transform.position.z >= 195)
        {
            goaltext.text = "GOAL!!";
            resultbutton.SetActive(true); //retrybuttonを表示する
            rg.velocity = Vector3.zero;
            GameObject.Find("GameManager").GetComponent<GameManage>().timeflg
                = false; //タイマーを止める

        }
    }

    //他のオブジェクトとの接触の処理
    void OnTriggerEnter(Collider collider)
    {
        //SpeedUpPlateのとき
        if (collider.gameObject.tag == "SUP")
        {
            playersp += 10f;
            rg.AddForce(new Vector3(0, 0, 5));
        }
        //SpeedDownPlateのとき
        if (collider.gameObject.tag == "SDP")
        {
            playersp -= 1f;

        }
        //Goalのとき
        
        Destroy(collider.gameObject);
    }
}
