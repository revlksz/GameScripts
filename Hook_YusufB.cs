using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook_YusufB : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = 0,hookAngle;
    private bool inverse=true;
    private Vector3 currentEulerAngles;
    float z;
    public Transform pivotPoint;
    private SpriteRenderer spr;
    void Start()
    {
        if (hookAngle > 0f)
        {
            inverse = true;
        }
        else
        {
            inverse = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (hookAngle > 0f)
        {
            if (currentEulerAngles.z < hookAngle && inverse)
            {
                currentEulerAngles += new Vector3(0, 0, 60) * Time.deltaTime * rotationSpeed;
                if (hookAngle - currentEulerAngles.z < 1)
                {
                    inverse = false;
                }
            }
            else
            {
                currentEulerAngles -= new Vector3(0, 0, 60) * Time.deltaTime * rotationSpeed;

                if (currentEulerAngles.z < -hookAngle)
                {
                    inverse = true;
                }
            }
        }
        else
        {
            if(currentEulerAngles.z>hookAngle && !inverse )
            {
                currentEulerAngles -= new Vector3(0, 0, 60) * Time.deltaTime * rotationSpeed;
                if (currentEulerAngles.z - hookAngle < 1)
                {
                    inverse = true;
                }
            }
            else
            {
                currentEulerAngles += new Vector3(0, 0, 60) * Time.deltaTime * rotationSpeed;
                if (currentEulerAngles.z>-hookAngle) { inverse = false; }
            }
        }
        pivotPoint.localEulerAngles = currentEulerAngles;

    }
}
