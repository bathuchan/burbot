using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float _speed = 6;
    public float _jumpForce = 6;
    private Rigidbody _rig;
    private Vector2 _input;
    private Vector3 _movementVector;

    [SerializeField] public Animator animator;
    private AudioSource jumpSource, runSource;

    [Header("Jump")]
    public AudioClip[] jumpAudioClips;
    [Header("Run")]
    public AudioClip[] runAudioClips;

    public ParticleSystem ParticlesOnFoot;

    private GameObject character;

    private void Start()
    {
        jumpSource = GetComponents<AudioSource>()[0];
        runSource = GetComponents<AudioSource>()[1];
        _rig = GetComponent<Rigidbody>();
        character=this.gameObject.transform.GetChild(0).gameObject;
        

        //Need to freez rotation so the player do not flip over
        _rig.freezeRotation = true;
        //this.particleSystem= GameObject.FindObjectOfType<ParticleSystem>();
    }
    private void Update()
    {
        //Cleanerway to get input
        _input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Jump();
    }
    private void FixedUpdate()
    {
        this.animator.SetBool("IsGrounded", IsGrounded());
        //Keep the movement vector aligned with the player rotation
        _movementVector = _input.x * transform.right * _speed + _input.y * transform.forward * _speed;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) 
        {
            this.animator.SetBool("IsMoving", true);
            Move();
            PlayFootstep();

        }else 
        {
            this.animator.SetBool("IsMoving", false);
        }
        
    }

    private void Move()
    {
        
        //Keep the movement vector aligned with the player rotation
        _movementVector = _input.x * transform.right * _speed + _input.y * transform.forward * _speed;
        //Apply the movement vector to the rigidbody without effecting gravity
        _rig.velocity = new Vector3(_movementVector.x, _rig.velocity.y, _movementVector.z) ;

        
        

        if (_movementVector.sqrMagnitude == 0f) //Look rotation viewing vector is zero - Hata çözümü
        {
            return;
        }
        
        Quaternion toRotation = Quaternion.LookRotation(_movementVector);

        if (toRotation.eulerAngles!= _movementVector) 
        {
            character.transform.rotation = Quaternion.RotateTowards(character.transform.rotation, toRotation, Time.deltaTime * 500f);
        }
        

            

    }

    //public float footstepRate;
    private float lastFootstepTime;

    private void PlayFootstep() 
    {
        int random = Random.Range(0, runAudioClips.Length);

        if ((Time.time - lastFootstepTime >+ runAudioClips[random].length/8) && IsGrounded())
            {
                lastFootstepTime = Time.time;
            //this.runSource.pitch = Random.Range(0.8f, 1.8f);
            this.runSource.volume = Random.Range(0.02f, 0.05f);
            //this.runSource.pitch = Random.Range(.9f, 1.1f);
            
            //footstepRate= (runAudioClips[random]).length;
            this.runSource.PlayOneShot(runAudioClips[random]);


            }



    }
    
    public bool IsGrounded()
    {
        //Simple way to check for ground
        if (Physics.Raycast(transform.position, Vector3.down, 1.1f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            
            this.animator.SetBool("Jump", true);
            this.jumpSource.clip = jumpAudioClips[Random.Range(0, jumpAudioClips.Length)];
            this.jumpSource.pitch = Random.Range(0.8f, 1.8f);
            this.jumpSource.volume = Random.Range(0.04f, 0.1f);
            this.jumpSource.Play();

            _rig.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);

            /*ParticleSystemShapeType donutShape = ParticleSystemShapeType.Donut;
            var shape=particleSystem.shape;
            shape.shapeType = donutShape;
            shape.radius = 1.0f;
             = shape;*/

            ParticlesOnFoot.Emit(100);
            

        } else if (IsGrounded()) 
        {
            this.animator.SetBool("Jump", false);
        }
        
        
    }



}
/*
 
    public float _speed = 6;
    public float _jumpForce = 6;
    private Rigidbody _rig;
    private Vector2 _input;
    private Vector3 _movementVector;
    public float rotationSpeed;


    private Rigidbody rb;
    [SerializeField] public Animator animator;
    
    private void Start()
    {
        _rig = GetComponent<Rigidbody>();
        //Need to freez rotation so the player do not flip over
        _rig.freezeRotation = true;
    }
    private void Update()
    {
        //Cleanerway to get input
         _input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        
        Jump();
        Move();
        
    }
    private void FixedUpdate()
    {
        //Keep the movement vector aligned with the player rotation
        _movementVector = _input.x * transform.right * _speed + _input.y * transform.forward * _speed;
        //Apply the movement vector to the rigidbody without effecting gravity
        _rig.velocity = new Vector3(_movementVector.x, _rig.velocity.y, _movementVector.z);
    }
    private bool IsGrounded()
    {
        //Simple way to check for ground
        if (Physics.Raycast(transform.position, Vector3.down, 1.5f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _rig.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }

    private void Move()

    {
        float verticalAxis = _input.x;
        float horizontalAxis = _input.y;

        //Keep the movement vector aligned with the player rotation
        _movementVector = _input.x * transform.right * _speed + _input.y * transform.forward * _speed;
        //Apply the movement vector to the rigidbody without effecting gravity
        _rig.velocity = new Vector3(_movementVector.x, _rig.velocity.y, _movementVector.z)*Time.deltaTime;
        //Vector3 movementDirection = new Vector3(horizontalAxis, 0, verticalAxis);
        
        
        /*if (_rig.velocity!=Vector3.zero) 
        {
            Quaternion toRotation = Quaternion.LookRotation(_movementDirection,Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }*/
//movementDirection.Normalize();
//transform.Translate(movementDirection * _speed * Time.deltaTime, Space.World);
/*Vector3 movement = this.transform.forward * verticalAxis + this.transform.right * horizontalAxis;
    movement.Normalize();

    this.transform.position += movement * 0.04f;

this.animator.SetFloat("vertical", verticalAxis);
this.animator.SetFloat("horizontal", horizontalAxis);
        

    } 
 

*/




/*{
    public float MoveSmoothTime;
    public float GravityStrength;
    public float JumpStrength;
    public float WalkSpeed;
    public float RunSpeed;

    private CharacterController Controller;
    private Vector3 CurrentMoveVelocity;
    private Vector3 MoveDampVelocity;

    private Vector3 CurrentForceVelocity;

    void Start()
    {
        Controller=GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 PlayerInput = new Vector3
        {
            x = Input.GetAxisRaw("Horizontal"),
            y=0f,
            z= Input.GetAxisRaw("Vertical")
        };

        if (PlayerInput.magnitude>1f) 
        {
            PlayerInput.Normalize();
        }

        Vector3 MoveVector= transform.TransformDirection(PlayerInput);
        float CurrentSpeed=Input.GetKey(KeyCode.LeftShift)?RunSpeed:WalkSpeed;

        CurrentMoveVelocity= Vector3.SmoothDamp(
            CurrentMoveVelocity,
            MoveVector,
            ref MoveDampVelocity,
            MoveSmoothTime
            );
        Controller.Move(CurrentMoveVelocity * Time.deltaTime);

        Ray groundCheckRay = new Ray(transform.position,Vector3.down);
        if (Physics.Raycast(groundCheckRay,1.1f)) 
        {
            CurrentForceVelocity.y = -2;
            if (Input.GetKey(KeyCode.Space)) 
            {
                
                CurrentForceVelocity.y = JumpStrength;
            }
        }
        else 
        {
            CurrentForceVelocity.y = -GravityStrength*Time.deltaTime;
        }
        Controller.Move(CurrentForceVelocity * Time.deltaTime*5);
    }
}*/
