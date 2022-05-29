using UnityEngine;

public class LoadBigMapPosition : MonoBehaviour
{
    private void Start() {
        transform.position = SaveDataManager.Instance.playerData.lastBigMapPosition;
    }
}
