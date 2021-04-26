using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float controlSpeed = 45f;
    [SerializeField] private float xRange = 20f;
    [SerializeField] private float yRange = 5f;
    [SerializeField] private float positionPitchFactor = -1.5f;
    [SerializeField] private float controlPitchFactor = -8f;
    [SerializeField] private float controlRollFactor = -30f;
    [SerializeField] private float positionYawFactor = 1.6f;
    [SerializeField] private float controlYawFactor = 3f;
    [SerializeField] private GameObject[] weapons;

    private float xThrow;
    private float yThrow;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProccessTranslation();
        ProccessRotation();
        ProccessFiring();
    }

  

    private void ProccessRotation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float positionPitch = transform.localPosition.y * positionPitchFactor;
        float controlPitch = yThrow * controlPitchFactor;
        float positionYaw = transform.localPosition.x * positionYawFactor;
        float controlYaw = xThrow * controlYawFactor;

        float pitch = positionPitch + controlPitch;
        float yaw = positionYaw + controlYaw;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProccessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;

        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange * 4);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    private void ProccessFiring()
    {
        float fireVulcan = Input.GetAxis("Fire1");
        float fireCannon = Input.GetAxis("Fire2");
        FiringHelper0(fireVulcan,0);
        FiringHelper1(fireCannon, 1);

    }

    private void FiringHelper0(float fireWeapon,int weaponIndex)
    {
        if (fireWeapon == 1f)
        {
            ActivateWeapon(weaponIndex);
        }
        else
        {
            DeactivateWeapon(weaponIndex);
        }
    }
    private void FiringHelper1(float fireWeapon, int weaponIndex)
    {
        if (fireWeapon == 1f)
        {
            ActivateWeapon(weaponIndex);
        }
        else
        {
            DeactivateWeapon(weaponIndex);
        }
    }

    private void DeactivateWeapon(int weaponIndex)
    {
        ParticleSystem[] weaponsToDeactivate = weapons[weaponIndex].GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem weapon in weaponsToDeactivate)
        {
            weapon.enableEmission = false;
        }
    }

    private void ActivateWeapon(int weaponIndex)
    {
        ParticleSystem[] weaponsToActivate = weapons[weaponIndex].GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem weapon in weaponsToActivate)
        {
            weapon.enableEmission = true;
        }
    }
}
