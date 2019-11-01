using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // can't see 2D array in inspector
    public Transform[] roomSpawnersRow0;
    public Transform[] roomSpawnersRow1;
    public Transform[] roomSpawnersRow2;
    public Transform[] roomSpawnersRow3;

    public GameObject[] rooms;

    public int testRow = 0;
    public int testColumn = 0;
    public int testType = 0;

    private int lastUsedRow;
    private int lastUsedCol;

    enum withinLimits { sides, downOnce, nonPath };

    // Use this for initialization
    void Start()
    {
        int rnd = Random.Range(0, 4);                           // Generates random number 0-3
        GenerateRandomRoom(0, rnd, withinLimits.sides);         // Generate starting room

        lastUsedRow = 0;
        lastUsedCol = rnd;

        // Generate the map
        GenerateSolutionPath();
        GenerateNonSolutionPath();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddRoom(testRow, testColumn, testType);
        }
    }

    public void AddRoom(int row, int column, int roomType)
    {
        // figure out position to spawn at
        Transform[] spawnPos = null;

        switch (row)
        {
            case 0:
                spawnPos = roomSpawnersRow0;
                break;
            case 1:
                spawnPos = roomSpawnersRow1;
                break;
            case 2:
                spawnPos = roomSpawnersRow2;
                break;
            case 3:
                spawnPos = roomSpawnersRow3;
                break;
        }

        // actually spawn it
        var newRoom = Instantiate(rooms[roomType], spawnPos[column].position, transform.rotation);
        spawnPos[column] = newRoom.transform;
    }

    private void GenerateRandomRoom(int row, int col, withinLimits limits)
    {
        /*
         * 0 = Not part of solution path - no entrances/exits
         * 1 = Has exits to the right and left
         * 2 = Has exits to the right, left, and downwards
         * 3 = Has exits to the right, left, and upwards 
         * 4 = All 4 sides are open
        */

        int randNum = 0;
        switch (limits)
        {
            case withinLimits.sides:
                randNum = 1;
                break;

            case withinLimits.downOnce:
                randNum = 3;
                break;

            case withinLimits.nonPath:
                randNum = Random.Range(0, 2);
                break;
        }

        AddRoom(row, col, randNum);
    }

    private void GenerateSolutionPath()
    {
        int downCounter = 0;

        for (; ; )
        {
            int rnd = Random.Range(1, 6);            // 1-5

            if (rnd == 1 || rnd == 2)                // Move Left
            {
                if (isSpotOK(lastUsedRow, lastUsedCol - 1))
                {
                    GenerateRandomRoom(lastUsedRow, lastUsedCol - 1, withinLimits.sides);
                    lastUsedCol--;
                    downCounter = 0;
                }
                else
                {
                    rnd = 5;
                }
            }
            else if (rnd == 3 || rnd == 4)           // Move Right
            {
                if (isSpotOK(lastUsedRow, lastUsedCol + 1))
                {
                    GenerateRandomRoom(lastUsedRow, lastUsedCol + 1, withinLimits.sides);
                    lastUsedCol++;
                    downCounter = 0;
                }
                else
                {
                    rnd = 5;
                }
            }
            else if (rnd == 5)                       // Move Down
            {
                downCounter++;
                int newRoomToSpawn = (downCounter >= 2 ? 4 : 2);
                ReplaceRoom(lastUsedRow, lastUsedCol, newRoomToSpawn);

                if (isSpotOK(lastUsedRow + 1, lastUsedCol))
                {
                    GenerateRandomRoom(lastUsedRow + 1, lastUsedCol, withinLimits.downOnce);
                    lastUsedRow++;
                }
                else
                {
                    break;
                }
            }
        }
    }

    private void ReplaceRoom(int row, int column, int newRoom)
    {
        Transform[] currentRow = null;
        switch (row)
        {
            case 0:
                currentRow = roomSpawnersRow0;
                break;
            case 1:
                currentRow = roomSpawnersRow1;
                break;
            case 2:
                currentRow = roomSpawnersRow2;
                break;
            case 3:
                currentRow = roomSpawnersRow3;
                break;
        }

        if (currentRow[column].tag != "EmptySpot")
        {
            Destroy(currentRow[column].gameObject);
            AddRoom(row, column, newRoom);
        }
    }

    private bool isSpotOK(int row, int column)
    {
        if (row < 0 || row >= 4) { return false; }
        if (column < 0 || column >= 4) { return false; }

        Transform[] currentRow = null;

        switch (row)
        {
            case 0:
                currentRow = roomSpawnersRow0;
                break;
            case 1:
                currentRow = roomSpawnersRow1;
                break;
            case 2:
                currentRow = roomSpawnersRow2;
                break;
            case 3:
                currentRow = roomSpawnersRow3;
                break;
        }

        if (currentRow[column].tag != "EmptySpot")
            return false;

        return true;
    }

    private void GenerateNonSolutionPath()
    {
        Transform[] currentRow = null;
        for (int row = 0; row < 4; row++)
        {
            switch (row)
            {
                case 0:
                    currentRow = roomSpawnersRow0;
                    break;
                case 1:
                    currentRow = roomSpawnersRow1;
                    break;
                case 2:
                    currentRow = roomSpawnersRow2;
                    break;
                case 3:
                    currentRow = roomSpawnersRow3;
                    break;
            }

            for (int col = 0; col < 4; col++)
            {
                if (currentRow[col].gameObject.tag == "EmptySpot")
                {
                    GenerateRandomRoom(row, col, withinLimits.nonPath);
                }
            }

        }
    }
}
