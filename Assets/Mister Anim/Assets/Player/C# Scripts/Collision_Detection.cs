using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Detection : MonoBehaviour
{
    private Animator animator;
    private bool isHit = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            isHit = true;
        }
        Debug.Log("Collided with: " + collision.gameObject.name);

        Debug.Log("Updating IsHit: " + isHit);
        animator.SetBool("IsHit", isHit);


    }


}