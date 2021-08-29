using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    Vector2 mousePos;
    float maxScale = 0.2f;
    float minScale = 0.1f;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ScaleAndRotateArrow();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            FindObjectOfType<Ball>().GetDirection();
        }

        
    }

    private void ScaleAndRotateArrow()
    {
        mousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition);
        Vector2 arrowPos = transform.position;
        transform.right = mousePos- arrowPos;

        if (mousePos.y < 100)
        {
            transform.localScale = new Vector3(minScale, 0.1f, 1);
        }
        else if (mousePos.y > 300)
        {
            transform.localScale = new Vector3(maxScale, 0.1f, 1);
        }
        else 
        {
            transform.localScale = new Vector3(mousePos.y*0.001f, 0.1f, 1);
        }

        Debug.Log(mousePos);
    }

    public Vector2 Direction()
    {
        return mousePos;
    }
}
