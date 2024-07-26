using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Animator))]

public class AnimationController : MonoBehaviour
{
    Animator Animation;


    private void Start()
    {
        Animation = GetComponent<Animator>();
    }

    public void SetBool(string AnimationID , bool AnimationBoolean)
    {
        Animation.SetBool(AnimationID , AnimationBoolean);
    }

    public void SetTrigger(string AnimationID)
    {
        Animation.SetTrigger(AnimationID);
    }


    public void EndFire()
    {
        WeaponManager.Instance.EndFire();
    }

    public void EndReload()
    {
        WeaponManager.Instance.EndReload();
    }

    public void WeaponDown()
    {
        WeaponManager.Instance.CloseWeapon();
    }

    public void SetAvailability (int Index)
    {
        WeaponManager.Instance.Availability = Index ==0 ? false : true;
    }

}
