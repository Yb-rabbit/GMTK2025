// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/03 19:03
// @version: 1.0
// @description:
// *****************************************************************************

using HoshiVerseFramework.FSM.Interfaces;
using UnityEngine;

namespace HoshiVerseFramework.FSM
{
    /// <summary>
    /// 状态基类，使用时创建一个新状态脚本，继承自FsmState即可
    /// </summary>
    public abstract class FsmState : MonoBehaviour, IState
    {
        [SerializeField] protected string stateType;

        [SerializeField] protected bool isDefaultState;

        /// <summary>
        /// 状态类型
        /// </summary>
        public string StateType => stateType;

        public bool IsDefaultState => isDefaultState;

        public abstract bool OnCheck(StateContext context = null);
        public abstract void OnEnter(StateContext context = null);
        public abstract void OnUpdate();
        public abstract void OnFixedUpdate();
        public abstract void OnExit(StateContext context = null);
    }
}
