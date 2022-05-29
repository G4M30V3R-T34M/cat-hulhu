using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct HouseColors
{
    public HouseColors(string id, Color colorBase, Color colorWall, Color colorUpperWall, Color colorRoof) {
        this.id = id;
        this.colorBase = colorBase;
        this.colorWall = colorWall;
        this.colorUpperWall = colorUpperWall;
        this.colorRoof = colorRoof;
    }

    public string id;
    public Color colorBase;
    public Color colorWall;
    public Color colorUpperWall;
    public Color colorRoof;

}
