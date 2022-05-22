using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class Item : MonoBehaviour
{
    [SerializeField] protected ItemScriptableObject itemSettings;

    protected SpriteRenderer itemSprite;

    protected void Awake()
    {
        itemSprite = GetComponent<SpriteRenderer>();
    }

    public bool IsWeapon()
    {
        return itemSettings.isWeapon;
    }

    public void DropItem(Vector3 position)
    {
        this.transform.position = position;
        itemSprite.enabled = true;
        // Maybe it will be needed to enable collider
    }

    public void Pick()
    {
        itemSprite.enabled = false;
        // Maybe it will be needed to disable collider too

        ActionOnPick();
    }

    /*
     * Abstract functions
     */
    protected abstract void ActionOnPick();
    public abstract void Attack();
}
