using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioClip ambientBirds;
    public AudioClip ambientWater;
    public AudioClip ambientWind;
    public AudioClip ambientFire;
    public AudioClip ambientRain;

    public AudioClip anvilHitSound;

    public delegate void AnvilHitAction(Collider col);
    public static event AnvilHitAction OnAnvilHit;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;

    }
    void OnEnable()
    {
        OnAnvilHit += PlayAvilHit;
    }
    void OnDisable()
    {
        OnAnvilHit -= PlayAvilHit;
    }

    public void AnvilHit(Collider col)
    {
        if (OnAnvilHit != null)
            OnAnvilHit(col);
    }

    void PlayAvilHit(Collider col)
    {
        GetComponent<AudioSource>().clip = anvilHitSound;
        GetComponent<AudioSource>().Play();
    }
   
}
