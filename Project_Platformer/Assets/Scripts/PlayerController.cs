using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForse;
    public float score;
    public Text scoreText;


    private Rigidbody2D  rigidbody2D;
    private Animator animator;
    private bool isGround;
   
    private SpriteRenderer spriteRenderer;
    private void Start()

    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        scoreText.text = score.ToString();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            isGround = false;
            Jump();

        }

    }

    private void FixedUpdate()
    {
        



        Vector3 position = transform.position;

        position.x += Input.GetAxis("Horizontal") * speed;

        transform.position = position;

        

        if (Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                spriteRenderer.flipX = true;
            }
            //animator.SetInteger("state", 1);
        }
        else
        {

            //animator.SetInteger("state", 0);
        }

    }
    private void Jump()
    {
        rigidbody2D.AddForce(transform.up * jumpForse, ForceMode2D.Impulse);
    }

    public void AddCoin(int count)
    {
        score += count;

        scoreText.text = score.ToString();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;

        }
    }
}
