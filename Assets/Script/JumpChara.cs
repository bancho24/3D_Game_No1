using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpChara : MonoBehaviour
{
    private Animator animator;
    private CharacterController characterController;
    //速度
    private Vector3 velocity;
    //ジャンプ力
    [SerializeField] private float jumpPower = 5f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded)
        {
            velocity = Vector3.zero;
            var input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            
            //方向キー押下状況(移動有り/無し) 
            if(input.magnitude > 0f && !animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
            {
                animator.SetFloat("Speed", input.magnitude);
                transform.LookAt(transform.position + input);
                velocity += input.normalized * 2;
            }
            else
            {
                animator.SetFloat("Speed", 0f);
            }

            //ジャンプ操作
            if (Input.GetButtonDown("Jump") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
            {
                animator.SetBool("Jump", true);
                velocity.y += jumpPower;
            }
        }

        velocity.y += Physics.gravity.y * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}
