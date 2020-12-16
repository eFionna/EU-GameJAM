using UnityEngine;

public class CommunityPlot : RoofSlot
{
    [SerializeField]
    GameManager GameManager;

    public int AccseptanceOnBuilt = 25;
    public int FavorsToBuild;
    public SpriteRenderer renderer;
    public override void Interact()
    {
        Build();
    }

    void Build()
    {
        if (GameManager.Favors >= FavorsToBuild)
        {
            renderer.color = Color.white;
            GameManager.Acceptance += AccseptanceOnBuilt;
        }
    }
}

