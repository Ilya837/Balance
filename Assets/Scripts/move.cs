using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 1;
    private Rigidbody rb;
    private bool jump;
    private Vector3 Check;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = false;
        Check = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHor = Input.GetAxis("Horizontal");
        float moveVer = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveHor,0,moveVer);

        if (Input.GetKey(KeyCode.Space) && !jump)
        {
            move = new Vector3(moveHor, 500, moveVer);
            jump = true;
        }
        
        rb.AddForce(move * speed);

        if(transform.position.y < -15)
        {
            rb.velocity = new Vector3(0, 0, 0);
            transform.position = Check;

        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Chekpoint")
        {
            Check = collision.gameObject.transform.position;
            Check.y += 0.7f;
        }
        jump = false;
    }


}
