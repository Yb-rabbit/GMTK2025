// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/02 23:09
// @version: 1.0
// @description:
// *****************************************************************************

using QFramework;
using UnityEngine;
using UnityEngine.UI;

namespace Yumihoshi.UI
{
    public class PauseAudioSlider : MonoBehaviour
    {
        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _slider.value = ES3.Load("AudioVolume", 1f);
            if (Mathf.Approximately(_slider.value, 1f))
                ES3.Save("AudioVolume", 1f);
        }

        private void Start()
        {
            _slider.onValueChanged.AddListener(OnVolumeChanged);
        }

        private void OnVolumeChanged(float value)
        {
            AudioKit.Settings.MusicVolume.Value = value;
            ES3.Save("AudioVolume", value);
        }
    }
}
