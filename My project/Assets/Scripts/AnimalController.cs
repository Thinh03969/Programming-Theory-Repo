using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    public bool isTouched = true;
    public int isCollide = 0;
    public bool moveUp;
    public bool moveDown;
    public bool moveLeft;
    public bool moveRight;
    [SerializeField]int speed = 10;
    [SerializeField]private int z =0;
    private int x =0;

    private MainUIHandle mainUI;
    public Rigidbody animalRb;
    // Start is called before the first frame update
    void Start()
    {
        mainUI = GameObject.Find("Canvas").GetComponent<MainUIHandle>();
        animalRb = GameObject.Find("Animal").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouched)
        {
            MoveTrigger();
        }
    }
    void FixedUpdate()
    {
        animalRb.position += z * transform.forward * Time.deltaTime * speed;
        animalRb.position += x * transform.right * Time.deltaTime * speed;
    }

    void MoveTrigger()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            z = 1;
            isTouched = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            z = -1;
            isTouched = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            x = 1;
            isTouched = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            x = -1;
            isTouched = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isCollide += 1;
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
