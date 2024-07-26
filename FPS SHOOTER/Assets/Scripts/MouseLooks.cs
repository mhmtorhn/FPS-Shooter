using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MouseLooks : MonoBehaviour
{

    public static MouseLooks Instance;



    private void Awake()
    {
        Instance = this;
    }


    [SerializeField] Transform CharachterBody;
     public Transform CameraParent;


    [Header("")]

    [SerializeField][Range(0f, 100f)] float Sensitivity;

    float X;
    float Y;




    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameOver" || scene.name == "MainMenu")
        {
            // Fareyi serbest býrak ve görünür yap
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
      
        else if (scene.name == "Sample Scene")
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void FixedUpdate()
    {
        MouseControl();
    }

    void MouseControl()
    {
        X = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime *20;
        Y += Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime *20;

        Y = Mathf.Clamp(Y, -80f, 80f);

        CameraParent.localRotation = Quaternion.Euler(-Y, 0f, 0f);


        CharachterBody.Rotate(Vector3.up * X);

    }





}
