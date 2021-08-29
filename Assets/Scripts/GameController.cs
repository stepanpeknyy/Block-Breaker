using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] GameObject blocks;
    [SerializeField] Text lvlText;
    int count=0; 
    int lvlCount=1;

    private void Start()
    {
        lvlText.text = "Level " + lvlCount.ToString();
    }
    public void NewBall()
    {
        Instantiate(ball, new Vector3(0, 0.1501f, -5), Quaternion.identity );
    }

    public void NewLevel()
    {
        count++;
        if (count==3 )
        {
            count = 0;
            FindObjectOfType<Block>().DestroyBlocks();
            Instantiate(blocks, new Vector3(0, 0, 2), Quaternion.identity);
            FindObjectOfType<Player2>().UpMoveSpeed();
            lvlCount++;
            lvlText.text = "Level " + lvlCount.ToString() ;
        }
    }

}
