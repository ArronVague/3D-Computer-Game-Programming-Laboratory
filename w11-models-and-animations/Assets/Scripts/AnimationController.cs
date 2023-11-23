using Unity.VisualScripting;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    public bool empty;
    public bool isPulling;
    public bool isHolding;
    public float power;
    public float hold_power;

    private void Start()
    {
        // 获取对象上的Animator组件
        animator = GetComponent<Animator>();
        empty = true;
        isPulling = false;
        isHolding = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && empty)
        {
            animator.SetTrigger("pull");
            empty = false;
            isPulling = true;
            power += Time.deltaTime;
            animator.SetFloat("power", power);
        }
        else if (Input.GetMouseButtonDown(1) && isPulling)
        {
            animator.SetTrigger("hold");
            isPulling = false;
            isHolding = true;
        }
        else if (Input.GetMouseButtonDown(0) && isHolding)
        {
            animator.SetTrigger("shoot");
            isHolding = false;
            empty = true;
        }
    }
}