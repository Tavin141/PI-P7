using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cristais : MonoBehaviour
{
    public GameObject[] locais;
    int atual = 0;
    float Mvel;
    public float vel;
    float localLength = 1;

    // Update is called once per frame
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
}
