using UnityEngine;

public class LoadBigMapPosition : MonoBehaviour
{
    [SerializeField]
    PlayerPositionBigMapScriptable position;

    private void Awake() {
        transform.position = new Vector2(position.xPos, position.yPos);
    }

}
