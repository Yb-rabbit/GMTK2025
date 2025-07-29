// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/03 19:03
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using System.Collections.Generic;
using HoshiVerseFramework.Base;

namespace HoshiVerseFramework.Singletons
{
    public class EventCenterManager : Singleton<EventCenterManager>
    {
        private readonly Dictionary<Type, Delegate> _eventHandlers = new();

        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }

        /// <summary>
        /// 订阅事件
        /// </summary>
        /// <param name="handler"></param>
        /// <typeparam name="T"></typeparam>
        public void AddListener<T>(Action<T> handler)
        {
            Type type = typeof(T);
            if (!_eventHandlers.TryAdd(type, handler))
                _eventHandlers[type] =
                    Delegate.Combine(_eventHandlers[type], handler);
        }


        /// <summary>
        /// 触发事件
        /// </summary>
        /// <param name="eventData"></param>
        /// <typeparam name="T"></typeparam>
        public void TriggerEvent<T>(T eventData)
        {
            Type type = typeof(T);
            if (_eventHandlers.TryGetValue(type, out Delegate handler))
                (handler as Action<T>)?.Invoke(eventData);
        }

        /// <summary>
        /// 取消订阅事件
        /// </summary>
        /// <param name="handler"></param>
        /// <typeparam name="T"></typeparam>
        public void RemoveListener<T>(Action<T> handler)
        {
            Type type = typeof(T);
            if (!_eventHandlers.TryGetValue(type, out Delegate existing))
                return;
            Delegate newDelegate = Delegate.Remove(existing, handler);
            if (newDelegate != null)
                _eventHandlers[type] = newDelegate;
            else
                _eventHandlers.Remove(type);
        }

        /// <summary>
        /// 取消某个类型的所有订阅
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void RemoveCustomAllListeners<T>()
        {
            Type type = typeof(T);
            if (_eventHandlers.ContainsKey(type))
                _eventHandlers.Remove(type);
        }

        /// <summary>
        /// 取消所有类型的所有订阅
        /// </summary>
        public void RemoveAllListeners()
        {
            _eventHandlers.Clear();
        }
    }
}
