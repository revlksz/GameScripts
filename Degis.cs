using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Degis : MonoBehaviour
{
    public Text tx;
    private int score;
    
    void Start()
    {
        score = 0;
        tx.text = score.ToString();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position= new Vector3(-2,0,0);
            score++;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector3(2, 0, 0);
            score++;
        }
        tx.text = score.ToString();
    }
}
