using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class UI_ItemToolTip : UI_ToolTip
{
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemTypeText;
    [SerializeField] private TextMeshProUGUI itemDescription;

    public void ShowTooltip(ItemData_Equipment _item)
    {
        if (_item == null)
            return;

        itemNameText.text = _item.itemName;
        itemTypeText.text = _item.equipmentType.ToString();
        itemDescription.text = _item.GetDescription();

        AdjustPosition();

        gameObject.SetActive(true);
    }

    public void HideTooltip() => gameObject.SetActive(false);
}
