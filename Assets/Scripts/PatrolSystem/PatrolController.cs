using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PatrolController : MonoBehaviour
{
    public bool EnableMovement;
    public float forceStrength;     
    public float stopDistance;
    public float TurnRotSpeed;
    public Transform[] patrolPointObjects;
 
    private List<Vector2> patrolPoints= new List<Vector2>();
    private Vector2 this2DPositon;
    
    private int currentPoint = 0;      
    private Rigidbody ourRigidbody;   

    void Awake()
    {
        ourRigidbody = GetComponent<Rigidbody>();
        
    }

    private void Start()
    {
        this2DPositon = new Vector2(this.transform.position.x, this.transform.position.z);
        
        foreach (Transform t in patrolPointObjects)
        {
            patrolPoints.Add(new Vector2(t.position.x, t.position.z));
            
        }

    }
    void FixedUpdate()
    {   
        if (EnableMovement) {
            this2DPositon = new Vector2(this.transform.position.x, this.transform.position.z);

            float distance = Vector2.Distance(this2DPositon, patrolPoints[currentPoint]);
            

            if (distance <= stopDistance)
            {
                currentPoint = currentPoint + 1;

                if (currentPoint >= patrolPoints.Count)
                {
                    currentPoint = 0;
                }
            }

            Vector3 direction = new Vector3((patrolPoints[currentPoint].x - this2DPositon.x), 0, (patrolPoints[currentPoint].y - this2DPositon.y)).normalized;

            ourRigidbody.AddForce(direction * forceStrength, ForceMode.Impulse);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * TurnRotSpeed);
            //Debug.Log(ourRigidbody.velocity);
        }
        
    }
}