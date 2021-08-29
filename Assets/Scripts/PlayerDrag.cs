using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrag : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform arrow;
    [SerializeField ] private GameObject plane;
    [SerializeField] float maxScale = 0.2f;
    [SerializeField] float minScale = 0.1f;
    [SerializeField] float scale = 0.1f;

    RaycastHit hit;
    Ray ray;
    Vector3 mousePos;
    Collider planeCollider;
    private void Awake()
    {
        planeCollider = plane.GetComponent<Collider>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0) && FindObjectOfType<UIController>().GameStatus()==false)
        {           
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider ==planeCollider)
                {
                    Vector3 playerPos = hit.point;
                    if (playerPos.z > -1)
                    {
                        playerPos.z = -1;
                    }
                    transform.position = playerPos ;
                    mousePos = new Vector3(playerPos.x, arrow.position.y, playerPos.z);
                    arrow.LookAt(mousePos);
                }


                ArrowScale();
            }
        }
        else if (Input.GetMouseButtonUp(0) && hit.point.z + 5>0f)
        {
            if (hit.point.z + 5 <=2 && hit.point.z + 5 >= 1)
            {
                scale = scale * (hit.point.z + 5);
            }
            
            FindObjectOfType<Ball>().GetDirection();
        }
    }

    private void ArrowScale()
    {
        if (hit.point.z + 5 > 2)
        {
            scale = maxScale;
            arrow.localScale = new Vector3(0.1f, 1, scale );
        }
        else if (hit.point.z + 5 < 1)
        {
            scale = minScale;
            arrow.localScale = new Vector3(0.1f, 1, scale );
        }
        else
        {  
            arrow.localScale = new Vector3(0.1f, 1, scale * (hit.point.z + 5));
        }
    }

    public Vector3 MousePos()
    {
        return mousePos;
    }
    public float Scale()
    {
       return scale;
    }
}
