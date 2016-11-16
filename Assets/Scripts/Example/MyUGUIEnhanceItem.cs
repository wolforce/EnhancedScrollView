using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class MyUGUIEnhanceItem : EnhanceItem
{
    public Action<int> OnSelect;
    public Action<int> OnDeselect;

    private Button uButton;
    private RawImage rawImage;

    protected override void OnStart()
    {
        rawImage = GetComponent<RawImage>();
        uButton = GetComponent<Button>();
        uButton.onClick.AddListener(OnClickUGUIButton);
    }

    private void OnClickUGUIButton()
    {
        OnClickEnhanceItem();
    }

    // Set the item "depth" 2d or 3d
    protected override void SetItemDepth(float depthCurveValue, int depthFactor, float itemCount)
    {
        int newDepth = (int)(depthCurveValue * itemCount);
        this.transform.SetSiblingIndex(newDepth);
    }

    public override void SetSelectState(bool isCenter)
    {
        if (rawImage == null)
            rawImage = GetComponent<RawImage>();
        rawImage.color = isCenter ? Color.white : Color.gray;

        if (isCenter)
        {
            if (OnSelect != null) OnSelect(base.CurveOffSetIndex);
        }
        else
        {
            if (OnDeselect != null) OnDeselect(base.CurveOffSetIndex);
        }
    }
}
