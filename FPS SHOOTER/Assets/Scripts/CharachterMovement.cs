using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class CharachterMovement : MonoBehaviour
{
  public static CharachterMovement Instance;

    public Vector3 startPosition = new Vector3 (-25.32f, 2.433f, 5.79f);

    public float Health;
    private void Awake()
    {
        Instance = this;
    }


    [SerializeField] CharacterController CC;
    [SerializeField] Transform CharachterBody;

     float Horizontal;
     float Vertical;


    public bool IsWalking;
    public bool IsRunning;
    [SerializeField] float WalkSpeed;
    [SerializeField] float RunSpeed;


    private void FixedUpdate()
    {
        Movement();
    }


    private void Update()
    {
        CheckMovement();
    }

    void Movement()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        Vector3 Move = CharachterBody.right * Horizontal + CharachterBody.forward * Vertical;
        CC.Move(Move * TotalSpeed() * Time.deltaTime);

    }

    void CheckMovement()
    {
        if ((Horizontal !=0f || Vertical !=0f) || (Horizontal !=0f && Vertical != 0f))
        {
            if(TotalSpeed() == RunSpeed)
            {
                IsRunning = true;
                IsWalking = false;
            }

            if (TotalSpeed() == WalkSpeed) 
            {

                IsRunning = false;
                IsWalking = true;
            }

        }

        else
        {
            IsRunning = false;
            IsWalking = false;
        }
    }


    float TotalSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            return RunSpeed;
        else 
            return WalkSpeed;
    }



    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Apple"))
        {
            Health -=20f;
        }

        if (Health <= 0) 
        {
           Health = 100f;
            SceneManager.LoadScene("GameOver");
        }


        

        

    }

  


}
