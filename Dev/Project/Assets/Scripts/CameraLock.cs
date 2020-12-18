using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : MonoBehaviour
{
    public GameObject Player;
    internal Vector3 Offset;
    // Start is called before the first frame update
    void Start()
    {
        Offset = transform.position -Player.transform.position;   
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position =  new Vector3(Player.transform.position.x, 0, 0) + Offset;
    }
}
