﻿using UnityEngine;
using System.Collections;


using UnityEngine;

/// <summary>
/// Plays the specified sound.
/// </summary>

public class NGUISoundPlay : MonoBehaviour
{
    public enum Trigger
    {
        OnClick,
        OnMouseOver,
        OnMouseOut,
        OnPress,
        OnRelease,
    }

    public AudioClip audioClip;
    public Trigger trigger = Trigger.OnClick;

#if UNITY_3_5
	public float volume = 1f;
	public float pitch = 1f;
#else
    [Range(0f, 1f)]
    public float volume = 1f;
    [Range(0f, 2f)]
    public float pitch = 1f;
#endif

    void OnHover(bool isOver)
    {
        if (enabled && ((isOver && trigger == Trigger.OnMouseOver) || (!isOver && trigger == Trigger.OnMouseOut)))
        {
            NGUITools.PlaySound(audioClip, volume, pitch);
        }
    }

    void OnPress(bool isPressed)
    {
        if (enabled && ((isPressed && trigger == Trigger.OnPress) || (!isPressed && trigger == Trigger.OnRelease)))
        {
            NGUITools.PlaySound(audioClip, volume, pitch);
        }
    }

    void OnClick()
    {
        if (enabled && trigger == Trigger.OnClick)
        {
            NGUITools.PlaySound(audioClip, volume, pitch);
        }
    }
}