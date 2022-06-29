using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    //Movement
    public float Acceleration = 10.0f;
    public float maxSpeed = 10;
    Vector3 velocity;
    Vector3 direction = Vector3.zero;
    Vector3 currentVelocity;

    //Jump
    [SerializeField]
    private int pulosFeitos;
    public int maxPulos = 2;
    public float forcaPulo = 8.0f;
    public float forceDown = 2.0f;
    public float multiPuloAlto = 0.5f;
    private bool onGround = true;

    //Alguma outra coisa
    public float raioChao;
    private float timerPulo;

    //Animation
    Animator anim;
    /*private float direcaoMovimento;
    private float timerVira;
    private int dierecaoOlhando = 1;
    private bool estaOlhandoDireita = true;
    [SerializeField]
    private bool estaAndando;
    [SerializeField]
    private bool podeMover;
    private bool podeGirar;
    private Animator anim;
    public float chaoCheck;
    public float forcaAr = 0.95f;
    public float timerViraSer = 0.1f;
    public float distanceBetweenImages;
    */


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        //CheckJump();
        Walking();
        Animation();
        //CheckMovementDirection();
        //UpdateAnimations();
    }

    private void FixedUpdate()
    {
        //ApplyMovement();
        //CheckSurroundings();
    }

   /* private void CheckSurroundings()
    {
        estaNoChao = Physics2D.OverlapCircle(chao.position, raioChao, whatIsGround);
    }*/

    private void Walking(){
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        direction = new Vector3(horizontalInput, 0, 0).normalized;

        velocity = Vector3.SmoothDamp(velocity, direction * maxSpeed, ref currentVelocity, maxSpeed/Acceleration);

        transform.position += velocity * Time.deltaTime;
    }


    private void Jump()
    {
        //direcaoMovimento = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.W) && (onGround || maxPulos>pulosFeitos))
        {
                rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
                onGround = false;
                pulosFeitos++;
        }
        if (Input.GetKey(KeyCode.S) && !onGround)
        {
                rb.AddForce(Vector3.up * -forceDown, ForceMode.Impulse);
        }


    }

    private void Animation() {
        if(Input.GetAxis("Horizontal") != 0) {
            anim.SetBool("IsWalking", true);
        } else {
            anim.SetBool("IsWalking", false);
        }
    }

    void OnCollisionEnter(Collision collision){
            onGround = true;
            pulosFeitos = 0;
        }
    

/*
    // Moving fields
    [SerializeField] // This will make the variable below appear in the inspector
    float speed = 6;
    [SerializeField]
    float jumpSpeed = 8;
    [SerializeField]
    float gravity = 20;
    Vector3 moveDirection = Vector3.zero;
    CharacterController controller;
    //bool isJumping; // "controller.isGrounded" can be used instead
    [SerializeField]
    int nrOfAlowedDJumps = 1; // New vairable
    int dJumpCounter = 0;     // New variable

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        moveDirection.x = Input.GetAxis("Horizontal") * speed;
        moveDirection.z = Input.GetAxis("Vertical") * speed;

        if (Input.GetButtonDown ("Jump")) {
            if (controller.isGrounded) {
                moveDirection.y = jumpSpeed;
                dJumpCounter = 0;
            }
            if (!controller.isGrounded && dJumpCounter < nrOfAlowedDJumps) {
                moveDirection.y = jumpSpeed;
                dJumpCounter++;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}*/





    
   /* private void CheckMovementDirection()
    {
        if (estaOlhandoDireita && direcaoMovimento < 0)
        {
            Flip();
        }
        else if (!estaOlhandoDireita && direcaoMovimento > 0)
        {
            Flip();
        }
        if (Mathf.Abs(rb.velocity.x) >= 0.01f)
        {
            estaAndando = true;
        }
        else
        {
            estaAndando = false;
        }
    }
    private void UpdateAnimations()
    {
        //anim.SetBool("isWalking", estaAndando);
        //anim.SetBool("isGrounded", estaNoChao);
        //anim.SetFloat("yVelocity", rb.velocity.y);
    }

    public int GetFacingDirection()
    {
        return dierecaoOlhando;
    }


   private void ApplyMovement()
    {
        if (!estaNoChao && direcaoMovimento == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x * forcaAr, rb.velocity.y);
        }
        else if (podeMover)
        {
            rb.velocity = new Vector2(velocidadeMovimentacao * direcaoMovimento, rb.velocity.y);
        }
    }
    public void DisableFlip()
    {
        podeGirar = false;
    }
    public void EnableFlip()
    {
        podeGirar = true;
    }
    private void Flip()
    {
        if (podeGirar)
        {
            dierecaoOlhando *= -1;
            estaOlhandoDireita = !estaOlhandoDireita;
            transform.Rotate(0.0f, 180.0f, 0.0f);
        }
    }
   /* private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(chao.position, raioChao);
    }*/
}