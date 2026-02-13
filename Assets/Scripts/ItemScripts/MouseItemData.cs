using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MouseItemData: MonoBehaviour
{
    public UnityEngine.UI.Image ItemSprite;
    public TextMeshProUGUI ItemCount;
    private void Awake()
    {
        ItemSprite.color = Color.clear;
        ItemCount.text = "";
;    }
}
