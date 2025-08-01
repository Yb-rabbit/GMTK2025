// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 14:00
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Yumihoshi.SO.Item.Consumable
{
    [CreateAssetMenu(fileName = "NewConsumableDataList",
        menuName = "物品/新建补给类配置列表", order = 2)]
    public class ConsumableSo : ScriptableObject
    {
        [LabelText("补给类配置列表")]
        public List<ConsumableData> ConsumableDataList;
    }
}
