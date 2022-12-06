using System;
using System.Collections;
using System.Collections.Generic;
using External.LeanTween.Framework;
using UnityEngine;

public class TweenResizer : MonoBehaviour
{
    [SerializeField] private bool startShrunken = true;
    [SerializeField] private Vector3 minScale = Vector3.zero;
    [SerializeField] private Vector3 maxScale = Vector3.one;
    [SerializeField] private float growEaseTime = 0.2f;
    [SerializeField] private LeanTweenType growEaseType = LeanTweenType.easeOutElastic;
    [SerializeField] private float shrinkEaseTime = 0.2f;
    [SerializeField] private LeanTweenType shrinkEaseType = LeanTweenType.easeInBack;

    private void Start()
    {
        if (startShrunken)
        {
            transform.localScale = minScale;
        }
    }

    public void Grow()
    {
        LeanTween.scale(gameObject, maxScale, growEaseTime).setEase(growEaseType);
    }
    
    public void Shrink()
    {
        LeanTween.scale(gameObject, minScale, shrinkEaseTime).setEase(shrinkEaseType);
    }
}
