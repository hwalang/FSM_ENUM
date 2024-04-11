using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class RunState : State
{
    public AnimationClip anim;

    public override void Enter()
    {
        animator.Play(anim.name);
    }
    public override void Do()
    {
        // Instead of stopping abruptly, it gradually slows down before coming to a stop.
        float velX = body.velocity.x;
        animator.speed = Helpers.Map(controller.maxXSpeed, 0, 1, 0, 1.6f, true);

        if (!grounded /*|| Mathf.Abs(velX) < 0.1f*/)
        {
            isCompelete = true;
        }
    }
    public override void Exit()
    {

    }
}
