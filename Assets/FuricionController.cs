using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuricionController : MonoBehaviour
{
    public float fucion = 0.5f;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ball")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity *= fucion;
            collision.gameObject.GetComponent<Rigidbody2D>().angularVelocity *= fucion;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
