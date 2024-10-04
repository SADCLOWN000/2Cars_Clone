using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeCollider : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Points")
        {
            //Game Over
            FindObjectOfType<GameController>().GameOver();
        }
        if (collision.tag == "Obstacles")
        {
            //Destroy GO
            Destroy(collision.gameObject);
        }
    }
}
