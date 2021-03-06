﻿using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// NGUI Enhance item example
/// </summary>


public class MyNGUIEnhanceItem : EnhanceItem
{
    public Action<int> OnSelect;
    public Action<int> OnDeselect;

    private UITexture mTexture;

    protected override void OnAwake()
    {
        this.mTexture = GetComponent<UITexture>();
        UIEventListener.Get(this.gameObject).onClick = OnClickNGUIItem;
    }

    private void OnClickNGUIItem(GameObject obj)
    {
        this.OnClickEnhanceItem();
    }

    // Set the item "depth" 2d or 3d
    protected override void SetItemDepth(float depthCurveValue, int depthFactor, float itemCount)
    {
        if (mTexture.depth != (int)Mathf.Abs(depthCurveValue * depthFactor))
            mTexture.depth = (int)Mathf.Abs(depthCurveValue * depthFactor);
    }

    // Item is centered
    public override void SetSelectState(bool isCenter)
    {
        if (mTexture == null)
            mTexture = this.GetComponent<UITexture>();
        if (mTexture != null)
            mTexture.color = isCenter ? Color.white : Color.gray;

        if (isCenter)
        {
            if (OnSelect != null) OnSelect(base.CurveOffSetIndex);
        }
        else
        {
            if (OnDeselect != null) OnDeselect(base.CurveOffSetIndex);
        }
    }

    protected override void OnClickEnhanceItem()
    {
        // item was clicked
        base.OnClickEnhanceItem();
    }
}
