using System.Linq;
using UnityEngine;
using Zenject;

public class GridInitializer : MonoBehaviour
{
    [SerializeField] private GameGrid[] openGrids;

    [SerializeField] private GameGrid[] closedGrids;
    
    [Inject]
    public void Init()
    {
        foreach (var grid in openGrids)
        {
            grid.Init();
        }

        foreach (var closedGrid in closedGrids)
        {
            if (!PlayerPrefs.HasKey(closedGrid.GridName))
            {
                PlayerPrefs.SetInt(closedGrid.GridName, 0);
                return;
            }

            if (PlayerPrefs.GetInt(closedGrid.GridName) == 1)
            {
                closedGrid.Init();
            }
        }
    }

    public void Save(GameGrid grid)
    {
        if(PlayerPrefs.GetInt(grid.GridName) == 1)
            return;
        
        grid.gameObject.SetActive(true);
        grid.Init();
        PlayerPrefs.SetInt(grid.GridName, 1);
    }
}
