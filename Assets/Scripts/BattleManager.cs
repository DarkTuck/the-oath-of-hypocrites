using System.Threading.Tasks;
using UnityEngine;
using TMPro;

public class BattleManager : MonoBehaviour
{
    [SerializeField] int enemyHealth, playerHealth, enemyDamage, playerDamage;
    [SerializeField] GameObject gameOverPanel, winPanel;
    [SerializeField] TextMeshProUGUI playerHealthText, enemyHealthText, damageText;
    bool isPlayerTurn = true;

public async void DamageEnemy()
    {
        if (isPlayerTurn)
        {
            isPlayerTurn = false;
            enemyHealth-=playerDamage;
            damageText.text = damageText.text=$@"Enemy was Damaged for {playerDamage} damage health is now {enemyHealth}";
            enemyHealthText.text=enemyHealth.ToString();
            if (enemyHealth <= 0)
            {
                WinCombat();
            }

            await EnemyTurn();
            isPlayerTurn = true;
        }
    }

    async Task EnemyTurn()
    {
        await Task.Delay(Random.Range(1, 5)*1000);
        int rand = Random.Range(0, enemyDamage);
        if (rand == 0)
        {
            damageText.text = "Enemy missed";
            return;
        }
        playerHealth -= rand;
        playerHealthText.text = playerHealth.ToString();
        damageText.text = $@"Player was damaged for {rand} health is now {playerHealth}";
        if (playerHealth <= 0)
        {
            FailCombat();
        }
        
    }
        
    void FailCombat()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    void WinCombat()
    {
        winPanel.SetActive(true);
    }
}
