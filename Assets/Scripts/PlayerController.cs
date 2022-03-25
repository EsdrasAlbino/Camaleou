using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 velocity;
    public float Acceleration = 10.0f;
    public float maxSpeed = 10;
    Vector3 direction = Vector3.zero;
    Vector3 currentVelocity;

    
    /*private float direcaoMovimento;
    private float timerPulo;
    private float timerVira;
    private int pulosRestantes;
    private int dierecaoOlhando = 1;
    private bool estaOlhandoDireita = true;
    [SerializeField]
    private bool estaNoChao;
    private bool estaAndando;
    [SerializeField]
    private bool podePular;
    private bool estaTentandoPular;
    private bool multiplicadorDePuloCheck;
    private bool podeMover;
    private bool podeGirar;
    private Rigidbody2D rb;
    private Animator anim;
    public int quantosPulos = 1;
    public float forcaPulo = 16.0f;
    public float chaoCheck;
    public float raioChao;
    public float multiPuloAlto = 0.5f;
    public float forcaAr = 0.95f;
    public float timerPuloSet = 0.15f;
    public float timerViraSer = 0.1f;
    public float distanceBetweenImages;
    public Transform chao;
    public LayerMask whatIsGround;*/

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        //pulosRestantes = quantosPulos;
    }

    // Update is called once per frame
    void Update()
    {
        //CheckInput();
        //CheckMovementDirection();
        //UpdateAnimations();
        //CheckIfCanJump();
        //CheckJump();
        Walking();
    }

    private void FixedUpdate()
    {
        //ApplyMovement();
        //CheckSurroundings();
    }

    /*private void CheckSurroundings()
    {
        estaNoChao = Physics2D.OverlapCircle(chao.position, raioChao, whatIsGround);
    }*/

    private void Walking(){
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        direction = new Vector3(horizontalInput, 0, 0).normalized;

        velocity = Vector3.SmoothDamp(velocity, direction * maxSpeed, ref  currentVelocity, maxSpeed/Acceleration);

        transform.position += velocity * Time.deltaTime;
    }

    //L�gica para liberar pulo
    /*private void CheckIfCanJump()
    {
        if (estaNoChao && rb.velocity.y <= 0.01f)
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
    private void CheckInput()
    {
        direcaoMovimento = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump"))
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
        if (timerVira >= 0)
        {
            timerVira -= Time.deltaTime;
            if (timerVira <= 0)
            {
                podeMover = true;
                podeGirar = true;
            }
        }
        if (multiplicadorDePuloCheck && !Input.GetButton("Jump"))
        {
            multiplicadorDePuloCheck = false;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * multiPuloAlto);
        }
    }
    public int GetFacingDirection()
    {
        return dierecaoOlhando;
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