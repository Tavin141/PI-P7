using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tirobehaviour : MonoBehaviour
{
    public float velocidade;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * velocidade * Time.deltaTime);
    }

   private void OnTriggerEnter2D(Collider2D collision)    
   {
       if (collision.tag == "Player")
       {
           Destroy(this.gameObject);
       }

   }
}
