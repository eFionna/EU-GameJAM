using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmPlot : RoofSlot
{
    public CropType CropType;
    public float Growth;

    public bool HasCrop;
    public override void Interact()
    {
        if (HasCrop)
        {

        }
        GameManager.OnHarvest.Invoke(CropType);
    }
}
