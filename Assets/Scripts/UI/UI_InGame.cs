using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_InGame : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private PlayerStats playerStats;

    [SerializeField] private Image dashImage;
    [SerializeField] private Image parryImage;
    [SerializeField] private Image crystalImage;
    [SerializeField] private Image swordImage;
    [SerializeField] private Image blackholeImage;
    [SerializeField] private Image flaskImage;

    [SerializeField] private TextMeshProUGUI currentSouls;
    private SkillManager skills;

    void Start()
    {
        if (playerStats != null)
            playerStats.onHealthChanged += UpdateHealthUI;

        skills = SkillManager.instance;
    }

    private void Update()
    {
        currentSouls.text = PlayerManager.instance.GetCurrency().ToString("#,#");

        if (Input.GetKeyDown(KeyCode.LeftShift) && skills.dash.dashUnlocked)
            SetCooldownOf(dashImage);

        if (Input.GetKeyDown(KeyCode.Q) && skills.parry.parryUnlocked)
            SetCooldownOf(parryImage);

        if (Input.GetKeyDown(KeyCode.X) && skills.crystal.crystalUnlocked)
            SetCooldownOf(crystalImage);

        if (Input.GetKeyDown(KeyCode.Mouse1) && skills.sword.swordUnlocked)
            SetCooldownOf(swordImage);

        if (Input.GetKeyDown(KeyCode.R) && skills.blackhole.blackholeUnlocked)
            SetCooldownOf(blackholeImage);

        if (Input.GetKeyDown(KeyCode.Alpha1) && Inventory.instance.GetEquipment(EquipmentType.Flask) != null)
            SetCooldownOf(flaskImage);

        CheckCoolDownOf(dashImage, skills.dash.coolDown, skills.dash.dashUnlocked);
        CheckCoolDownOf(parryImage, skills.parry.coolDown, skills.parry.parryUnlocked);
        CheckCoolDownOf(crystalImage, skills.crystal.coolDown, skills.crystal.crystalUnlocked);
        CheckCoolDownOf(swordImage, skills.sword.coolDown, skills.sword.swordUnlocked);
        CheckCoolDownOf(blackholeImage, skills.blackhole.coolDown, skills.blackhole.blackholeUnlocked);
        CheckCoolDownOf(flaskImage, Inventory.instance.flaskCooldown, Inventory.instance.GetEquipment(EquipmentType.Flask) != null);
    }

    private void UpdateHealthUI()
    {
        slider.maxValue = playerStats.GetMaxHealthValue();
        slider.value = playerStats.currentHealth;
    }

    private void SetCooldownOf(Image _image)
    {
        if (_image.fillAmount <= 0)
            _image.fillAmount = 1;
    }

    private void CheckCoolDownOf(Image _image, float _cooldown, bool isUnlocked)
    {
        if(isUnlocked == false)
        {
            _image.fillAmount = 1;
            return;
        }

        if (_image.fillAmount > 0)
            _image.fillAmount -= Time.deltaTime / _cooldown;
    }


}
