using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    public string tooltipString;

    public void OnMouseEnter()
    {
        ToolTipManager._instance.ShowToolTip(tooltipString);
    }

    public void OnMouseExit()
    {
        ToolTipManager._instance.HideToolTip();
    }
}
