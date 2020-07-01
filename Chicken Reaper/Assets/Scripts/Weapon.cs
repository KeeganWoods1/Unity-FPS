using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject enemyHitEffect;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] AudioClip gunshotSFX;
    [SerializeField] float rateOfFire = 0.5f;
    [SerializeField] float range = 100f;
    [SerializeField] int damage = 1;

    public bool isSprinting = false;
    bool canShoot = true;
    bool hasAmmo = true;
    Animator animator;
    AudioSource audioSource;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHasAmmo();
        UpdateAmmoText(ammoType);
        HandleShootInput();
    }

    private void UpdateHasAmmo()
    {
        if (!ammoSlot || ammoSlot.GetCurrentAmmo(ammoType) <= 0)
        {
            hasAmmo = false;
        }

        else
        {
            hasAmmo = true;
        }
    }

    private void UpdateAmmoText(AmmoType ammoType)
    {
        if (ammoType.ToString() == "knife")
        {
            ammoText.text = ammoType.ToString() + ": 00";
        }

        else
        {
            ammoText.text = ammoType.ToString() + ": " + ammoSlot.GetCurrentAmmo(ammoType).ToString();
        }
    }

    private void HandleShootInput()
    {
        if (Input.GetMouseButton(0) && !isSprinting && hasAmmo && canShoot)
        {
            StartCoroutine(Shoot());
        }

        else
        {
            if (animator)
            {
                animator.StopPlayback();
                animator.SetBool("isFiring", false);                
            }
            if (canShoot)
            {
                audioSource.Stop();
            }
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;

        if (animator)
        {
            animator.SetBool("isFiring", true);
        }

        ammoSlot.DecreaseAmmo(ammoType);
        PlayMuzzleFlash();
        ProcessRaycast();
        PlayGunShotSFX();
        yield return new WaitForSeconds(rateOfFire);

        canShoot = true;
    }

    private void PlayGunShotSFX()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(gunshotSFX);
        }
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {

            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target)
            {
                CreateEnemyHitImpact(hit);
                target.TakeDamage(damage);
            }

            else
            {
                CreateObjectImpact(hit);
            }
        }
    }

    private void CreateObjectImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1f);
    }

    private void CreateEnemyHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(enemyHitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1f);
    }
}
