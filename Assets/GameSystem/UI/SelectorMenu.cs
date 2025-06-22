using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectorMenu : MonoBehaviour
{
    private GameManager gameManagerScript;
    public GameObject gameManager;

    public GameObject GAMESTARTImage;
    public GameObject SETTINGImage;
    public bool SettingButtonNowFlag;
    public bool GameStartButtonNowFlag;
    private float SelectorMove = 12.0f;
    private float baseSpeed = 300.0f; // ”CˆÓ‚Ì‘¬“x
    public RectTransform SettingMENUImage;
    public RectTransform StartImage;
    public GameObject LuleBGmage;
    public GameObject LuleUiImage;
    public GameObject LTRTImage;
    public GameObject SpecImage;

    private bool isSeaneEffect = false;
    private bool shouldMove = false;

    void Start()
    {
        gameManagerScript = gameManager.GetComponent<GameManager>();

        LuleBGmage.SetActive(false);
        LuleUiImage.SetActive(false);
        SpecImage.SetActive(false);
    }

    void Update()
    {
        float tri = Input.GetAxis("L_R_Trigger");

        if (gameManagerScript.IsOpenSelector() && !gameManagerScript.IsGameStart())
        {
            if (SettingMENUImage.position.x >= 410.0f)
            {
                SelectorMove = baseSpeed * Time.fixedDeltaTime * -1f;
                shouldMove = false;

                StartImage.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 120);
                StartImage.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 120);

                if (!SettingButtonNowFlag && !isSeaneEffect)
                {
                    GameStartButtonNowFlag = true;
                    StartImage.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 120);
                    StartImage.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 120);
                    LuleBGmage.SetActive(true);
                    LuleUiImage.SetActive(true);
                    SpecImage.SetActive(false);

                    if (Input.GetKeyDown(KeyCode.S) || tri > 0)
                    {
                        GameStartButtonNowFlag = false;
                        SettingButtonNowFlag = true;
                    }
                    if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))
                    {
                        isSeaneEffect = true;
                        LuleBGmage.SetActive(false);
                        LuleUiImage.SetActive(false);
                        GAMESTARTImage.SetActive(false);
                        SETTINGImage.SetActive(false);
                    }
                }
                else
                {
                    StartImage.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 100);
                    StartImage.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 100);
                }

                if (SettingButtonNowFlag)
                {
                    SettingMENUImage.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 120);
                    SettingMENUImage.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 120);
                    LuleBGmage.SetActive(false);
                    LuleUiImage.SetActive(false);
                    SpecImage.SetActive(true);

                    if ((Input.GetKeyDown(KeyCode.W) || tri < 0) && !isSeaneEffect)
                    {
                        SettingButtonNowFlag = false;
                        GameStartButtonNowFlag = true;
                    }
                }
                else
                {
                    SettingMENUImage.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 100);
                    SettingMENUImage.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 100);
                }
            }
            else
            {
                shouldMove = true;
            }
        }
        else
        {
            isSeaneEffect = false;
            shouldMove = false;
        }
    }

    void FixedUpdate()
    {
        if (shouldMove)
        {
            Vector3 move = new Vector3(SelectorMove, 0, 0);
            SettingMENUImage.position += move;
            StartImage.position += move;
        }
    }

    public bool IsColorMenuFlag()
    {
        return SettingButtonNowFlag;
    }

    public bool IsStartButtonFlag()
    {
        return GameStartButtonNowFlag;
    }

    public bool IsSeaneEffectFlag()
    {
        return isSeaneEffect;
    }
}
