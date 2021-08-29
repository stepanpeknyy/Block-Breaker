using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    float moveSpeed = 1;
    bool findBall;
    public void UpMoveSpeed()
    {
        moveSpeed++;
    }
    void Update()
    {
        if (findBall)
        {
            Transform target = FindObjectOfType<Ball>().transform;
            Vector3 pos = new Vector3(target.transform.position.x, 0, 3);
            transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * moveSpeed);
        }
    }

    public void Move()
    {
        findBall = true;
    }

    public void Stop()
    {
        findBall = false;
    }
}
