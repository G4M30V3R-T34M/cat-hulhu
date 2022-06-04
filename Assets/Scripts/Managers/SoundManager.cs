using UnityEngine;
using Feto;

[RequireComponent(typeof(ObjectPool))]
public class SoundManager : Singleton<SoundManager>
{
    ObjectPool soundPool;

    protected override void Awake() {
        base.Awake();
        soundPool = GetComponent<ObjectPool>();
    }

    public void PlayClip(AudioClip clip) {
        SoundEffect sound = (SoundEffect)soundPool.GetNext();
        sound.gameObject.SetActive(true);
        sound.PlaySound(clip);
    }
}
