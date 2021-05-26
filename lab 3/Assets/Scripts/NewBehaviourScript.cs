using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public CharacterController charContr;

    private float xDir;
    private float zDir;
    private float yDir;

    private Vector3 moveDirection;

    public float speed = 10f;
    public float jump = 1f;
    public float groundDist = 0.2f;
    public LayerMask groundLayer;

    public Transform grandCheck;
    private bool isGrounded;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(grandCheck.position, groundDist, groundLayer);

        if (isGrounded && yDir < 0)
        {
            yDir = -2f;
        }
        xDir = Input.GetAxis("Horizontal");
        zDir = Input.GetAxis("Vertical");

        yDir += Physics.gravity.y * Time.deltaTime;

        moveDirection = transform.right * xDir * speed + transform.forward * zDir * speed + transform.up * yDir;
        charContr.Move(moveDirection * Time.deltaTime);

        print(yDir);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            yDir = Mathf.Sqrt(jump * -2f * Physics.gravity.y);
        }
    }
}
