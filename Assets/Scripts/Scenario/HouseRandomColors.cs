using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseRandomColors : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer[] renderers;

    [SerializeField]
    string id = "";

    private void Awake() {
        if (id == "") {
            Debug.LogWarning("House without ID", gameObject);
        }
    }

    private void Start() {
        HouseColors house = SaveDataManager.Instance.houseData.GetHouseColors(id);

        if (house.id == HouseData.EMPTY_HOUSE) {
            SetNewColors();
        } else {
            AssignColors(house);
        }
    }

    private void SetNewColors() {
        for (int i = 0; i < renderers.Length; i++) {
            renderers[i].color = RandomColor.Generate();
        }

        SaveDataManager.Instance.houseData.Savehouse(
            id, renderers[0].color, renderers[1].color, renderers[2].color, renderers[3].color);
    }

    private void AssignColors(HouseColors house) {
        renderers[0].color = house.colorBase;
        renderers[1].color = house.colorWall;
        renderers[2].color = house.colorUpperWall;
        renderers[3].color = house.colorRoof;
    }
}
