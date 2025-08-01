// *****************************************************************************
// @author: Yumihoshi
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/08/01 20:03
// @version: 1.0
// @description:
// *****************************************************************************

using QFramework;

namespace Yumihoshi.Utility
{
    public class Storage : IUtility
    {
        public void Save<T>(string key, T value)
        {
            ES3.Save(key, value);
        }

        public T Load<T>(string key, T defaultValue = default)
        {
            return ES3.Load(key, defaultValue);
        }
    }
}
