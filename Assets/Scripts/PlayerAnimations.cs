using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Animator animator;
    SpriteRenderer sprite;

    [SerializeField] private AnimationClip _missedAnimation;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void ChangeAnimation(NoteDirection moveToDo, bool hasMissed = false)
    {
        if (hasMissed)
        {
            animator.Play(_missedAnimation.name);
            return;
        }

        string animationTrigger = "";
        switch (moveToDo)
        {
            case NoteDirection.Down:
                animationTrigger = "Down";
                break;
            case NoteDirection.Up:
                animationTrigger = "Up";
                break;
            case NoteDirection.Right:
                animationTrigger = "Right";
                break;
            case NoteDirection.Left:
                animationTrigger = "Left";

                break;
            default:
                return;
        }

        animator.Play(animationTrigger);
        //animator.SetTrigger(animationTrigger);
    }
}
