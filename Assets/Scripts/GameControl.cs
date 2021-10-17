using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl Instance;
    [SerializeField] ScoreManager scoreboard;
    [SerializeField] PlayerControl player;
    //[SerializeField] GameObject[] fishPool;
    private Dictionary<int, FishController> fishDic;
    public static int TargetFishId { get; private set; }
    private int totalHealth = 3;
    private int currentHealth;
    //private int maxFishId;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        //maxFishId = fishPool.Length;
        EatFish.OnPlayerEatFish += CheckEatResult;
        DontDestroyOnLoad(gameObject);
    }

    private void CheckEatResult(object sender, GameObject fish)
    {
        FishController fishC = fish.GetComponent<FishController>();
        if (fishC == null)
        {
            Debug.LogWarning("Fish has no controller attached!!!");
            return;
        }
        //compareId
        if (TargetFishId == fishC.FishId)
        {
            ScoreManager.Instance.UpdateScore(fishC.FishScore);
            Destroy(fish);
            SpwanFish.Instance.UpdateExistingFish(fishC.FishId);
            //refill pool and update new target;
            SpwanFish.Instance.InitSpwanFish(1);
            GenerateTargetId();
        }
        else
        {
            --currentHealth;
            ScoreManager.Instance.UpdateHealth(currentHealth);
            if (currentHealth < 1)
            {
                player.IsGameOver = true;
                ScoreManager.Instance.ToggleGameOver(true);

            }

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        FormFishDic(SpwanFish.Instance.fishTank);
        GenerateTargetId();
        currentHealth = totalHealth;
    }
    void FormFishDic(GameObject[] pool)
    {
        fishDic = new Dictionary<int, FishController>();
        foreach (GameObject fish in pool)
        {
            FishController controller = fish.GetComponent<FishController>();
            int key = controller.FishId;
            if (!fishDic.ContainsKey(key))
                fishDic.Add(key, controller);
            else
            {
                Debug.LogWarning($"Same Key already exist {key}");
            }
        }
    }
    //also tell ui to update the target pic
    private void GenerateTargetId()
    {
        List<int> livePool = SpwanFish.Instance.existFishIds;
        TargetFishId = livePool[UnityEngine.Random.Range(0, livePool.Count)];
        ScoreManager.Instance.UpdateFishImg(fishDic[TargetFishId].fishImg);
        Debug.Log(TargetFishId);
    }

    public void RePlay()
    {
        SpwanFish.Instance.Refresh();
        GenerateTargetId();
        ScoreManager.Instance.ToggleGameOver(false);
        player.IsGameOver = false;
        currentHealth = totalHealth;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
