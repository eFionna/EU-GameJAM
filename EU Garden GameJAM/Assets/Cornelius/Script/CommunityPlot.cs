using UnityEngine;

public class CommunityPlot : RoofSlot
{
    [SerializeField]
    GameManager GameManager;

    public int AccseptanceOnBuilt = 25;
    public int FavorsToBuild;
    public SpriteRenderer SpriteRenderer;
    public GameObject worldCanvas;
    bool isBuilt;
    public override void Interact()
    {
        if (!isBuilt)
        {

            Build();
        }
    }

    void Build()
    {
        if (GameManager.Favors >= FavorsToBuild)
        {
            SpriteRenderer.color = Color.white;
            worldCanvas.SetActive(false);
            GameManager.Acceptance += AccseptanceOnBuilt;
            GameManager.Favors -= FavorsToBuild;
            isBuilt = true;
        }
    }
}

