using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimationState
{
    Attack,
    Clicked,
    Eat,
    Fly,
    IdleA,
    IdleB,
    IdleC,
    Roll,
    Sit,
    Swim,
    Bounce,
    Death,
    Fear,
    Hit,
    Jump,
    Run,
    Spin,
    Walk,
    EyesAnnoyed,
    EyesDead,
    EyeLookDown,
    EyeLookUp,
    EyesShrink,
    EyesSquint,
    SweatR,
    EyeBlink,
    EyesExcited,
    EyesLookIn,
    EyesRabid,
    EyesSleep,
    EyesTrauma,
    TeardropL,
    EyesCry,
    EyesHappy,
    EyesLookOut,
    EyesSad,
    EyesSpin,
    SweatL,
    TeardropR
    
}

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private AnimationState m_CurrentAnimation = AnimationState.IdleA;
    
    [SerializeField] private Animator m_Animator;

    private void Update()
    {
        m_Animator.Play(GetAnimationName(m_CurrentAnimation));
    }

    private string GetAnimationName(AnimationState state)
    {
        switch (state)
        {
            case AnimationState.Attack:
                return "Attack";
            case AnimationState.Clicked:
                return "Clicked";
            case AnimationState.Eat:
                return "Eat";
            case AnimationState.Fly:
                return "Fly";
            case AnimationState.IdleA:
                return "Idle_A";
            case AnimationState.IdleB:
                return "Idle_B";
            case AnimationState.IdleC:
                return "Idle_C";
            case AnimationState.Roll:
                return "Roll";
            case AnimationState.Sit:
                return "Sit";
            case AnimationState.Swim:
                return "Swim";
            case AnimationState.Bounce:
                return "Bounce";
            case AnimationState.Death:
                return "Death";
            case AnimationState.Fear:
                return "Fear";
            case AnimationState.Hit:
                return "Hit";
            case AnimationState.Jump:
                return "Jump";
            case AnimationState.Run:
                return "Run";
            case AnimationState.Spin:
                return "Spin";
            case AnimationState.Walk:
                return "Walk";
            case AnimationState.EyesAnnoyed:
                return "Eyes_Annoyed";
            case AnimationState.EyesDead:
                return "Eyes_Dead";
            case AnimationState.EyeLookDown:
                return "Eyes_LookDown";
            case AnimationState.EyeLookUp:
                return "Eyes_LookUp";
            case AnimationState.EyesShrink:
                return "Eyes_Shrink";
            case AnimationState.EyesSquint:
                return "Eyes_Squint";
            case AnimationState.SweatR:
                return "Sweat_R";
            case AnimationState.SweatL:
                return "Sweat_L";
            case AnimationState.EyeBlink:
                return "Eyes_Blink";
            case AnimationState.EyesExcited:
                return "Eyes_Excited";
            case AnimationState.EyesLookIn:
                return "Eyes_LookIn";
            case AnimationState.EyesRabid:
                return "Eyes_Rabid";
            case AnimationState.EyesSleep:
                return "Eyes_Sleep";
            case AnimationState.EyesTrauma:
                return "Eyes_Trauma";
            case AnimationState.TeardropL:
                return "Teardrop_L";
            case AnimationState.TeardropR:
                return "Teardrop_R";
            case AnimationState.EyesCry:
                return "Eyes_Cry";
            case AnimationState.EyesHappy:
                return "Eyes_Happy";
            case AnimationState.EyesLookOut:
                return "Eyes_LookOut";
            case AnimationState.EyesSad:
                return "Eyes_Sad";
            case AnimationState.EyesSpin:
                return "Eyes_Spin";
        }

        return null;
    }
}
