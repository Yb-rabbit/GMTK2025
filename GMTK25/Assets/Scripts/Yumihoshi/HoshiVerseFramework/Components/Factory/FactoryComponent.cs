// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/04/08 19:04
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections.Generic;
using System.Linq;
using HoshiVerseFramework.Configs;
using HoshiVerseFramework.Interfaces;
using UnityEngine;

namespace HoshiVerseFramework.Components.Factory
{
    /// <summary>
    /// 工厂组件，用于创建特效对象，注意非Unity挂载组件，在Monobehaviour中实例化该类以使用
    /// </summary>
    public class FactoryComponent
    {
        private readonly Dictionary<VFXType, ObjectPoolHandler> _poolDict =
            new();

        public FactoryComponent(VFXPoolConfigList configList)
        {
            // 初始化对象池处理器
            foreach (VFXPoolConfig config in
                     configList.configList.Where(config => !_poolDict.TryAdd(
                         config.vfxType,
                         new ObjectPoolHandler(config))))
                Debug.LogWarning(
                    $"[VFX] 特效工厂组件：添加对象池失败，已有相同类型{config.vfxType.ToString()}的对象池");
        }

        /// <summary>
        /// 创建特效对象，注意创建后需调用Play播放
        /// </summary>
        /// <param name="type">特效类型</param>
        /// <param name="pos">初始位置</param>
        /// <param name="rot">初始旋转</param>
        /// <returns></returns>
        public IVFX CreateVFX(VFXType type, Vector3 pos, Quaternion rot)
        {
            if (_poolDict.TryGetValue(type, out ObjectPoolHandler pool))
                return pool.Spawn(pos, rot).GetComponent<IVFX>();

            Debug.LogError($"[VFX] 特效工厂组件：获取对象池失败，找不到{type.ToString()}");
            return null;
        }

        /// <summary>
        /// <para>创建特效对象，默认V3.Zero，Quaternion.identity</para>
        /// <para>注意：创建后需调用Play播放</para>
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IVFX CreateVFX(VFXType type)
        {
            if (_poolDict.TryGetValue(type, out ObjectPoolHandler pool))
                return pool.Spawn(Vector3.zero, Quaternion.identity)
                    .GetComponent<IVFX>();

            Debug.LogError($"[VFX] 特效工厂组件：获取对象池失败，找不到{type.ToString()}");
            return null;
        }
    }
}
