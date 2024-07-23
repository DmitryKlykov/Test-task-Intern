using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] int tapValue = 1;
    [SerializeField] int upgradePrice = 20;
    [SerializeField] int playerLevel = 1;

    public Transform spawnPoint;
    public GameObject moneyPrefab;
    public TMP_Text scoreText;
    public TMP_Text playerLevelText;
    public TMP_Text tapValueText;
    public TMP_Text upgradePriceText;

    private void Update()
    {
        // Text output
        scoreText.text = score.ToString();
        playerLevelText.text = "LV " + playerLevel.ToString();
        tapValueText.text = "+" + tapValue.ToString();
        upgradePriceText.text = "UPGRADE " + upgradePrice.ToString();
    }

    public void OnClickButton()
    {
        score += tapValue;
        SpawnMoney();
    }

    public void OnUpgrade()
    {
        if (score >= upgradePrice)
        {
            playerLevel++;
            score -= upgradePrice;
            tapValue += 2;
            upgradePrice += 10;  
        }
    }

    private void SpawnMoney()
    {
        GameObject moneyInstance = Instantiate(moneyPrefab, spawnPoint.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        Vector2 direction = new Vector2(Random.Range(-0.4f, 0.4f), 1f);
        Rigidbody2D rb = moneyInstance.GetComponent<Rigidbody2D>();
        rb.velocity = direction * 10f;
    }
}
