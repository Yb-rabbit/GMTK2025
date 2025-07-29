// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/04/08 19:04
// @version: 1.0
// @description:
// *****************************************************************************

using HoshiVerseFramework.Base.VFX;
using HoshiVerseFramework.Configs;
using UnityEngine;
using UnityEngine.Pool;

namespace HoshiVerseFramework.Components.Factory
{
    /// <summary>
    /// 单个对象池处理器
    /// </summary>
    public class ObjectPoolHandler
    {
        private readonly VFXPoolConfig _config;
        private readonly ObjectPool<GameObject> _pool;

        public ObjectPoolHandler(VFXPoolConfig config)
        {
            _config = config;
            _pool = new ObjectPool<GameObject>(Create, Get, ReleaseObj, Destroy,
                _config.collectionChecks, _config.defaultCapacity,
                _config.maxCapacity);
        }

        private GameObject Create()
        {
            GameObject goVfx = Object.Instantiate(_config.prefab);
            var entity = goVfx.GetComponent<VFXBaseEntityWithPool>();
            if (entity)
                entity.SetPool(_pool);
            else
                Debug.LogWarning("[VFX] 对象池生成特效实体时，无法设置实体所属的对象池");
            return goVfx;
        }

        private void Get(GameObject obj)
        {
            obj.SetActive(true);
        }

        private void ReleaseObj(GameObject obj)
        {
            obj.SetActive(false);
        }

        private void Destroy(GameObject obj)
        {
            Object.Destroy(obj);
        }

        /// <summary>
        /// 生成特效物体
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="rot"></param>
        /// <returns></returns>
        public GameObject Spawn(Vector3 pos, Quaternion rot)
        {
            GameObject vfx = _pool.Get();
            vfx.transform.position = pos;
            vfx.transform.rotation = rot;
            return vfx;
        }
    }
}
