using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float force = 300f;
    [SerializeField] float ballTimeExpire = 2f;
    Vector3 direction;
    Rigidbody rbBall;
    

    private void Awake()
    {
        rbBall = GetComponent<Rigidbody>();
    }
    public void GetDirection()
    {
        force = force * FindObjectOfType<PlayerDrag>().Scale();
        direction = FindObjectOfType<PlayerDrag>().MousePos ();
        rbBall.AddForce(new Vector3(direction.x, direction.y, direction.z + 5) * force);
        StartCoroutine(NextBall());
        FindObjectOfType<Player2>().Move();
    }

    IEnumerator NextBall()
    {
        yield return new WaitForSeconds(ballTimeExpire);
        FindObjectOfType<GameController>().NewBall(); 
        FindObjectOfType<Player2>().Stop();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Block") || other.CompareTag ("Player2"))
        {
            FindObjectOfType<GameController>().NewBall();
            FindObjectOfType<Player2>().Stop();
            Destroy(gameObject);
        }
    }
}
