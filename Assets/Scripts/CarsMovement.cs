using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsMovement : MonoBehaviour
{
    [SerializeField] private bool firstLaneBlueCar, firstLaneRedCar;
    [SerializeField] private bool blueCar, redCar;

    [SerializeField] private Vector2 xPos;

    private GameController gameController;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void Update()
    {
        if (gameController.gameOverBool == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                LeftButtonPressed();
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                RightButtonPressed();
            }


            if (blueCar)
            {
                if (firstLaneBlueCar)
                {
                    transform.position =
                        Vector3.Lerp(transform.position, new Vector3(-xPos.y, transform.position.y, 0), .1f);
                }
                else
                {
                    transform.position =
                        Vector3.Lerp(transform.position, new Vector3(-xPos.x, transform.position.y, 0), .1f);
                }
            }

            if (redCar)
            {
                if (firstLaneRedCar)
                {
                    transform.position =
                        Vector3.Lerp(transform.position, new Vector3(xPos.y, transform.position.y, 0), .1f);
                }
                else
                {
                    transform.position =
                        Vector3.Lerp(transform.position, new Vector3(xPos.x, transform.position.y, 0), .1f);
                }
            }
        }
    }

    public void LeftButtonPressed()
    {
        if (firstLaneBlueCar)
        {
            firstLaneBlueCar = false;
        }
        else
        {
            firstLaneBlueCar = true;
        }
    }

    public void RightButtonPressed()
    {
        if (firstLaneRedCar)
        {
            firstLaneRedCar = false;
        }
        else
        {
            firstLaneRedCar = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Points")
        {
            //Get Points
            Destroy(collision.gameObject);
            FindObjectOfType<GameController>().AddScore();
        }

        if (collision.tag == "Obstacles")
        {
            //Game Over
            FindObjectOfType<GameController>().GameOver();
        }
    }
}