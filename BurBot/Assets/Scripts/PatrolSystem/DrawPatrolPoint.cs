using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPatrolPoint : MonoBehaviour
{
    public Color color=Color.yellow;

    // Update is called once per frame
    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        if (this.tag == "Car") 
        {
            Gizmos.DrawMesh(GetComponent<MeshFilter>().sharedMesh, transform.position+Vector3.up);

        }
        else {
            
            Gizmos.DrawMesh(GetComponent<MeshFilter>().sharedMesh, transform.position);
        }

        
    }
}
