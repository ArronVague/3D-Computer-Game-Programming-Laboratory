using Com.Mygame;
using System;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    public bool empty;
    public bool isPulling;
    public bool isHolding;
    public float power = 0f;
    public float hold_power;
    public float powerIncreaseSpeed = 1f;
    public IUserAction action;

    private void Start()
    {
        // 获取对象上的Animator组件
        animator = GetComponent<Animator>();
        empty = true;
        isPulling = false;
        isHolding = false;
        action = SSDirector.getInstance().currentSceneController as IUserAction;
    }

    private void Update()
    {
        if (isPulling)
        {
            power += Time.deltaTime * powerIncreaseSpeed;
            animator.SetFloat("power", power);
        }
        if (Input.GetMouseButtonDown(0) && empty)
        {
            animator.SetTrigger("pull");
            empty = false;
            isPulling = true;          
        }
        else if (Input.GetMouseButtonDown(1) && isPulling)
        {
            hold_power = Math.Min(power, 1f);
            power = 0f;
            animator.SetFloat("hold_power", hold_power);
            animator.SetTrigger("hold");
            isPulling = false;
            isHolding = true;
        }
        else if (Input.GetMouseButtonDown(0) && isHolding)
        {         
            animator.SetTrigger("shoot");
            action.hit();
            isHolding = false;
            empty = true;
        }
    }
}