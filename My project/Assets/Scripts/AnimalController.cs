using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

//Inheritance Monobehaviour class
public class AnimalController : MonoBehaviour
{
    public bool isTouched = true;
    public int isCollide = 0;
    public int currentCollide = -1;
    public int moveUp = 0;
    public int moveDown = 0;
    public int moveLeft = 0;
    public int moveRight = 0;
    //Encapsulation
    [SerializeField]private int speed = 10;
    [SerializeField]private int z = 0;
    [SerializeField]private int x = 0;
    public string objectName { get; private set;}
    private MainUIHandle mainUI;
    public Rigidbody animalRb;
  
    void Start()
    {
        mainUI = GameObject.Find("Canvas").GetComponent<MainUIHandle>();
        animalRb = GameObject.Find("Animal").GetComponent<Rigidbody>();
        InvokeRepeating("CheckErrorMove", 1, 2);
    }

    void Update()
    {
        if (isTouched)
        {
            MoveTrigger();
        }
    }

    void FixedUpdate()
    {
        Move(z, x);
    }

    void CheckErrorMove()
    {
        if (isCollide == currentCollide && (moveUp == 2 || moveDown == 2 || moveRight == 2 || moveLeft == 2))
        {
            mainUI.GameOver(objectName);
            Destroy(gameObject);
        }

        if (isCollide == currentCollide && currentCollide > 1 && !isTouched)
        {
            mainUI.GameOver(objectName);
            Destroy(gameObject);
        }
    }

    //Abstraction Move function
    void Move(int zMove, int xMove)
    {
        animalRb.position += zMove * transform.forward * Time.deltaTime * speed;
        animalRb.position += xMove * transform.right * Time.deltaTime * speed;
    }

    //Abstraction MoveTrigger function
    void MoveTrigger()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            z = 1;
            moveUp++;
            moveDown = 0;
            moveLeft = 0;
            moveRight = 0;
            isTouched = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            z = -1;
            moveUp = 0;
            moveDown++;
            moveLeft = 0;
            moveRight = 0;
            isTouched = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            x = 1;
            moveUp = 0;
            moveDown = 0;
            moveRight++;
            moveLeft = 0;
            isTouched = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            x = -1;
            moveUp = 0;
            moveDown = 0;
            moveRight = 0;
            moveLeft++;
            isTouched = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isCollide += 1;
        currentCollide = isCollide;
        objectName = collision.gameObject.tag;
        if (!collision.gameObject.CompareTag("Door"))
        {
            mainUI.currentScore++;
            mainUI.moveLeft -= 1;
            isTouched = true;
            x =0;
            z = 0;
            if (mainUI.moveLeft == 0)
            {
                Destroy(gameObject);
                mainUI.GameOver();
            }
        }

        if (collision.gameObject.CompareTag("Door") && z==1)
        {
            Destroy(gameObject);
            mainUI.WinGame();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isCollide -= 1;
    }
}
