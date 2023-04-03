using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    public float velocidade;
    public float impulso;
    bool estaNoChao;
    public Transform sensorChao;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anima;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anima = GetComponent<Animator>();
    }

    
    void Update()
    {
        //mover
        float mover = Input.GetAxis("Horizontal") * velocidade * Time.deltaTime;
        transform.Translate(mover, 0.0f, 0.0f);

        //orientação
        if (Input.GetAxis("Horizontal") > 0)
        {
            sr.flipX = false;
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            sr.flipX = true;
        }

        //chao
        estaNoChao = Physics2D.Linecast(transform.position, sensorChao.position, 1 << LayerMask.NameToLayer("piso"));

        //pulo
        if (Input.GetButtonDown("Jump") && estaNoChao)
        {
            rb.velocity = new Vector2(0.0f, impulso);
        }

        //anim
        anima.SetFloat("andar", Mathf.Abs(Input.GetAxis("Horizontal")));
    }
}
