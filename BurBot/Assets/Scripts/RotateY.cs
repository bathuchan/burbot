using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateY : MonoBehaviour
{
    public float rotateSpeed;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 1*Time.deltaTime*rotateSpeed, 0);
    }
}
