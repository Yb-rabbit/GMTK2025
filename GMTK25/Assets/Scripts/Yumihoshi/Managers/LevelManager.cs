// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/02 00:35
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using System.Collections.Generic;
using QFramework;
using UnityEngine;
using Yumihoshi.SO.Level;
using Random = UnityEngine.Random;

namespace Yumihoshi.Managers
{
    public class LevelManager : HoshiVerseFramework.Base.Singleton<LevelManager>
    {
        private readonly List<List<string>> _usedItemIds = new();
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
            for (int i = 0; i < LevelTreasureList.ConfigList.Count; i++)
                _usedItemIds.Add(new List<string>());
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            // 清理资源加载器
            if (_resLoader == null) return;
            _resLoader.Recycle2Cache();
            _resLoader = null;
        }

        public void Reset()
        {
            foreach (List<string> usedItemId in _usedItemIds)
            {
                usedItemId.Clear();
            }
        }

        /// <summary>
        /// 下一关
        /// </summary>
        [Obsolete]
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
        public string GetRandomLevelItemId(int levelIndex)
        {
            if (LevelTreasureList.ConfigList[levelIndex - 1].Config.Count ==
                _usedItemIds[levelIndex - 1].Count)
            {
                Debug.LogWarning("当前关卡物品已全部使用，无法获取新的物品ID");
                return "";
            }

            while (true)
            {
                string id = LevelTreasureList.ConfigList[levelIndex - 1].Config[
                    Random.Range(0,
                        LevelTreasureList.ConfigList[levelIndex - 1].Config
                            .Count)];
                if (_usedItemIds[levelIndex - 1].Contains(id) &&
                    ItemManager.Instance.FindItemById(id).ItemType ==
                    ItemCategory.Weapon) continue;
                _usedItemIds[levelIndex - 1].Add(id);
                return id;
            }
        }
    }
}
