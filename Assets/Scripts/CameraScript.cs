using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Vector3 diff;

    public GameObject player;

    void Start()
    {
        diff = player.transform.position - transform.position;
    }

    void Update()
    {
        transform.position = player.transform.position - diff;
    }
}
