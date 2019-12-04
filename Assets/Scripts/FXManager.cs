using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    public static FXManager instance;
    [Header("Enviroment Sound")]
    public AudioClip ambientBirds;
    public AudioClip ambientWater;
    public AudioClip ambientWind;
    public AudioClip ambientFire;
    public AudioClip ambientRain;
    [Header("Action Sounds")]
    public AudioClip anvilHitSound;
    [Header("GamePlay Sounds")]
    public AudioClip jobAcceptSound;
    public AudioClip jobCompleteSound;
    [Header("Action Effects")]
    public GameObject hammerHitEffect;
    public GameObject hammerBadEffect;
    public GameObject generalFeedbackEffect;

    public delegate void AnvilHitAction(Collider col);
    public static event AnvilHitAction OnAnvilHit;

    public delegate void AnvilBadHitAction(Collider col);
    public static event AnvilBadHitAction OnAnvilBadHit;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;

    }
    void OnEnable()
    {
        OnAnvilHit += PlayAvilHit;
        OnAnvilBadHit += PlayAvilBadHit;
    }
    void OnDisable()
    {
        OnAnvilHit -= PlayAvilHit;

        OnAnvilBadHit -= PlayAvilBadHit;
    }

    public void AnvilHit(Collider col)
    {
        if (OnAnvilHit != null)
            OnAnvilHit(col);
    }

    public void AnvilBadHit(Collider col)
    {
        if (OnAnvilBadHit != null)
            OnAnvilBadHit(col);
    }

    public void OnAcceptJob()
    {
        GetComponent<AudioSource>().clip = jobAcceptSound;
        GetComponent<AudioSource>().pitch = 1f;
        GetComponent<AudioSource>().Play();
    }
    public void OnJobCompletion()
    {
        GetComponent<AudioSource>().clip = jobCompleteSound;
        GetComponent<AudioSource>().pitch = 1f;
        GetComponent<AudioSource>().Play();
    }

    void PlayAvilHit(Collider col)
    {
        EffectSpawner(hammerHitEffect, col.transform.position, Quaternion.identity,3f);
        GetComponent<AudioSource>().clip = anvilHitSound;
        GetComponent<AudioSource>().pitch = 1f;
        GetComponent<AudioSource>().Play();
    }
    void PlayAvilBadHit(Collider col)
    {
        EffectSpawner(hammerBadEffect, col.transform.position, Quaternion.identity, 3f);
        GetComponent<AudioSource>().clip = anvilHitSound;
        GetComponent<AudioSource>().pitch = 0.2f;
        GetComponent<AudioSource>().Play();
        print("bad hit");
    }
    void EffectSpawner(GameObject effect, Vector3 pos, Quaternion rot, float lifeTime)
    {
       GameObject ef = Instantiate(hammerHitEffect, pos, rot) as GameObject;

        Destroy(ef, lifeTime);
    }

}
