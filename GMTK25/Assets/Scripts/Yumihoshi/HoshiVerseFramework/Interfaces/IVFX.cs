// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/04/09 15:04
// @version: 1.0
// @description:
// *****************************************************************************

namespace HoshiVerseFramework.Interfaces
{
    public interface IVFX
    {
        /// <summary>
        /// 开始播放特效
        /// </summary>
        /// <param name="autoRelease"></param>
        /// <param name="lifeTime"></param>
        public void Play(bool autoRelease = true, float lifeTime = 10f);

        /// <summary>
        /// 在playTime时间内播放完特效，重映射播放速率
        /// </summary>
        /// <param name="playTime"></param>
        /// <param name="autoRelease"></param>
        /// <param name="lifeTime"></param>
        public void Play(float playTime, bool autoRelease = true,
            float lifeTime = 10f);

        /// <summary>
        /// 播放特效，并设置播放速率
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="autoRelease"></param>
        /// <param name="lifeTime"></param>
        public void PlayWithSpeed(float speed = 1f, bool autoRelease = true,
            float lifeTime = 10f);

        /// <summary>
        /// 暂停特效
        /// </summary>
        public void Pause();

        /// <summary>
        /// 停止特效，并将播放进度重置为0
        /// </summary>
        public void Stop();

        /// <summary>
        /// 重启特效，立即播放
        /// </summary>
        public void Restart()
        {
            Stop();
            Play();
        }

        /// <summary>
        /// 恢复特效播放（继续播放特效）
        /// </summary>
        public void Resume();

        /// <summary>
        /// 释放特效资源
        /// </summary>
        public void Release();

        /// <summary>
        /// 设置特效是否循环播放
        /// </summary>
        /// <param name="loop"></param>
        public void SetLoop(bool loop = true);
    }
}
