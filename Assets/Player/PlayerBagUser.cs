using System;
using System.Collections;
using System.Collections.Generic;
using Bag;
using Bag.Dimension;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBagUser : MonoBehaviour
{
    [SerializeField] private MagicBag bag;
    [SerializeField] private Transform bagTransform;
    [SerializeField] private Transform bagParent;
    [SerializeField] private TweenResizer bagDimensionImageResizer;

    private void Start()
    {
        BagDimensionManager.Instance.SetCameraFollowTarget(transform);
    }

    public bool InBag { get; private set; }
    public void EnterBag()
    {
        // Detach bag
        bagParent.SetParent(transform.parent, true);
        
        InBag = true;
        bag.EnterBag(transform);
        
        bagDimensionImageResizer.Grow();
        BagDimensionManager.Instance.EnableCameraFollow();
    }
    
    public void ExitBag()
    {
        BagDimensionManager.Instance.DisableCameraFollow();
        InBag = false;
        bag.ExitBag(transform);
        
        // Attach bag
        bagParent.SetParent(transform, true);
        
        bagDimensionImageResizer.Shrink();
    }
}
