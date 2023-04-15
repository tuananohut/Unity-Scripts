using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class material : MonoBehaviour
{
    public Material[] materials = new Material[3];

    private Renderer rend;
    private int currentMaterialIndex = 0;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materials[currentMaterialIndex];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentMaterialIndex++;
            if (currentMaterialIndex >= materials.Length)
            {
                currentMaterialIndex = 0;
            }

            rend.sharedMaterial = materials[currentMaterialIndex];
        }
    }
}
