using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
public static WeaponManager Instance;




    private void Awake()
    {
        Instance = this;
    }


    [SerializeField] Transform WeaponTransform;

    public bool Availability;


    [Header("Fire Point")]
    [SerializeField] Transform firePoint;

    [Header("Bullet")]
    [SerializeField] GameObject bulletPrefab;


    [Header("Animations")]

    [SerializeField] AnimationController Animation;

    [SerializeField] string FireI_ID;
    [SerializeField] string FireII_ID;
    [SerializeField] string Reload_ID;
    [SerializeField] string WeaponDown_ID;


    [Header("Fire Available")]

    [SerializeField] bool Fire;
    [SerializeField] int CurrentAmmo;
   

    [SerializeField] float FireFreq;
    float FireCounter;

    RaycastHit FireRaycast;
    [SerializeField] float Firerange;

    [Header("Reload Veriables")]
    [SerializeField] bool Reload;
    [SerializeField] int MaxAmmo;
    [SerializeField] int TotalAmmo;

    [Header("Muzzle Flash")]
    [SerializeField] Transform WeaponTip;
    [SerializeField] GameObject MuzzleFlash;
    
    private void Update()
    {
        Inputs();
    }

    void Inputs ()
    {
        WeaponTransform.localRotation = MouseLooks.Instance.CameraParent.localRotation;

        if (Input.GetMouseButtonDown(0) && !Reload && CurrentAmmo >0 && Time.time > FireCounter && Availability)
        {
            StartFire();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartReload();
        }
    }

    void StartFire()
    {
        Fire = true;
       
        if(CurrentAmmo <=1)
            Animation.SetBool(FireI_ID, Fire);
        else
            Animation.SetBool(FireII_ID, Fire);

        CurrentAmmo--;
        FireCounter = Time.time + FireFreq;

        if (Physics.Raycast(CameraController.Instance.Camera.position, CameraController.Instance.Camera.forward, out FireRaycast, Firerange))
        {
            print(FireRaycast.transform.name);
        }

        CreateMuzzleFlash();

    }
    public void EndFire()
    {
        Fire = false;
        Animation.SetBool(FireI_ID, Fire);
        Animation.SetBool(FireII_ID, Fire);
    }

    void CreateMuzzleFlash()
    {
        GameObject MuzzleFlashCopy = Instantiate(MuzzleFlash, WeaponTip.position, WeaponTip.rotation, WeaponTip);
        Destroy(MuzzleFlashCopy, 5f);
    }

    void StartReload()
    {
        Reload = true;
        Animation.SetBool (Reload_ID, Reload);
    }

    public void EndReload()
    {
        Reload = false;
        Animation.SetBool(Reload_ID, Reload);
    }

    public void CloseWeapon()
    {

    }

}
