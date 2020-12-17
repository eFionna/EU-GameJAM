using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public delegate void Harvest(CropType cropType);
    public static Harvest OnHarvest;

    public TextMeshProUGUI favorText;
    public TextMeshProUGUI acceptanceText;
    public TextMeshProUGUI currentRequestText;

    public GameObject Camera;

    public Transform StartCpos;
    public Transform FinalCpos;

    public GameObject IngameUI;
    public GameObject MainMenu;
    public GameObject PausMenu;
    public GameObject victoryScreen;

    public int favorOnHarvest = 10;
    public float specialRequstInterval = 180;
    public Vector2Int bonusFavorFromSpecial = new Vector2Int(1, 50);

    private int favors;
    public int Favors
    {
        get { return favors; }
        set
        {
            favors = value;
            favorText.text = $"Favor: {Favors}";
        }
    }
    private int acceptance;
    public int Acceptance
    {
        get { return acceptance; }
        set
        {
            CheckIfWin();
            acceptance = value;
            acceptanceText.text = $"Acceptance : {Acceptance}";
        }
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
                currentRequestText.text = $"Special Request For {currenstSpecialRequest.cropType}";
            }
            else
            {
                SpecialRequest = null;
                currentRequestText.text = string.Empty;
            }
            ;
        }
    }
    public SpecialRequest[] specialRequests;
    bool isPaused;
    private void Awake()
    {
        OnHarvest += CropWasHarvested;
        //currenstSpecialRequest = GenerateSpecialRequst();
        Acceptance = 0;
        Favors = 0;
    }
    public void StartGame()
    {
        StartCoroutine(StartSequens());
    }
    public void PausGame()
    {
        if (isPaused)
        {
            PausMenu.SetActive(false);
            isPaused = !isPaused;
            Time.timeScale = 1;
        }
        else
        {
            PausMenu.SetActive(true);
            isPaused = !isPaused;
            Time.timeScale = 0;
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public int interpolationFramesCount; // Number of frames to completely interpolate between the 2 positions
    int elapsedFrames = 0;
    IEnumerator StartSequens()
    {
        MainMenu.SetActive(false);
        while (Camera.transform.position != FinalCpos.position)
        {

            float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;
            Camera.transform.position = Vector3.Lerp(StartCpos.position, FinalCpos.position, interpolationRatio);
            elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);  // reset elapsedFrames to zero after it reached (interpolationFramesCount + 1)
            yield return null;
        }

        IngameUI.SetActive(true);
        StartCoroutine(SpecialRequestTimer());

    }
    void CheckIfWin()
    {
        if (Acceptance == 100)
        {
            victoryScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
    void CropWasHarvested(CropType cropType)
    {
        if (currenstSpecialRequest != null && cropType == currenstSpecialRequest.cropType)
        {
            Favors += favorOnHarvest + currenstSpecialRequest.bonusFavor;
            currentRequestText.text = string.Empty;
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
            if (Random.Range(0, 10) >= 2)
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