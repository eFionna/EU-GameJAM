using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmPlot : RoofSlot
{
    public CropType CropType;


    public override void Interact()
    {
        GameManager.OnHarvest.Invoke(CropType);
    }
}
