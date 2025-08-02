// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/02 22:46
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections.Generic;
using QFramework;
using UnityEngine;

namespace Yumihoshi.Managers
{
    public class AudioManager : HoshiVerseFramework.Base.Singleton<AudioManager>
    {
        private ResLoader _resLoader = ResLoader.Allocate();
        private readonly List<AudioClip> _bgmClips = new();

        private void Start()
        {
            _bgmClips.Add(_resLoader.LoadSync<AudioClip>("bgm1fi"));
            PlayLevelMusic();
        }

        /// <summary>
        /// 播放关卡bgm
        /// </summary>
        /// <param name="index"></param>
        public void PlayLevelMusic(int index = 0)
        {
            AudioKit.PlayMusic(_bgmClips[index]);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            if (_resLoader == null) return;
            _resLoader.Recycle2Cache();
            _resLoader = null;
        }
    }
}
