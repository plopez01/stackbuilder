using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private List<StackLevel> levels = new();
    [SerializeField] private Transform levelList;

    [SerializeField] private GameObject levelButtonPrefab;
    [SerializeField] private string gameSceneName;
    // Start is called before the first frame update
    void Start()
    {
        foreach (StackLevel level in levels)
        {
            GameObject newButton = Instantiate(levelButtonPrefab, levelList);

            TextMeshProUGUI buttonText = newButton.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = level.name;

            Button button = newButton.GetComponent<Button>();
            button.onClick.AddListener(() => {
                Manager.currentLevel = level;
                SceneManager.LoadScene(gameSceneName);
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
