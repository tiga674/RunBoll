using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody rigidBody;

    public float playerSpeedZ; //プレイヤーの速度
    public float playerSpeedX;
    public Text goalText;
    public GameObject retryButton;
    public GameObject resultButton;
    public GameObject Goal;
    public GameObject SdpEffect;
    public GameObject SupEffect;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        //プレイヤーの左右移動
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += transform.right * Time.deltaTime * playerSpeedX;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= transform.right * Time.deltaTime * playerSpeedX;
        }

        //プレイヤーが前進
        if (Input.GetKey(KeyCode.Z))
        {
            rigidBody.AddForce(new Vector3(0, -1, playerSpeedZ));
        }

        //落下したらゲームオーバー
        if (transform.position.y < -10)
        {
            goalText.text = "GAMEOVER";
            retryButton.SetActive(true);
            rigidBody.velocity = Vector3.zero;
        }

        if (transform.position.z >= Goal.transform.position.z)
        {
            goalText.text = "GOAL!!";
            resultButton.SetActive(true); //RetryButtonを表示する
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
            playerSpeedZ += 0.2f;
            rigidBody.AddForce(new Vector3(0, 0, 5));

            //エフェクト生成
            Instantiate(
                SupEffect,
                collider.transform.position,
                Quaternion.identity);
        }
        //SpeedDownPlateのとき
        if (collider.gameObject.tag == "SDP")
        {
            playerSpeedZ -= 0.4f;

            //エフェクト生成
            Instantiate(
                SdpEffect,
                collider.transform.position,
                Quaternion.identity);
        }
        
        Destroy(collider.gameObject);
    }
}
