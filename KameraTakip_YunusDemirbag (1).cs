using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    public GameObject player;
    void FixedUpdate()
    {
        transform.position = Vector2.Lerp(transform.position,player.transform.position,Time.deltaTime);
        transform.Translate(Vector3.back*10);
    }
}
