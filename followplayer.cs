using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player1;
    //public float smoothSpeed = 0.125f;
    public Vector3 offset1;
 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
      
        Vector3 desiredPosition = player1.transform.position + offset1;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime);
        transform.position = desiredPosition;


    }
}
