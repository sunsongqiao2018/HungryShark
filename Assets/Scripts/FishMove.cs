using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FishMove : MonoBehaviour
{
    public void SetFishMove(float fishSpeed)
    {
        int dice = Random.Range(0, 3);
        switch (dice)
        {
            case 0:
                transform.DOMoveX(Random.Range(2, 4), 10 / fishSpeed).SetLoops(-1, LoopType.Yoyo);
                break;

            case 1:
                transform.DOMoveY(Random.Range(2, 4), 10 / fishSpeed).SetLoops(-1, LoopType.Yoyo);
                break;

            case 2:
                transform.DOBlendableMoveBy(Vector3.up * Random.Range(-2, -4), 20 / fishSpeed).SetLoops(-1, LoopType.Yoyo);
                transform.DOBlendableMoveBy(Vector3.right * Random.Range(-2, -1), 30 / fishSpeed).SetLoops(-1, LoopType.Yoyo);
                break;
            default:
                break;
        }
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }
}
