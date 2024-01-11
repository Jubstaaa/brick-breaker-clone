using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    float barY;
    Rigidbody2D rb;
    SceneCheck sceneCheck = new SceneCheck();
    private bool isStarted;
    GameObject bar;
  
    void Start()
    {
        bar = GameObject.FindGameObjectWithTag("Bar");

        rb = GetComponent<Rigidbody2D>();

        barY = bar.GetComponent<SpriteRenderer>().bounds.extents.y;

    }

    void Update()
    {
        if(!isStarted)
        {
            this.transform.position = new Vector3(bar.transform.position.x, bar.transform.position.y+(barY * 2),0f) ;
        }

        if(Input.GetMouseButtonDown(0) && !isStarted)
        {
            isStarted = true;
            rb.velocity = new Vector2 (3f, 3f);


        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = rb.velocity * 1.004f;

    }

    private void OnBecameInvisible()
    {
        if (BlockController.allBlocks>0)
        {
            PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
            sceneCheck.ChangeSceneByName("Result");
        }
       
    }
}
