using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksGenerator : MonoBehaviour {

    public GameObject[] blocks;
    public int lines;

	// Use this for initialization
	void Start () {
        CreateBlockGroup();
	}
	
	void CreateBlockGroup()
    {
        Bounds blockEdges = blocks[0].GetComponent<SpriteRenderer>().bounds;
        float blockWidth = blockEdges.size.x;
        float blockHeight = blockEdges.size.y;
        float screenWidth, screenHeight, widthMultiplier;
        int collumns;
        GetBlockInformation(blockWidth, out screenWidth, out screenHeight, out collumns, out widthMultiplier);

        MyGameManager.blocksTotalNumber = lines * collumns;

        for (int i = 0; i < lines; i++)
        {
            for (int j = 0; j < collumns; j++)
            {
                GameObject randomBlock = blocks[Random.Range(0, blocks.Length)];
                GameObject block = Instantiate<GameObject>(randomBlock); // Intancio um bloco para que o mesmo apareça na tela
                block.transform.position = new Vector3(
                    -(screenWidth * 0.5f) + (j * blockWidth * widthMultiplier), 
                    (screenHeight * 0.5f) - (i * blockHeight));
                float blockNewWidth = block.transform.localScale.x * widthMultiplier;

                block.transform.localScale = new Vector3(blockNewWidth, block.transform.localScale.y, 1);
            }
        }
    }

    void GetBlockInformation(float blockWidth, out float screenWidth, out float screenHeight, out int collumns, out float widthMultiplier)
    {
        Camera camera = Camera.main;
        screenWidth = (camera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)) - camera.ScreenToWorldPoint(new Vector3(0, 0, 0))).x;
        screenHeight = (camera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)) - camera.ScreenToWorldPoint(new Vector3(0, 0, 0))).y;
        collumns = (int) (screenWidth / blockWidth);
        widthMultiplier = screenWidth / (collumns * blockWidth);
    }
}
