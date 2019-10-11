using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    int gridWidth = 50;
    int gridHeight = 50;

    float cellDimension = 1f;
    float cellSpacing = 0.1f;

    public CellScript[ , ] grid;

    public GameObject cellPrefab;
    bool simulate = false;

    float generationRate = 0.5f;
    float generationTimer;

    int time = 0;
    GameObject cellObj;

    // Start is called before the first frame update
    void Start()
    {
        grid = new CellScript[gridWidth, gridHeight];

        for(int x = 0; x < gridWidth; x++)
        {
            for(int y = 0; y < gridHeight; y++)
            {
                Vector3 pos = new Vector3(x * (cellDimension + cellSpacing), 0 , y * (cellDimension + cellSpacing));
                GameObject cellObj = Instantiate(cellPrefab, pos, Quaternion.identity);
                CellScript cs = cellObj.AddComponent<CellScript>();
                cs.x = x;
                cs.y = y;
                cs.alive = (Random.value > 0.5f) ? true : false;
                cs.updateColor();
                
                cellObj.transform.position = pos;
                cellObj.transform.localScale = new Vector3(cellDimension, cellDimension, cellDimension);

                grid[x,y] = cs;
            }
        }
        generationTimer = generationRate;
    }

    public void Update()
    {
        generationTimer -= Time.deltaTime;

        if(generationTimer < 0 && simulate)
        {
            //generate next state
            generate();

            //reset timer
            generationTimer = generationRate;
        }

        else if(!simulate)
        {
            generationTimer = generationRate;
        }
    }

    void generate()
	{
		time++;

		for (int x = 0; x < gridWidth; x++) 
        {
			for (int y = 0; y < gridHeight; y++) 
            {
				List<CellScript> liveNeighbors = gatherLiveNeighbors(x, y);
				//1. Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
				if (grid[x, y].alive && liveNeighbors.Count < 2) 
                {
					grid[x, y].nextAlive = false;
				}
				//2. Any live cell with two or three live neighbours lives on to the next generation.
				else if (grid[x, y].alive && (liveNeighbors.Count == 2 || liveNeighbors.Count == 3)) 
                {
					grid[x, y].nextAlive = true;
				}
				//3. Any live cell with more than three live neighbours dies, as if by overpopulation.
				else if (grid[x, y].alive && liveNeighbors.Count > 3) 
                {
					grid[x, y].nextAlive = false;
				}
				//4. Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
				else if (!grid[x, y].alive && liveNeighbors.Count == 3) 
                {
					grid[x, y].nextAlive = true;
				}
			}
		}
		for (int x = 0; x < gridWidth; x++) 
        {
			for (int y = 0; y < gridHeight; y++) 
            {
				grid[x, y].alive = grid[x, y].nextAlive;
			}
		}
	}
    List<CellScript> gatherLiveNeighbors(int x, int y)
    {
        List<CellScript> neighbors = new List<CellScript>();
        for(int i = Mathf.Max(0, x - 1); i < Mathf.Min(gridWidth-1, x+1); i++)
        {
            for(int j = Mathf.Max(0, y - 1); j < Mathf.Min(gridWidth-1, y+1); j++)
            {
                if(grid[i,j].alive)
                {
                    neighbors.Add(grid[i,j]);
                }
                
            }
        }
        return neighbors;
    }

    public void toggleSimulate(bool value)
    {
        simulate = value;
    }
    
}
