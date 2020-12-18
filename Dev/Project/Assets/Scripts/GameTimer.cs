using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public static GameTimer Instance;
    internal TextMeshProUGUI text;
    public float time { get; private set; } = 0;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        text.text = new TimeSpan(0, 0, 0, 0, (int)(time * 1000)).ToString(@"hh\:mm\:ss");
    }
}
