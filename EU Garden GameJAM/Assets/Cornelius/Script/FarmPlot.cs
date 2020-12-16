using System.Collections;
using UnityEngine;

public class FarmPlot : RoofSlot
{
    public CropType CropType;

    [Range(0, 100)]
    public float Growth;
    public bool HasCrop;
    public float TimeToMature;
    float timeToMature;

    private void Awake()
    {
        timeToMature = TimeToMature / 100;
        StartCoroutine(Grow());
    }

    public override void Interact()
    {
        if (HasCrop)
        {
            if (Growth == 100)
            {
                GameManager.OnHarvest.Invoke(CropType);
                HasCrop = false;
            }
        }
        else
        {
            Plant();
        }
    }

    void Plant()
    {
        HasCrop = true;
        StartCoroutine(Grow());
    }
    IEnumerator Grow()
    {
        while (Growth < 100)
        {
            yield return new WaitForSeconds(timeToMature);
            Growth++;
        }
    }
}
