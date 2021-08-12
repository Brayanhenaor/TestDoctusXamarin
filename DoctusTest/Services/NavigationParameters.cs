using System;
using System.Collections.Generic;

namespace DoctusTest.Services
{
    public class NavigationParameters : INavigationParameters
    {
        public Dictionary<string, object> parameters { private get; set; }

        public NavigationParameters() => parameters = new Dictionary<string, object>();

        public INavigationParameters Add(string key, object value)
        {
            parameters.Add(key, value);

            return this;
        }

        public T GetValue<T>(string key)
        {
            parameters.TryGetValue(key, out object value);

            if (value != null && value is T valueCast)
            {
                return valueCast;
            }

            return default;
        }
    }
}
