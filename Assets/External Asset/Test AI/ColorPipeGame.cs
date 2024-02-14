using System.Collections.Generic;
using UnityEngine;

public class ColorPipeGame : MonoBehaviour
{
    public int gridSizeX;  // Number of columns on the grid
    public int gridSizeY;  // Number of rows on the grid
    public GameObject pipePrefab;  // Prefab for the pipe object
    public GameObject startPipe;  // Start pipe object
    public GameObject endPipe;  // End pipe object

    private Pipe[,] grid;  // 2D array to hold the pipes in the grid

    private void Start()
    {
        // Generate and populate the grid
        GenerateGrid();
        PopulateGrid();
    }

    private void GenerateGrid()
    {
        grid = new Pipe[gridSizeX, gridSizeY];

        // Create pipes at each position in the grid
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                GameObject pipeObject = Instantiate(pipePrefab, new Vector3(x, y, 0), Quaternion.identity);
                Pipe pipe = pipeObject.GetComponent<Pipe>();
                pipe.SetPosition(x, y);

                grid[x, y] = pipe;
            }
        }
    }

    private void PopulateGrid()
    {
        // Assign random colors to each pipe
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Pipe pipe = grid[x, y];
                pipe.SetColor(Random.ColorHSV());
            }
        }

        // Set start and end pipes
        Pipe startPipeScript = startPipe.GetComponent<Pipe>();
        Pipe endPipeScript = endPipe.GetComponent<Pipe>();

        startPipeScript.SetPosition(0, 0);
        endPipeScript.SetPosition(gridSizeX - 1, gridSizeY - 1);

        grid[0, 0] = startPipeScript;
        grid[gridSizeX - 1, gridSizeY - 1] = endPipeScript;
    }

    // TODO: Implement methods for pipe rotation, connection checks, flow animation, win condition, etc.
}

