using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public static int allBlocks;
    [SerializeField] int maxHP = 3;
    int damageTaken=0;
    public Sprite firstHit,secondHit;
    SpriteRenderer spriteRenderer;
    SceneCheck sceneCheck = new SceneCheck();

    void Start()
    {
        allBlocks++;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

 

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ball")
        {
            damageTaken++;
            maxHP--;
            UpdateAppearance(damageTaken);


            if (maxHP == 0)
            {
                allBlocks--;
                if(allBlocks <= 0)
                {
                    sceneCheck.NextScene();
                }
                Destroy(gameObject);
            }
        }
    }

    void UpdateAppearance(int damageTaken)
    {
        switch (damageTaken)
        {
            case 1:
                spriteRenderer.sprite = firstHit;
                break;
            case 2:
                spriteRenderer.sprite = secondHit;
                break;
            default:
                break;
        }
    }
}
