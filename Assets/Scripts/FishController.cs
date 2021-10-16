using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FishController : MonoBehaviour
{
    [SerializeField] FishData data;
    public int FishId { get; private set; }
    public int FishScore { get; private set; }
    public float fishSpeed { get; private set; }
    public Sprite fishImg { get; private set; }
    //[SerializeField] bool dummy = false;

    // Start is called before the first frame update
    void Awake()
    {
        fishSpeed = data.fishSpeed;
        FishId = data.fishId;
        FishScore = data.fishScore;
        fishImg = data.fishImg;
        gameObject.GetComponent<SpriteRenderer>().sprite = fishImg;
    }
    //includes some movement;

    private void Start()
    {
       // if (dummy) return;
    }
}
