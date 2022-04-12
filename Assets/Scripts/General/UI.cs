using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    // Referência ao texto que representa a vida
    [SerializeField]
    private TextMeshProUGUI healthText = default;

    [SerializeField]
    private TextMeshProUGUI staminaText = default;

    [SerializeField]
    private TextMeshProUGUI legendaText = default;

    [SerializeField]
    private TextMeshProUGUI legenda3DText = default;

    [SerializeField]
    private Image interactionNote;

    [SerializeField]
    private GameObject inventory;

    [SerializeField]
    private GameObject playerUI;

    public Text[] inventoryItems;

    [SerializeField]
    private Text collectText;

    [SerializeField]
    private bool inventoryActivated = false;

    public static UI instaceUI;

    private void Awake()
    {
        instaceUI = this;
    }

    private void OnEnable()
    {
        FirstPersonController.OnDamage += UpdateHealth;
        FirstPersonController.OnHeal += UpdateHealth;
        FirstPersonController.OnStaminaChange += UpdateStamina;
    }

    private void OnDisable()
    {
        FirstPersonController.OnDamage -= UpdateHealth;
        FirstPersonController.OnHeal += UpdateHealth;
        FirstPersonController.OnStaminaChange -= UpdateStamina;
    }

    private void Start()
    {
        UpdateHealth(100);
        UpdateStamina(100);
    }

    private void UpdateHealth(float currentHealth)
    {
        healthText.text = currentHealth.ToString("00");
    }

    private void UpdateStamina(float currentStamina)
    {
        staminaText.text = currentStamina.ToString("00");
    }

    public void SetCaptions(string text)
    {
        legendaText.text = text;
    }

    public void Set3DCaptions(string text)
    {
        legenda3DText.text = text;
    }

    public void SetBackImage(bool state)
    {
        if (!state)
        {
            interactionNote.enabled = state;
        }
    }

    public void SetImage(Sprite sprite)
    {
        interactionNote.sprite = sprite;
        interactionNote.enabled = true;
    }

    public void SetItems(Item item, int index)
    {
        inventoryItems[index].text = item.collectMessage;
        collectText.text = item.collectMessage + " foi coletado";
        StartCoroutine(FadingText());
    }

    public void UseItems(Item item, int index)
    {
        inventoryItems[index].text = "Used " + item.collectMessage;
        collectText.text = item.collectMessage + " foi coletado";
        StartCoroutine(FadingText());
    }

    IEnumerator FadingText()
    {
        Color newColor = collectText.color;

        while (newColor.a < 1)
        {
            newColor.a += Time.deltaTime;
            collectText.color = newColor;
            yield return null;
        }

        yield return new WaitForSeconds(2f);

        while (newColor.a > 0)
        {
            newColor.a -= Time.deltaTime;
            collectText.color = newColor;
            yield return null;
        }
    }

    public void ActivateInventory()
    {
        playerUI.SetActive (inventoryActivated);
        inventory.SetActive(!inventoryActivated);
        inventoryActivated = !inventoryActivated;
    }
}
