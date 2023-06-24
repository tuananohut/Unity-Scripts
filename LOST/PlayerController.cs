using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput, verticalInput;
    public float speed = 15.0f;
    private Animator anim;
    private bool isForwardLeft, isBackwardLeft, isSprinting;
    private bool isAttacking, isShield;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Check if the left shift key is pressed
        bool sprintInput = Input.GetKey(KeyCode.LeftShift);

        if (Input.GetMouseButtonDown(0))
        {
            if (!isAttacking)
            {
                anim.SetTrigger("Attack");
                isAttacking = true;
            }
        }

        if (isAttacking && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            isAttacking = false;
        }

        if(Input.GetMouseButtonDown(1)) {
            if (!isShield)
            {
                anim.SetTrigger("Shield");
                isShield = true;   
            }
        }

        if (isShield && !anim.GetCurrentAnimatorStateInfo(0).IsName("Shield"))
        {
            isShield = false;
        }

        if (!isAttacking && !isShield)
        {
            if (sprintInput && verticalInput > 0)
            {
                // Start sprinting
                isSprinting = true;
                anim.SetBool("Forward", false);
            }
            else if (isSprinting || verticalInput <= 0)
            {
                // Stop sprinting when no longer moving forward
                isSprinting = false;
            }

            // Adjust the speed based on sprinting
            float currentSpeed = isSprinting ? speed * 2 : speed;

            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * currentSpeed);
            transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * currentSpeed);

            if (verticalInput > 0 && horizontalInput > 0)
            {
                anim.SetBool("ForwardRight", true);
                anim.SetBool("Forward", false);
                isForwardLeft = false;
            }
            else if (horizontalInput < 0 && verticalInput > 0)
            {
                anim.SetBool("ForwardLeft", true);
                anim.SetBool("Forward", false);
                isForwardLeft = true;
            }
            else
            {
                anim.SetBool("ForwardRight", false);
                anim.SetBool("ForwardLeft", false);

                if (!isForwardLeft || isForwardLeft)
                {
                    anim.SetBool("Forward", !isSprinting && verticalInput > 0);
                }
            }

            if (verticalInput < 0 && horizontalInput > 0)
            {
                anim.SetBool("BackwardRight", true);
                anim.SetBool("Backward", false);
                anim.SetBool("Right", false);
                isBackwardLeft = false;
            }
            else if (verticalInput < 0 && horizontalInput < 0)
            {
                anim.SetBool("BackwardLeft", true);
                anim.SetBool("Backward", false);
                anim.SetBool("Left", false);
                isBackwardLeft = true;
            }
            else
            {
                anim.SetBool("BackwardRight", false);
                anim.SetBool("BackwardLeft", false);
                anim.SetBool("Right", horizontalInput > 0);
                anim.SetBool("Left", horizontalInput < 0);

                if (!isBackwardLeft || isBackwardLeft)
                {
                    anim.SetBool("Backward", verticalInput < 0);
                }
            }
        }

        anim.SetBool("Sprint", isSprinting);
    }
}
