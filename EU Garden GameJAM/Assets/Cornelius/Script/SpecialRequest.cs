using UnityEngine;
[CreateAssetMenu]
public class SpecialRequest : ScriptableObject
{
    public CropType cropType;
    public int bonusFavor;


    private void OnEnable()
    {
        cropType = (CropType)Random.Range(0, 2);
        bonusFavor = Random.Range(1, 50);
    }
}
