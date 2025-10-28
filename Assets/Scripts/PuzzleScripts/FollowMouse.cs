using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    Vector3 point;
    public float speed = 1f;
    
    void Update()
    {

        point = Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(30);
        
        this.transform.LookAt(point);
       

        
    }
}
