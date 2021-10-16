using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/FishData", order = 1)]
public class FishData : ScriptableObject
{
    public int fishId;
    public float fishSpeed;
    public int fishScore;
    public Sprite fishImg;
}
