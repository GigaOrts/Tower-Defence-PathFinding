using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] private int _startingBalance = 150;
    [SerializeField] private TMP_Text _displayBalance;

    private int _currentBalance;
    public int CurrentBalance => _currentBalance;

    private void Awake()
    {
        _currentBalance = _startingBalance;
        UpdateBalance();
    }

    private void UpdateBalance()
    {
        _displayBalance.text = $"Gold: {_currentBalance}";
    }

    public void Deposit(int amount)
    {
        _currentBalance += Mathf.Abs(amount);
        UpdateBalance();
    }

    public void Withdraw(int amount)
    {
        _currentBalance -= Mathf.Abs(amount);
        UpdateBalance();

        if (_currentBalance < 0)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}
