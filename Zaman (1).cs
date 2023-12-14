using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zaman : MonoBehaviour
{
    TimeAdd tm;
    public float time;
    public Text timeText;
    private void Start()
    {
        tm = GetComponent<TimeAdd>();
    }
    void FixedUpdate()
    {
        time = time+tm.ek;
        time -= Time.deltaTime ;
        timeText.text = "Zaman : " + (int)time;
        
    }
}
