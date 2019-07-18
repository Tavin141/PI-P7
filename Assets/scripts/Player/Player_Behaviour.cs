using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Behaviour : MonoBehaviour
{
    [SerializeField] private bool imune;
    [SerializeField] float CD;

    private Rigidbody2D rb;
    private Transform tr;
    private Animator an;
    public SpriteRenderer sprite;
    public SpriteRenderer foguinho;

    public Transform verificaChao;
    public Transform verificaParede;

    private bool estaAndando;
    public bool estaPulando;
    public bool estaNoChao;
    private bool estaNaParede;
    private bool estaVivo;
    private bool viradoParaDireita;
    private bool vidaGain = false;
    private bool planar;
    public int teste;
    private bool primeiroHit;

    public static bool on;
    public static int vida;
    public int pontos;
    public Text score;
    private float axis;
    public float velocidade;
    public float forcaPulo;
    public float raioVchao;
    public float raioVp;
    public bool ivuneravel = false;

    public float doubleJump;

    public LayerMask solido;

    public static bool check;
    public static bool restore;
    private static List<string> pegos = new List<string>();
    private static List<string> pastCp = new List<string>();


    private GameObject toDestroy;

    void Start()
    {        
        if(check)
        {
            pontos = 0;
            transform.position = new Vector3(92.98f, -7.95f);
            foreach(string a in pastCp)
            {
                Destroy(GameObject.Find(a));
                pontos++;
            }
        }
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        an = GetComponent<Animator>();
        estaVivo = true;
        viradoParaDireita = true;
        vida = 5;        
    }

    void Update()
    {
        score.text = pontos.ToString();
        //print(check);
        if(Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene("Persona PI"); 
        }
        if(vida <= 0)
        {
            morrendo();
        }
        estaNoChao = Physics2D.OverlapCircle(verificaChao.position, raioVchao, solido);
        estaNaParede = Physics2D.OverlapCircle(verificaParede.position, raioVp, solido);
        if(vida >= 5)
        {
            vida = 5;
        }
        if(vida_perdida5.morto)
        {
            morte();           
        }
        if(estaVivo)
        {
            axis = Input.GetAxisRaw("Horizontal");
            estaAndando = Mathf.Abs(axis) > 0f;
            if(axis > 0f && !viradoParaDireita && Time.timeScale == 1 )
            {
                flip();
            }
            else if(axis < 0f && viradoParaDireita && Time.timeScale == 1 )
            {
             flip();
            }
            if(estaNoChao)
            {
                primeiroHit = true;
            }
            if(Input.GetButtonDown("Jump") && estaNoChao)
            {
                rb.AddForce(tr.up * forcaPulo);
                estaPulando = true;
                estaNoChao = false;
            }
            else if(Input.GetButtonDown("Jump") && estaPulando)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                rb.AddForce(tr.up * forcaPulo);
                estaPulando = false;
            }
            if(vida == 0)
            {
                estaVivo = false;
            }
            if(estaNoChao)
            {
                teste = 0;
            }   
            Animations();
        }

    }
    void FixedUpdate()
    {
        if(estaAndando && !estaNaParede)
        {
            if(viradoParaDireita)
            { 
                rb.velocity = new Vector2(velocidade, rb.velocity.y);
            }
            else
            { 
                rb.velocity = new Vector2(-velocidade, rb.velocity.y);
            }
        }
    }
    void flip()
    {
        viradoParaDireita = !viradoParaDireita;
        tr.localScale = new Vector2(-tr.localScale.x, tr.localScale.y);
    }

    void Animations()
    {
        an.SetBool("Andando", (estaNoChao && estaAndando));
        an.SetBool("Pulando", !estaNoChao);
        an.SetFloat("VelVertical", rb.velocity.y);
        //an.SetBool("Atacando", (estaNoChao && estaAndando));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        teste = 0;
        if (collision.tag == "cristal")
        {
            pegos.Add(collision.name);
            pontos++;
        }
        else if(collision.tag == "dano")
        {
            StartCoroutine("IntervaloDeDano");
            //StartCoroutine("imunidade");
            //StartCoroutine("Temporizador");
            on = true;
            //vida--;
            vida_perdida.vidaLost = true;
            //GetComponent<AudioSource>().Play();
        }
        else if(collision.tag == "Agua" && primeiroHit)
        {
            if(vida == 5)
            {
                vida--;
                on = true;
                primeiroHit = false;
                //GetComponent<AudioSource>().Play();
            }
            estaPulando = true;
            StartCoroutine("imunidade");
            StartCoroutine("Temporizador");
        }
        else if(collision.tag == "CheckPoint")
        {
            if(!check)
            {
                collision.transform.GetChild(0).gameObject.SetActive(true);
                // pastCp.AddRange(pegos);
                // vida = 5;
                // restore = true;
                // check = true;               
            }
            print("cu");            
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "dano")
        {
            StopCoroutine("IntervaloDeDano");
        }
        else if(collision.tag == "CheckPoint")
        {
            collision.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Agua")
        {
            on = true;
            teste++;
            if(teste == 140)
            {
                teste = 0;
                vida--;
                StartCoroutine("imunidade");
                StartCoroutine("Temporizador");
            }
            vida_perdida.vidaLost = true;
            //GetComponent<AudioSource>().Play();
        }
        else if(collision.tag == "CheckPoint" && !check)
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                pastCp.AddRange(pegos);
                vida = 5;
                restore = true;
                check = true; 
                collision.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }

    private IEnumerator IntervaloDeDano()
    {
        vida--;
        StartCoroutine("imunidade");
        StartCoroutine("Temporizador");
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            vida--;
            StartCoroutine("imunidade");
            StartCoroutine("Temporizador");
        }
    }

    private IEnumerator imunidade()
    {
        sprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.1f);
    }

    private IEnumerator Temporizador()
    {
        foguinho.enabled = false;
        yield return new WaitForSeconds(0.1f);
        foguinho.enabled = true;
        yield return new WaitForSeconds(0.1f);
        foguinho.enabled = false;
        yield return new WaitForSeconds(0.1f);
        foguinho.enabled = true;
        yield return new WaitForSeconds(0.1f);
        foguinho.enabled = false;
        yield return new WaitForSeconds(0.1f);
        foguinho.enabled = true;
        yield return new WaitForSeconds(0.1f);
        foguinho.enabled = false;
        yield return new WaitForSeconds(0.1f);
        foguinho.enabled = true;
        yield return new WaitForSeconds(0.1f);
        foguinho.enabled = false;
        yield return new WaitForSeconds(0.1f);
        foguinho.enabled = true;
        yield return new WaitForSeconds(0.1f);
    }

    private IEnumerator morte()
    {
        sprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.2f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.2f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.2f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.2f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.2f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.2f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.2f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.2f);
    }
    public void morrendo()
    {
       SceneManager.LoadScene("Persona PI"); 
    }
}