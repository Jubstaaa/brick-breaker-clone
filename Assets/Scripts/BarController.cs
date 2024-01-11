using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
{
    float minX, maxX;
    float halfOfBar;

    void Start()
    {
        
        Cursor.visible = false; 

        minX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 10)).x;
        maxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 10)).x;

        halfOfBar = GetComponent<SpriteRenderer>().bounds.extents.x;
        minX += halfOfBar;
        maxX -= halfOfBar;
    }

    void Update()
    {
        Vector3 farePozisyonu = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        float hedefX = Mathf.Clamp(farePozisyonu.x, minX, maxX);

        transform.position = new Vector3(hedefX, transform.position.y, transform.position.z);
    }

    void OnMouseEnter()
    {
        Cursor.visible = false; 
    }

    void OnMouseExit()
    {
        Cursor.visible = true; 
    }

    private void OnDestroy()
    {
        Cursor.visible = true;

    }
}
