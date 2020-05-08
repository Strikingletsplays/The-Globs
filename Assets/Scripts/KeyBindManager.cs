using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyBindManager : MonoBehaviour
{
    public static KeyBindManager controls;

    public Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    public TextMeshProUGUI MoveForward, MoveBack, Jump, PickUp, Glow, EatAGlob, DropWeapon, UseKey;
    private GameObject currentKey;

    //Colors
    private Color32 normal = new Color32(128, 128, 128, 255);
    private Color32 selected = new Color32(245, 245, 245, 148);

    // Start is called before the first frame update
    void Start()
    {
        keys.Add("Move Forward", (KeyCode) System.Enum.Parse(typeof(KeyCode),PlayerPrefs.GetString("Move Forward","D")));
        keys.Add("Move Back", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Move Back", "A")));
        keys.Add("Jump", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "Space")));
        keys.Add("Pick Up", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Pick Up", "Mouse0")));
        keys.Add("Glow", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Glow", "G")));
        keys.Add("Eat a Glob", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Eat a Glob", "E")));
        keys.Add("Drop Weapon", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Drop Weapon", "X")));
        keys.Add("Use Key", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Use Key", "F")));

        MoveForward.text = keys["Move Forward"].ToString();
        MoveBack.text = keys["Move Back"].ToString();
        Jump.text = keys["Jump"].ToString();
        PickUp.text = keys["Pick Up"].ToString();
        Glow.text = keys["Glow"].ToString();
        EatAGlob.text = keys["Eat a Glob"].ToString();
        DropWeapon.text = keys["Drop Weapon"].ToString();
        UseKey.text = keys["Use Key"].ToString();

    }
    private void OnGUI()
    {
        if (currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = e.keyCode.ToString();
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
            }
        }
    }
    public void ChangeKey(GameObject clicked)
    {
        if (currentKey != null)
        {
            currentKey.GetComponent<Image>().color = normal;
        }
        currentKey = clicked;
        currentKey.GetComponent<Image>().color = selected;
    }

    public void SaveKeys()
    {
        foreach(var key in keys)
        {
            PlayerPrefs.SetString(key.Key,key.Value.ToString());
        }

        PlayerPrefs.Save();
    }
}
