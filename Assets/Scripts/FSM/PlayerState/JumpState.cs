using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    public AnimationClip anim;
    public float jumpSpeed;


    public override void Enter()
    {
        animator.Play(anim.name);
    }

    public override void Do()
    {
        // seek the animator to the frame based on your velocity
        float time = Helpers.Map(body.velocity.y, jumpSpeed, -jumpSpeed, 0, 1, true);
        animator.Play("JUMP", 0, time);
        animator.speed = 0;

        if (grounded)
        {
            isCompelete = true;
            animator.SetBool("IsJump", false);
            animator.SetBool("IsGround", true);
        }
    }

    public override void Exit()
    {
    }
}

public class KneelState : State
{
    public AnimationClip anim;

    public override void Enter()
    {
        animator.Play(anim.name);
    }

    public override void Do()
    {
        if (!controller.grounded || controller.yInput >= 0)
        {
            isCompelete = true;
        }
    }

    public override void Exit()
    {
    }
}
