using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillArea : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SpawnPoint;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.gameObject.GetComponent<PlayerController>().Kill();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
