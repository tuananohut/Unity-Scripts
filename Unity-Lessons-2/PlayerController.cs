using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 15.0f;
    public float xRange = 15;

    public GameObject projectilePrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // objenin bu aralık dışına çıkmasına izin verme 
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        //Kullanıcıdan yatay giriş al
        horizontalInput = Input.GetAxis("Horizontal"); //Input.GetAxis sürekli
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);


        //Kullanıcıdan mermi için giriş al
        if (Input.GetKeyDown(KeyCode.Space)) { //KeyCode bir kere bas 
            // Launch a projectile from the player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation); //(hangi nesne, nereden başlıyor, nereye gidiyor)
        }
    
    }
}
