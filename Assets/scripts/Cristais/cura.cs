using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cura : MonoBehaviour
{
    public static bool vidaGain;
    public GameObject[] locais = new GameObject[2];
    int atual = 0;
    float Mvel;
    public float vel;
    int localLength = 1;

  
    void Update()
    {

        if (Vector3.Distance(locais[atual].transform.position, transform.position) < localLength)
        {
            atual = Random.Range(0, locais.Length);
            if (atual >= locais.Length)
            {
                atual = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, locais[atual].transform.position, Time.deltaTime * vel);
    }

    private void OnTriggerEnter2D(Collider2D collision)

    {

        if (Player_Behaviour.vida <= 4)
        {


            if (collision.tag == "Player")
            {
                vidaGain = true;
                Destroy(gameObject);
                Destroy(locais[1]);
                Destroy(locais[0]);
            }
        }

    }
}
