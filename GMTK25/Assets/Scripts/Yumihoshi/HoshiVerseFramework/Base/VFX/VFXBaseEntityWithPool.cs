// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/04/08 19:04
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace HoshiVerseFramework.Base.VFX
{
    /// <summary>
    /// 带有对象池的特效实体基类
    /// </summary>
    public class VFXBaseEntityWithPool : MonoBehaviour
    {
        protected ObjectPool<GameObject> pool;
        protected bool poolSetStatus;

        public void SetPool(ObjectPool<GameObject> vfxPool)
        {
            if (poolSetStatus)
            {
                Debug.LogWarning("[VFX] VFXPool已经设置过了，不能重复设置");
                return;
            }

            pool = vfxPool;
            poolSetStatus = true;
        }

        public void ExecuteDelay(float lifeTime, Action onExecute = null)
        {
            StartCoroutine(ExecuteAfterDelay(lifeTime, onExecute));
        }

        /// <summary>
        /// 自动销毁特效物体
        /// </summary>
        /// <returns></returns>
        private IEnumerator ExecuteAfterDelay(float lifeTime,
            Action onExecute = null)
        {
            yield return new WaitForSeconds(lifeTime);
            onExecute?.Invoke();
        }
    }
}
