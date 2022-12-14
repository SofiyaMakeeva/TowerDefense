using UnityEngine;

public class GameOverScreen : Screen
{
    [SerializeField] private GameObject _winText;
    [SerializeField] private GameObject _gameOverText;
    [SerializeField] private Player _player;

    public static GameOverScreen GameOver;

    private void Awake()
    {
        if (GameOver != null && GameOver != this)
        {
            Destroy(gameObject);
        }
        else
        {
            GameOver = this;
        }
    }

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        CanvasGroup.interactable = false;
        CanvasGroup.blocksRaycasts = false;
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        CanvasGroup.interactable = true;
        CanvasGroup.blocksRaycasts = true;

        if (_player.Health <= 0)
        {
            _gameOverText.SetActive(true);
        }
        else
        {
            _winText.SetActive(true);
        }
    }

    protected override void OnEXitButtonClick()
    {
        Application.Quit();
    }

    protected override void OnPlayButtonClick()
    {

    }
}
