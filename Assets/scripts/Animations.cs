using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GridBrushBase;

public class Animations : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    public Transform cam;
    float turnSmoothVelocity;
    private bool isSprinting;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isSprinting = false;
    }

    // Update is called once per frame
    void Update()
    {

        // Movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        Vector3 rotationDirection = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(rotationDirection.x, rotationDirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection =  Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection * speed * Time.deltaTime);
        }
        
        // Animations
        anim.SetBool("WalkForwards", false);
        anim.SetBool("Trip", false);

        //sprinting

        speed = 6;
        isSprinting = false;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10;
            isSprinting = true;
        }


        if (Input.GetKey("w") == true || Input.GetKey("a") == true || Input.GetKey("d") == true || Input.GetKey("s") == true)
        {
            if (isSprinting == false)
            {
                anim.SetBool(("WalkForwards"), true);
                anim.SetBool(("WalkForwardsSprint"), false);
            }
            else
            {
                anim.SetBool(("WalkForwardsSprint"), true);
                anim.SetBool(("WalkForwards"), false);
                print("do sprint");
            }
        }
        else
        {
            anim.SetBool(("WalkForwards"), false);
            anim.SetBool(("WalkForwardsSprint"), false);
        }
        


        if(Input.GetKey("e") == true)
        {
            anim.SetTrigger("Trip");
            anim.SetBool("WalkForwards", false);
        }

        


    }
}
