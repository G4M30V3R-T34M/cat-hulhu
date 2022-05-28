using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public abstract class Item : MonoBehaviour
{
    [SerializeField] protected ItemScriptableObject itemSettings;

    protected SpriteRenderer itemSprite;
    protected Collider2D collider;

    public bool basicItem = true;

    protected virtual void Awake() {
        itemSprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
    }
    
    protected virtual void Start() { }

    public bool IsWeapon() {
        return itemSettings.isWeapon;
    }

    public void DropItem(Vector3 position) {
        this.transform.position = position;
        itemSprite.enabled = true;
        collider.enabled = true;
    }

    public void Pick(GameObject character) {
        if (basicItem) {
            itemSprite.enabled = false;
            collider.enabled = false;
        }

        ActionOnPick(character);
    }

    /*
     * Abstract functions
     */
    /// <summary>
    /// Abstract function for the item actions when is picked
    /// </summary>
    protected abstract void ActionOnPick(GameObject character);

    /// <summary>
    /// Abstract function for the item when user attack
    /// </summary>
    public abstract void Attack();
}
