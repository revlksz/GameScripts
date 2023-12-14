using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimeAdd : MonoBehaviour
{
    public int ek;
    public bool zamanEklendi = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!zamanEklendi && collision.gameObject.CompareTag("TimeAdd"))
        {
            ek = ek + 15;
            zamanEklendi = true; // Tekrarlý eklemeleri önlemek için bayrak ayarlanýr
            Destroy(collision.gameObject);
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
