using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanFish : MonoBehaviour
{
    [SerializeField] Transform fishPoolTrans;
    //public int activeFishes;
    public GameObject[] fishTank;
    public List<int> existFishIds;
    public static SpwanFish Instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        fishPoolTrans = gameObject.transform;
        // fishTank = GameControl.Instance.GetFishPool();
        //existFishIds = new List<int>();
        //InitSpwanFish(Random.Range(2, 4));
        Refresh();
    }
    public void InitSpwanFish(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            float spawnY = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height / 2)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            float spawnX = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 3, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

            Vector2 spawnPosition = new Vector2(spawnX, spawnY);
            //Vector3 spawnPosition = new Vector3(Random.Range(0, 1), Random.Range(0, 1), Camera.main.nearClipPlane);
            GameObject liveFish = Instantiate(fishTank[Random.Range(0, fishTank.Length)], spawnPosition, Quaternion.identity);
            liveFish.transform.SetParent(fishPoolTrans);
            liveFish.AddComponent<FishMove>().SetFishMove(liveFish.GetComponent<FishController>().fishSpeed);
            existFishIds.Add(liveFish.GetComponent<FishController>().FishId);
        }
    }
    public void UpdateExistingFish(int idToRemove)
    {
        existFishIds.Remove(existFishIds.Find(x => x == idToRemove));
    }

    public void Refresh()
    {
        existFishIds = new List<int>();
        int childs = fishPoolTrans.childCount;
        for (int i = childs - 1; i > 0; i--)
        {
            Destroy(fishPoolTrans.GetChild(i).gameObject);
        }
        InitSpwanFish(Random.Range(2, 4));
    }
}
