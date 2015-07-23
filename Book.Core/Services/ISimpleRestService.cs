using System;

namespace Books.Core.Services
{
    public interface ISimpleRestService
    {
        void MakeRequest<T>(string requestUrl, string verb, Action<T> successAction, Action<Exception> errorAction);

        void MakeRequest2<T>(string requestUrl, string verb, Action<T> successAction, Action<Exception> errorAction);
    }
}