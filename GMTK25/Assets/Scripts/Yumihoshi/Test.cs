// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 15:39
// @version: 1.0
// @description:
// *****************************************************************************

using UnityEngine;

namespace Yumihoshi
{
    public class Test : MonoBehaviour
    {
        private void Start()
        {
            ES3.Save("TestInt", 12345);
        }
    }
}
