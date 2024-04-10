using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public bool isCompelete { get; protected set; }

    // Check when the state started and how long it has been running.
    protected float startTime;
    public float time => Time.time - startTime;

    // Variables common to all states
    protected Rigidbody2D body;
    protected Animator animator;
    protected PlayerController controller;   // Can pass on all the information possessed by the PlayerController instance.

    public virtual void Enter() { }
    public virtual void Do() { }
    public virtual void FixedDo() { }
    public virtual void Exit() { }

    public void Init(Rigidbody2D _body, Animator _animator, PlayerController _controller)
    {
        body = _body;
        animator = _animator;
        controller = _controller;
    }

    // Set when the current state started.
    public void Initialize()
    {
        isCompelete = false;
        startTime = Time.time;
    }
}
