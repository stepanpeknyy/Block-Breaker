﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            
            Destroy(gameObject);
            FindObjectOfType<GameController>().NewLevel();
        }
    }

    public void DestroyBlocks()
    {
        Destroy(gameObject);
    }
}
