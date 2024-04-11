using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject miniGameMenu;

    // Координаты для телепортации
    private Vector3 miniGameMenuPosition = new Vector3(-0.01251f, 0.007412f, 0.00102f);
    private Vector3 mainMenuPosition = new Vector3(-0.01247f, 0.02472f, 0.00102f);

    public void SwitchToMiniGameMenu()
    {
        // Перемещение MiniGameMenu на новые координаты
        miniGameMenu.transform.position = miniGameMenuPosition;

        // Перемещение MainMenu на новые координаты
        mainMenu.transform.position = mainMenuPosition;
    }
}