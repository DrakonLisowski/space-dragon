using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMap : MonoBehaviour
{
    public int mapWidth;
    public int mapHeight;

    private int mapWidthReal;
    private int mapHeightReal;

    // Start is called before the first frame update
    void Start()
    {
        mapWidthReal = mapWidth;
        mapHeightReal = mapHeight;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
