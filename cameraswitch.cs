using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{

    public Camera mainCamera;
    public Camera driverCamera;

    void Start()
    {
        mainCamera.enabled = true;
        driverCamera.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            mainCamera.enabled = !mainCamera.enabled;
            driverCamera.enabled = !driverCamera.enabled;
            Debug.Log("Çalıştı");
            if (driverCamera.enabled)
            {
                driverCamera.transform.position = new Vector3(0f, 1f, -5f);
                driverCamera.transform.rotation = Quaternion.Euler(new Vector3(10f, 0f, 0f));
            }
        }
    }
}
