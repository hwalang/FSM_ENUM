using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class IdleState : State
{
    public AnimationClip anim;

    public override void Enter()
    {
        animator.Play(anim.name);
    }
    public override void Do()
    {
        // logic

        if (!controller.grounded /*|| input.xInput != 0*/)
        {
            isCompelete = true;
        }
    }
    public override void Exit()
    {

    }
}
