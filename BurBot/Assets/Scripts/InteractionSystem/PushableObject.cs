using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[RequireComponent (typeof(Rigidbody))]
public class PushableObject : MonoBehaviour,IInteractable
{
    Rigidbody rb, playerRB;
    GameObject player;
    bool isConnected = false;
    private FixedJoint fj;
    public float totalMassWhenConnected=1f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRB = player.GetComponent<Rigidbody>(); ;
        fj = this.GetComponent<FixedJoint>();
        rb = GetComponent<Rigidbody>();
       
    }
    
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interaction interaction)

    {
        
        if (player.transform.GetComponent<PlayerMovement>().IsGrounded()&&!player.GetComponent<InputControl>().IsRotating)
        {
            switch (isConnected)
            {
                case true:
                    if (this.TryGetComponent<FixedJoint>(out FixedJoint destroy))
                    {
                        Destroy(destroy);
                        isConnected = false;
                        rb.isKinematic = true;
                        player.transform.GetComponent<InputControl>().RotationActivated = true;

                        playerRB.constraints = RigidbodyConstraints.FreezeRotation;


                    }



                    break;
                case false:
                    FixedJoint fj = this.gameObject.AddComponent(typeof(FixedJoint)) as FixedJoint;
                    rb.isKinematic = false;

                    fj.connectedMassScale = totalMassWhenConnected;
                    fj.connectedBody = playerRB;
                    
                    isConnected = true;
                    player.transform.GetComponent<InputControl>().RotationActivated = false;
                    playerRB.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

                    break;
            }

        }
        

        return true;
    }


}
