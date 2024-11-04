using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float shootRange = 100f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    private void PlayMuzzleFlash(){
        muzzleFlash.Play();
    }

    private void Shoot(){
        PlayMuzzleFlash();
        
        RaycastHit hit; //Containes information about GameObject that was hit by the ray

        if(Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, shootRange)){
            // Do something
            CreateHitImpact(hit);
        }
        else{
            return;
        }

        Debug.Log("I hit an object: " + hit.transform.name);
    }

    private void CreateHitImpact(RaycastHit hit){
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1f);
    }
}
