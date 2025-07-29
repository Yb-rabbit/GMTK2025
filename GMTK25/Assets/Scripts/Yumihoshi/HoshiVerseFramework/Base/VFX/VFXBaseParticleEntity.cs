// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/04/08 20:04
// @version: 1.0
// @description:
// *****************************************************************************

using HoshiVerseFramework.Interfaces;
using UnityEngine;

namespace HoshiVerseFramework.Base.VFX
{
    /// <summary>
    /// 带有对象池的粒子特效实体基类
    /// </summary>
    public class VFXBaseParticleEntity : VFXBaseEntityWithPool, IVFX
    {
        protected ParticleSystem particle;

        protected virtual void Awake()
        {
            particle = GetComponent<ParticleSystem>();
            Stop();
        }

        /// <summary>
        /// 播放粒子特效
        /// </summary>
        /// <param name="autoRelease">是否自动回收</param>
        /// <param name="lifeTime">特效自动回收时间</param>
        public virtual void Play(bool autoRelease = true, float lifeTime = 10f)
        {
            ParticleSystem.MainModule main = particle.main;
            main.simulationSpeed = 1;
            particle.Play();
            if (autoRelease)
                ExecuteDelay(lifeTime, Release);
        }

        /// <summary>
        /// 在playTime时间内播放完特效，重映射播放速率
        /// </summary>
        /// <param name="playTime"></param>
        /// <param name="autoRelease"></param>
        /// <param name="lifeTime"></param>
        public void Play(float playTime, bool autoRelease = true,
            float lifeTime = 10f)
        {
            ParticleSystem.MainModule main = particle.main;
            main.simulationSpeed = main.duration / playTime;
            particle.Play();
            if (autoRelease)
                ExecuteDelay(lifeTime, Release);
        }

        /// <summary>
        /// 播放特效，并设置播放速率
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="autoRelease"></param>
        /// <param name="lifeTime"></param>
        public void PlayWithSpeed(float speed = 1, bool autoRelease = true,
            float lifeTime = 10f)
        {
            ParticleSystem.MainModule main = particle.main;
            main.simulationSpeed = speed;
            particle.Play();
            if (autoRelease)
                ExecuteDelay(lifeTime, Release);
        }

        /// <summary>
        /// 暂停粒子特效
        /// </summary>
        public virtual void Pause()
        {
            particle.Pause();
        }

        /// <summary>
        /// 停止粒子特效
        /// </summary>
        public virtual void Stop()
        {
            particle.Stop();
        }

        /// <summary>
        /// 恢复粒子特效
        /// </summary>
        public virtual void Resume()
        {
            particle.Play();
        }

        /// <summary>
        /// 释放粒子特效
        /// </summary>
        public virtual void Release()
        {
            pool.Release(gameObject);
        }

        /// <summary>
        /// 设置粒子特效是否循环
        /// </summary>
        /// <param name="loop"></param>
        public virtual void SetLoop(bool loop = true)
        {
            ParticleSystem.MainModule module = particle.main;
            module.loop = loop;
        }
    }
}
