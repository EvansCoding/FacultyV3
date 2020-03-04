namespace FacultyV3.Core.Interfaces.IServices
{
    using Models.Enums;
    using System.Collections.Generic;

    public interface ICacheService
    {
        T Get<T>(string key);
        void Set(string key, object data, CacheTimes minutesToCache);
        bool IsSet(string key);
        void Invalidate(string key);
        void Clear();
        void ClearStartsWith(string keyStartsWith);
        void ClearStartsWith(List<string> keysStartsWith);
    }
}
