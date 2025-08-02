// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/02 00:35
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections.Generic;
using QFramework;
using UnityEngine;
using Yumihoshi.SO.Level;

namespace Yumihoshi.Managers
{
    public class LevelManager : HoshiVerseFramework.Base.Singleton<LevelManager>
    {
        private readonly List<string> _usedItemIds = new();
        private LevelTreasureConfig _curLevelConfig;

        private ResLoader _resLoader = ResLoader.Allocate();

        /// <summary>
        /// 关卡物品库配表
        /// </summary>
        public LevelTreasureConfigList LevelTreasureList { get; private set; }

        /// <summary>
        /// 当前关卡索引
        /// </summary>
        public int CurrentLevelIndex { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            // 初始化关卡物品库配表
            LevelTreasureList =
                _resLoader.LoadSync<LevelTreasureConfigList>(
                    "leveltreasureconfiglist");
            _curLevelConfig = LevelTreasureList.ConfigList[0];
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            // 清理资源加载器
            if (_resLoader == null) return;
            _resLoader.Recycle2Cache();
            _resLoader = null;
        }

        /// <summary>
        /// 下一关
        /// </summary>
        public void LoadNextLevel()
        {
            CurrentLevelIndex = Mathf.Clamp(CurrentLevelIndex + 1, 0,
                LevelTreasureList.ConfigList.Count - 1);
            _curLevelConfig = LevelTreasureList.ConfigList[CurrentLevelIndex];
            _usedItemIds.Clear();
        }

        /// <summary>
        /// 获取当前关卡的随机物品ID
        /// </summary>
        /// <returns></returns>
        public string GetRandomCurLevelItemId()
        {
            if (_curLevelConfig.Config.Count == _usedItemIds.Count)
            {
                Debug.LogWarning("当前关卡物品已全部使用，无法获取新的物品ID");
                return "";
            }

            while (true)
            {
                string id = _curLevelConfig.Config[
                    Random.Range(0, _curLevelConfig.Config.Count)];
                if (_usedItemIds.Contains(id)) continue;
                _usedItemIds.Add(id);
                return id;
            }
        }
    }
}
