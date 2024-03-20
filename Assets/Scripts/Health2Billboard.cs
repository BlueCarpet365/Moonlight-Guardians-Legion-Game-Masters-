using UnityEngine;

public class HealthBillboard : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (mainCamera != null)
        {
            Vector3 lookAtPosition = transform.position + mainCamera.transform.rotation * Vector3.forward;
            Vector3 lookAtDirection = lookAtPosition - transform.position;
            transform.rotation = Quaternion.LookRotation(lookAtDirection, mainCamera.transform.up);
        }
    }
}
