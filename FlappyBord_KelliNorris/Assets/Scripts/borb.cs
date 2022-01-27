using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borb : MonoBehaviour
{

    private bool isDead = false;
    private Rigidbody2D rb2D;
    private Animator anim;

    

    public float upforce = 200f;

    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("flap");
                rb2D.velocity = Vector2.zero;
                rb2D.AddForce(new Vector2(0, upforce));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        anim.SetTrigger("died");
        isDead = true;
        gameControl.instance.BirdDied();
    }
}
