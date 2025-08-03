// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/03 15:59
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using QFramework;
using UnityEngine;
using UnityEngine.UI;

namespace Yumihoshi.UI
{
    public class HealthBar : MonoBehaviour
    {
        private Slider _healthBar;
        private hp _hp;

        private void Start()
        {
            _healthBar = GetComponent<Slider>();
            _hp = GameObject.Find("cat").GetComponent<hp>();
            _hp.HP.Register(HandleHpChanged)
                .UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private void HandleHpChanged(float newHp)
        {
            _healthBar.value = newHp;
        }
    }
}
