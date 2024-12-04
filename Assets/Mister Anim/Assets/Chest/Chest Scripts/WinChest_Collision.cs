using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinChest_Collision : MonoBehaviour
{
    private Animator animator;
    private bool chestTouched = false;

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
        if (collision.gameObject.CompareTag("Player"))
        {
            chestTouched = true;
            Debug.Log("Collided with: " + collision.gameObject.name);
            animator.SetBool("ChestTouched", chestTouched);

            Invoke("YouWin", 3f);
        }

    }

    void YouWin()
    {
        SceneManager.LoadScene("You Win");
    }
}
