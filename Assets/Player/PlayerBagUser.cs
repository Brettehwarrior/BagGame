using System;
using System.Collections;
using System.Collections.Generic;
using Bag;
using Bag.Dimension;
using UnityEngine;

public class PlayerBagUser : MonoBehaviour
{
    [SerializeField] private MagicBag bag;
    [SerializeField] private Transform bagTransform;
    [SerializeField] private Transform bagParent;

    private GameObject _previousCamera;
    
    public bool InBag { get; private set; }

    private void Start()
    {
        // TODO: Make this the previous camera rather than main
        _previousCamera = Camera.main.gameObject;
    }

    public void EnterBag()
    {
        // Detach bag
        bagParent.SetParent(transform.parent, true);
        
        InBag = true;
        bag.EnterBag(transform);
        
        // Camera
        _previousCamera.SetActive(false);
        BagDimensionManager.Instance.Cam.SetActive(true);
    }
    
    public void ExitBag()
    {
        InBag = false;
        bag.ExitBag(transform);
        
        // Camera
        _previousCamera.SetActive(true);
        BagDimensionManager.Instance.Cam.SetActive(false);
        
        // Attach bag
        bagParent.SetParent(transform, true);
    }
}
