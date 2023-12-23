using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    public bool isTouched = true;
    public bool moveUp;
    public bool moveDown;
    public bool moveLeft;
    public bool moveRight;
    int speed = 10;

    private MainUIHandle mainUI;
    // Start is called before the first frame update
    void Start()
    {
        mainUI = GameObject.Find("Canvas").GetComponent<MainUIHandle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouched)
        {
            MoveTrigger();
        }
        Move();
    }

    void MoveTrigger()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            mainUI.currentScore++;
            moveUp = true;
            isTouched = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            mainUI.currentScore++;
            moveDown = true;
            isTouched = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            mainUI.currentScore++;
            moveLeft = true;
            isTouched = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            mainUI.currentScore++;
            moveRight = true;
            isTouched = false;
        }
    }

    void Move()
    {
        if (moveUp)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (moveDown)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * -speed);
        }

        if (moveLeft)
        {
            transform.Translate(Vector3.right * Time.deltaTime * -speed);
        }

        if (moveRight)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Door"))
        {
            moveUp = false;
            moveDown = false;
            moveLeft = false;
            moveRight = false;
            isTouched = true;
        }

        if (collision.gameObject.CompareTag("Door"))
        {
            mainUI.WinGame();
            Destroy(gameObject);
        }
    }

}
