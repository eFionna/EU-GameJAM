using UnityEngine;

public class CommunityPlot : RoofSlot
{
    [SerializeField]
    GameManager GameManager;

    public int AccseptanceOnBuilt = 25;
    public int FavorsToBuild;
    public override void Interact()
    {
        Build();
    }

    void Build()
    {
        if (GameManager.Favors >= FavorsToBuild)
        {
            //Enabel Sprite

            GameManager.Acceptance += AccseptanceOnBuilt;
        }
    }
}

