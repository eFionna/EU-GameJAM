using System.Collections;
using UnityEngine;

public class FarmPlot : RoofSlot
{
    public CropType CropType;

    [Range(0, 100)]
    public float Growth;
    public bool HasCrop;
    public float TimeToMature;
    public Animator animator;
    float timeToMature;

    private void Awake()
    {
        timeToMature = TimeToMature / 100;
    }

    public override void Interact()
    {
        if (HasCrop)
        {
            if (Growth == 100)
            {
                HasCrop = false;

                GameManager.OnHarvest.Invoke(CropType);
                Growth = 0;
                animator.SetFloat("Growth", Growth);

                animator.SetTrigger("Reset");
                
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
            animator.SetFloat("Growth", Growth);
        }
    }
}
