using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instaciarTiros : MonoBehaviour
{
    public GameObject tiro;
    public float CD;
    
    float temp;
    bool dentro;
 
    void Update()
    {
        temp += Time.deltaTime;
        if (dentro)
        {
            if (temp >= CD)
            {
                Instantiate(tiro, transform.position, Quaternion.identity);
                temp = 0;
            }
        }
    }
private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.tag == "Player")
    {
        dentro = true; 
    }

}
private void OnTriggerExit2D(Collider2D collision)
{
    if (collision.tag == "Player")
    {
        dentro = false; 
    }

}
 
}

