using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Metal", menuName = "Weapon Materials/Metal")]
public class ScriptableMaterial : ScriptableObject
{
    public float heatTime;
    public float coolTime;
    public float hitTempMin;
    public float hitTempMax;
    public bool needsHardening;
}
