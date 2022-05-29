using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseData : MonoBehaviour
{
    public const string EMPTY_HOUSE = "";
    List<HouseColors> houses = new List<HouseColors>();

    public HouseColors GetHouseColors(string houseId) {
        HouseColors house = new HouseColors(EMPTY_HOUSE, Color.black, Color.black, Color.black, Color.black);

        int i = 0;
        while (i < houses.Count && house.id  == EMPTY_HOUSE) {
            if (houses[i].id == houseId) {
                house = houses[i];
            }
            i++;
        }

        return house;
    }

    public void Savehouse(string id, Color colorBase, Color colorWall, Color colorUpperWall, Color colorRoof) {
        HouseColors house = new HouseColors(id, colorBase, colorWall, colorUpperWall, colorRoof);
        houses.Add(house);
    }
}
