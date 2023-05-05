using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Heroi : MonoBehaviour
{
    public GameObject MeuAtaque;
    private Animator ControlAnim;
    private GerenciadorDeObjetos Inventario;

    // Movimento
    private Rigidbody Corpo;
    // Giro
    float sensibilidadeGiro = 100f;
    

    // Stats
    public float hp = 50;
    public bool vivo = true;
    private bool podePegar = false;


    void Start()
    {
        Inventario = GameObject.FindGameObjectWithTag("Inventario").GetComponent<GerenciadorDeObjetos>();
        ControlAnim = GetComponent<Animator>();

        // Movimento
        Corpo = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            ControlAnim.SetTrigger("Pegar");
        }

        Mover();

    }


    void Mover()
    {
        float velocidadeZ = Input.GetAxis("Vertical") * 3;
        float velocidadeX = 0;
        Vector3 velocidadeCorrigida = velocidadeX * transform.right + velocidadeZ * transform.forward;

        Corpo.velocity = new Vector3(velocidadeCorrigida.x, 0, velocidadeCorrigida.z);

        if (Corpo.velocity.magnitude > 1)
        {
            ControlAnim.SetBool("Andar", true);
        }
        else
        {
            ControlAnim.SetBool("Andar", false);
        }
        Girar();
    }

    void Girar()
    {
        float GiroY = Input.GetAxis("Horizontal") * sensibilidadeGiro * Time.deltaTime;
        transform.Rotate(Vector3.up * GiroY);
    }

    void ControleAtaque()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKeyDown(KeyCode.X))
        {
            ControlAnim.SetTrigger("Ataque");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ControlAnim.SetTrigger("Disparo");
        }





    }
    public void AtivarAtk()
    {
        MeuAtaque.SetActive(true);
    }

    public void DesativarAtk()
    {
        MeuAtaque.SetActive(false);
    }

    public void AtivarPegada()
    {
        podePegar = true;
    }

    public void DesativarPegada()
    {
        podePegar = false;
        
    }


    void AtkDistancia()
    {
        RaycastHit meuAtkD;
        if (Physics.Raycast(MeuAtaque.transform.position, transform.forward, out meuAtkD, 10f))
        {
            
            if(meuAtkD.collider.gameObject.tag == "Inimigo")
            {
                meuAtkD.collider.gameObject.GetComponent<Inimigo>().TomeiDano();
            }

        }
    }


    private void OnTriggerStay(Collider colidiu)
    {
        if (colidiu.gameObject.tag == "Pegavel")
        {
            if (podePegar == true)
            {
                string nomeObj = colidiu.gameObject.GetComponent<Item>().Nome;
                Sprite imgObj = colidiu.gameObject.GetComponent<Item>().imagemObj;
                if (Inventario.ReceberItem(nomeObj, imgObj) == true)
                {
                    Destroy(colidiu.gameObject);
                }
                else
                {
                    //faz nada
                }


                podePegar = false;
            }

        }

       
    }

    private void OnTriggerEnter(Collider colidiu)
    {
        if (colidiu.gameObject.tag == "AtkInimigo")
        {
            if(vivo == true)
            {
                hp--;
                ControlAnim.SetTrigger("TomouDano");
                if (hp <= 0)
                {

                    Morrer();
                }
            }
            
        }

    }


    public void Morrer()
    {
        vivo = false;
        ControlAnim.SetBool("Morreu", true);
    }

    public void AumentarHP(float vidaPlus)
    {
        hp = hp + vidaPlus;
    }

}
