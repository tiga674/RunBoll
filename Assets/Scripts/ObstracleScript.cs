using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstracleScript : MonoBehaviour
{
    public Vector3 obstracleRotate;
    
    void Update()
    {
        transform.Rotate(obstracleRotate);
    }
}
