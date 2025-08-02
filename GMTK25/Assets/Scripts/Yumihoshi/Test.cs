// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 15:39
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections;
using UnityEngine;
using Yumihoshi.Entities;

namespace Yumihoshi
{
    public class Test : MonoBehaviour
    {
        public Treasure TreasureTest;

        private void Start()
        {
            //Debug.Log(TreasureTest.PickUpTreasure().itemDesc);
            StartCoroutine(Testt());
        }

        private IEnumerator Testt()
        {
            yield return new WaitForSeconds(3f);
        }
    }
}
