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
}
