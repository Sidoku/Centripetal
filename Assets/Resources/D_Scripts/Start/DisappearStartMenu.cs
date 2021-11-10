using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class DisappearStartMenu : MonoBehaviour
{
    public GameObject c_Machine;
    // public GameObject Collider;
    public GameObject Apple;
    public GameObject Banana;
    public GameObject Coin;
    [SerializeField] 
    private Text[] Texts = new Text[2];
    [SerializeField]
    private Button[] Buttons = new Button[3];
    [SerializeField]
    private Image[] Images = new Image[4];
    private bool isPlayer;

    private Collider2D _collider2D;
    // Start is called before the first frame update
    void Start()
    {
        c_Machine.SetActive(false);
        // GameObject go = GameObject.Find("Canvas");
        // Texts[0] = go.transform.Find("StartMenu/Title").GetComponent<Text>();
        // Texts[1] = go.transform.Find("StartMenu/Press Notification").GetComponent<Text>();
        // Buttons[0] = go.transform.Find("StartMenu/StartButton").GetComponent<Button>();
        // Buttons[1] = go.transform.Find("StartMenu/SettingButton").GetComponent<Button>();
        // Buttons[2] = go.transform.Find("StartMenu/ShopButton").GetComponent<Button>();
        // Images[0] = go.transform.Find("StartMenu/A").GetComponent<Image>();
        // Images[1] = go.transform.Find("StartMenu/D").GetComponent<Image>();
        // Images[2] = go.transform.Find("StartMenu/Space/Spa").GetComponent<Image>();
        // Images[3] = go.transform.Find("StartMenu/Space/ce").GetComponent<Image>();
        Texts[0] = GameObject.Find("StartMenu/Title").GetComponent<Text>();
        Texts[1] = GameObject.Find("StartMenu/Press Notification").GetComponent<Text>();
        // Buttons[0] = GameObject.Find("StartMenu/StartButton").GetComponent<Button>();
        // Buttons[1] = GameObject.Find("StartMenu/SettingButton").GetComponent<Button>();
        // Buttons[2] = GameObject.Find("StartMenu/ShopButton").GetComponent<Button>();
        Images[0] = GameObject.Find("StartMenu/A").GetComponent<Image>();
        Images[1] = GameObject.Find("StartMenu/D").GetComponent<Image>();
        Images[2] = GameObject.Find("StartMenu/Space/Spa").GetComponent<Image>();
        Images[3] = GameObject.Find("StartMenu/Space/ce").GetComponent<Image>();
        // Collider = GameObject.Find("ThreeButtons");
        Apple = GameObject.Find("StartMenu/Apple");
        Banana = GameObject.Find("StartMenu/Banana");
        Coin = GameObject.Find("StartMenu/Coin");
        _collider2D = GetComponent<Collider2D>();
        
        Apple.SetActive(false);
        Banana.SetActive(false);
        Coin.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    #region private methods

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayer = true;
            c_Machine.SetActive(true);
            DisappearStartMenus();
            // throw new NotImplementedException();
            CheckLists.Instance.destinationPoint = transform.position;
            Apple.SetActive(true);
            Banana.SetActive(true);
            Coin.SetActive(true);
        }
    }

    #endregion

    #region public methods

    private void DisappearStartMenus()
    {
        foreach (var text in Texts)
        {
            text.DOFade(0, 1f);
        }

        foreach (var image in Images)
        {
            image.DOFade(0, 1f).OnComplete(() =>
            {
                // Collider.SetActive(false);
            });
        }
        
        // foreach (var button in Buttons)
        // {
        //     button.transform.localScale = new Vector3(0, 0, 0);
        // }

        _collider2D.enabled = false;
    }

    #endregion
    
    
}
