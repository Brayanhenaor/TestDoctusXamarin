using System;
using System.Collections.Generic;

namespace DoctusTest.Services
{
    public interface INavigationParameters
    {
        INavigationParameters Add(string key, object value);
        T GetValue<T>(string key);
    }
}
