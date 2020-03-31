using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody rigidBody;
    public float playerSpeed; //プレイヤーの速度
    public Text goalText;
    public GameObject retryButton;
    public GameObject resultButton;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
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
            rigidBody.AddForce(new Vector3(0, 0, playerSpeed));
        }

        //落下したらゲームオーバー
        if (transform.position.y < -10)
        {
            goalText.text = "GAMEOVER";
            retryButton.SetActive(true);
            rigidBody.velocity = Vector3.zero;
        }

        if (transform.position.z >= 195)
        {
            goalText.text = "GOAL!!";
            resultButton.SetActive(true); //retrybuttonを表示する
            rigidBody.velocity = Vector3.zero;
            GameObject.Find("GameManager").GetComponent<GameManage>().timeFlg
                = false; //タイマーを止める

        }
    }

    //他のオブジェクトとの接触の処理
    void OnTriggerEnter(Collider collider)
    {
        //SpeedUpPlateのとき
        if (collider.gameObject.tag == "SUP")
        {
            playerSpeed += 1f;
            rigidBody.AddForce(new Vector3(0, 0, 5));
        }
        //SpeedDownPlateのとき
        if (collider.gameObject.tag == "SDP")
        {
            playerSpeed -= 1f;

        }
        //Goalのとき
        
        Destroy(collider.gameObject);
    }
}
