using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void Harvest(CropType cropType);
    public static Harvest OnHarvest;

    public delegate void SpecialRequset(SpecialRequest request);
    public static SpecialRequset OnSpecialRequest;


    public int favorOnHarvest = 10;
    public float specialRequstInterval = 180;
    public Vector2Int bonusFavorFromSpecial = new Vector2Int(1, 50);

    private int favors;
    public int Favors
    {
        get { return favors; }
        set { favors = value; }
    }
    private int acceptance;
    public int Acceptance
    {
        get { return acceptance; }
        set {
            CheckIfWin();
            acceptance = value; }
    }
    private SpecialRequest SpecialRequest;
    public SpecialRequest currenstSpecialRequest
    {
        get { return SpecialRequest; }
        set
        {
            if (value != null)
            {
                SpecialRequest = value;
                OnSpecialRequest.Invoke(value);
            }
            else
            {
                SpecialRequest = value;
            }
            ;
        }
    }
    public SpecialRequest[] specialRequests;

    private void Awake()
    {
        OnHarvest += CropWasHarvested;
        StartCoroutine(SpecialRequestTimer());
    }

    void CheckIfWin()
    {
        if (Acceptance == 100)
        {
            //You Win
        }
    }
    void CropWasHarvested(CropType cropType)
    {
        if (currenstSpecialRequest != null && cropType == currenstSpecialRequest.cropType)
        {
            Favors += favorOnHarvest + currenstSpecialRequest.bonusFavor;
        }
        else
        {
            Favors += favorOnHarvest;
        }
    }

    public IEnumerator SpecialRequestTimer()
    {

        yield return new WaitForSeconds(specialRequstInterval);
        if (currenstSpecialRequest != null)
        {
            currenstSpecialRequest = null;
        }
        else
        {
            if (Random.Range(0, 10) >= 6)
            {
                currenstSpecialRequest = GenerateSpecialRequst();
            }
        }
        StartCoroutine(SpecialRequestTimer());


    }
    SpecialRequest GenerateSpecialRequst()
    {
        return specialRequests[Random.Range(0, specialRequests.Length - 1)];
    }




    //void GenerateObjects()
    //{
    //    for (int i = 0; i < 20; i++)
    //    {

    //        SpecialRequest asset = ScriptableObject.CreateInstance<SpecialRequest>();

    //        AssetDatabase.CreateAsset(asset, $"Assets/Cornelius/SO/SpecialRequest{i}.asset");
    //        AssetDatabase.SaveAssets();
    //    }
    //}
}
public enum CropType { Tomato, Carrot, Potato }