using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public List<GameObject> TilePrefabs = new List<GameObject>();
    public int GridDimension = 8;
    public float Distance = 1.0f;
    private GameObject[,] Grid;

    private void Start()
    {
        Grid = new GameObject[GridDimension, GridDimension];
        InitGrid();
    }

    void InitGrid()
    {
        Vector3 positionOffset = transform.position - new Vector3(GridDimension * Distance / 2.0f, GridDimension * Distance / 2.0f, 0);

        for (int row = 0; row < GridDimension; row++)
        {
            for (int column = 0; column < GridDimension; column++)
            {
                GameObject newTile = Instantiate(TilePrefabs[Random.Range(0, TilePrefabs.Count)]);
                newTile.transform.parent = transform;
                newTile.transform.position = new Vector3(column * Distance, row * Distance, 0) + positionOffset;

                Grid[column, row] = newTile;
            }
        }
    }

    GameObject GetTileAt(int column, int row) // Changed function name and return type
    {
        if (column < 0 || column >= GridDimension || row < 0 || row >= GridDimension)
            return null;
        return Grid[column, row];
    }
}
