using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_1 : MonoBehaviour
{
    public float speed;
    public Vector3[] position;

    private int currentTarget;

    public void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            position[currentTarget],
            speed);


        if (transform.position == position[currentTarget])
        {
            GetComponent<SpriteRenderer>().flipX = false;
            if (currentTarget < position.Length - 1)
            {
                currentTarget++;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = true;
                currentTarget = 0;
            }

        }
     }
}
