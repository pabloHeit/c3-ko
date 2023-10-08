using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Animator animator;
    SpriteRenderer sprite;

    [SerializeField] private Sprite[] Animations;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void ChangeAnimation(Colors moveToDo)
    {
        string animationTrigger = "";
        switch (moveToDo)
        {
            case Colors.Blue:
                animationTrigger = "Up";
                break;
            case Colors.Violet:
                animationTrigger = "Down";
                break;
            case Colors.Red:
                animationTrigger = "Right";
                break;
            case Colors.Green:
                animationTrigger = "Left";

                break;
            default:
                return;
        }

        animator.Play(animationTrigger);
        //animator.SetTrigger(animationTrigger);
    }
}
