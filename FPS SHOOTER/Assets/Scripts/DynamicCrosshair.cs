using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicCrosshair : MonoBehaviour
{

    [SerializeField] RectTransform Crosshair;



    [SerializeField] float MaxSize;
    [SerializeField] float MinSize;
    [SerializeField] float CurrentSize;

    [SerializeField] float Speed;


    private void Update()
    {
        Inputs();
        SetSize();
    }

    void SetSize()
    {
        Crosshair.sizeDelta = new Vector2 (CurrentSize, CurrentSize);
    }



    void Inputs()
    {
        if(!CharachterMovement.Instance.IsWalking && !CharachterMovement.Instance.IsRunning)
        {
            SetMin();
        }

        else if (CharachterMovement.Instance.IsWalking)
        {
            SetMax();
        }


        if (CharachterMovement.Instance.IsRunning)
        {
            SetDeactive();
        }

        else
        {
            SetActive();
        }

    }

    void SetMin()
    {
        CurrentSize = Mathf.Lerp(CurrentSize, MinSize, Speed * Time.deltaTime);
    }

    void SetMax()
    {
        CurrentSize = Mathf.Lerp(CurrentSize, MinSize, Speed * Time.deltaTime);
    }

    void SetActive() 
    { 
       Crosshair.gameObject.SetActive(true);
    }

    void SetDeactive()
    {
        Crosshair.gameObject.SetActive(false);
    }



}
