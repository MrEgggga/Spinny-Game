using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelectButton : MonoBehaviour
{
    public Image background;
    public TextMeshProUGUI levelNumber;
    public TextMeshProUGUI levelName;
    public TextMeshProUGUI yourTime;
    public TextMeshProUGUI goldTime;
    public Button button;
    public Color locked;
    public Color incomplete;
    public Color complete;
    public Color gold;
    public int level;
    public bool secretLevel = false;
    private LevelCompletionData lcd;
    private RectTransform rt;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        Invoke("SetupButton", 0.1f);
        rt = GetComponent<RectTransform>();
    }

    void SetupButton()
    {
        float width = rt.rect.width;
        float height = rt.rect.height;

        int column = level % 5;
        int row = level / 5;
        rt.anchoredPosition = new Vector2((column - 2) * width * 1.1f, (row + 0.5f) * height * -1.1f);

        lcd = LevelCompletionData.instance;
        if(secretLevel)
        {
            LevelCompletionData.SecretLevelData ld = lcd.levelData.secretLevelData[level];
            Level lv = lcd.secretLevels[level];

            levelNumber.text = string.Format("S{0}", level + 1);
            levelName.text = lv.name;
            yourTime.text = ld.bestTime == Mathf.Infinity ? "" : string.Format(" {0:000.000}", ld.bestTime);
            goldTime.text = "[" + string.Format("{0:000.000}", lv.goldTime) + "]";

            background.color = ld.unlocked ? 
                (ld.completed ? 
                    (ld.haveGold ? gold : complete) : 
                    incomplete) : 
                locked;

            if(ld.unlocked) button.onClick.AddListener(LoadLevel);
            gameObject.SetActive(true);
            return;
        }
        else
        {
            LevelCompletionData.LevelData ld = lcd.levelData.levelData[level];
            Level lv = lcd.levels[level];

            levelNumber.text = string.Format("{0}", level + 1);
            levelName.text = lv.name;
            yourTime.text = ld.bestTime == Mathf.Infinity ? "" : string.Format(" {0:000.000}", ld.bestTime);
            goldTime.text = "[" + string.Format("{0:000.000}", lv.goldTime) + "]";

            background.color = ld.completed ? (ld.haveGold ? gold : complete) : incomplete;

            button.onClick.AddListener(LoadLevel);
            gameObject.SetActive(true);
        }
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(secretLevel ? lcd.secretLevels[level].buildIndex : lcd.levels[level].buildIndex);
    }
}
