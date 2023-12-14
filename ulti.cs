using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ulti : MonoBehaviour
{
    public bomb ultiPrefab;
    public float ultiCoolDown;
    private float ultiCoolDownAge;
    // Start is called before the first frame update
    void Start()
    {
        ultiPrefab.bombcoolDown = 0;
    }

    // Update is called once per frame
    void Update()
    {
       ultiCoolDownAge += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.R) && ultiCoolDownAge >= ultiCoolDown) 
       {
            bomb spawned = Instantiate(ultiPrefab, transform.position, Quaternion.identity);
            ultiCoolDownAge = 0;
       } 
    }
}
