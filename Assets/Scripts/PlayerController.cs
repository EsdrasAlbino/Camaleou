using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    //Movement
    public float Acceleration = 10.0f;
    public float maxSpeed = 10;
    Vector3 velocity;
    Vector3 direction = Vector3.zero;
    Vector3 currentVelocity;

    //Jump
    private int pulosRestantes;
    public int quantosPulos = 1;
    public float raioChao;
    private float timerPulo;
    public float timerPuloSet = 0.15f;
    public float forcaPulo = 16.0f;
    public float multiPuloAlto = 0.5f;
    private bool podePular;
    private bool estaNoChao;
    private bool estaTentandoPular;
    private bool multiplicadorDePuloCheck;
    public Transform chao;
    public LayerMask whatIsGround;

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
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        pulosRestantes = quantosPulos;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        CheckIfCanJump();
        CheckJump();
        Walking();
        //CheckMovementDirection();
        //UpdateAnimations();

    }

    private void FixedUpdate()
    {
        //ApplyMovement();
        CheckSurroundings();
    }

    private void CheckSurroundings()
    {
        estaNoChao = Physics2D.OverlapCircle(chao.position, raioChao, whatIsGround);
    }

    private void Walking(){
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        direction = new Vector3(horizontalInput, 0, 0).normalized;

        velocity = Vector3.SmoothDamp(velocity, direction * maxSpeed, ref  currentVelocity, maxSpeed/Acceleration);

        transform.position += velocity * Time.deltaTime;
    }

    //Logica para liberar pulo
    private void CheckIfCanJump()
    {
        if (estaNoChao)
        {
            pulosRestantes = quantosPulos;
        }
        if (pulosRestantes <= 0)
        {
            podePular = false;
        }
        else
        {
            podePular = true;
        }
    }
        private void NormalJump()
    {
        if (podePular)
        {
            rb.velocity = new Vector2(rb.velocity.x, forcaPulo);
            pulosRestantes--;
            timerPulo = 0;
            estaTentandoPular = false;
            multiplicadorDePuloCheck = true;
        }
    }
        private void CheckJump()
    {
        if (timerPulo > 0) //time pulo == 0.15
        {
            NormalJump();
        }
        if (estaTentandoPular)
        {
            timerPulo -= Time.deltaTime;
        }
    }

    private void CheckInput()
    {
        //direcaoMovimento = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown("w"))
        {
            if (estaNoChao || (pulosRestantes > 0))
            {
                NormalJump();
            }
            else
            {
                timerPulo = timerPuloSet; // timer pulo == 0.15
                estaTentandoPular = true;
            }
        }
       /* if (timerVira >= 0)
        {
            timerVira -= Time.deltaTime;
            if (timerVira <= 0)
            {
                podeMover = true;
                podeGirar = true;
            }
        }*/
        if (multiplicadorDePuloCheck && !Input.GetButton("w"))
        {
            multiplicadorDePuloCheck = false;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * multiPuloAlto);
        }
    }








    
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