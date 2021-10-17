using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] Image targetFish;
    static int playerScore;
    public static ScoreManager Instance;
    [SerializeField] GameObject gameoverPanel;
    [SerializeField] GameObject[] healthIcons;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }

    }
    // Start is called before the first frame update
    private void Start()
    {
        UpdateScore(0);
    }

    public void UpdateScore(int score)
    {
        playerScore += score;
        this.score.text = $"{playerScore}";
    }
    public void UpdateFishImg(Sprite sprite)
    {
        targetFish.sprite = sprite;
    }
    public void UpdateHealth(int healthLeft)
    {
        healthIcons[healthLeft].transform.DOScale(Vector3.zero, .5f);
    }

    public void ToggleGameOver(bool enable)
    {
        if (!enable)
        {
            UpdateScore(0);
            foreach (var health in healthIcons)
            {
                health.transform.DOScale(Vector3.one, 0.5f);
            }
        }
        gameoverPanel.SetActive(enable);
    }
}
