using System;
using System.IO;
using System.Threading.Tasks;

namespace Messenger2.Data
{
    public interface IDataStore
    {
        IObservable<T> GetNodeAsync<T>(string path) where T : DataNode;
        Task PutNodeAsync<T>(T node, string path) where T : DataNode;
        Task UpdateAsync<T>(T node, string path) where T : DataNode;
        Task DeleteNodeAsync(string path);
    }

    public interface IImageStore
    {
        Task<Stream> GetImageAsync(string path);
        Task PutImageAsync(Stream image, string path);
        Task DeleteImageAsync(string path);
    }

    public interface IUserAuth
    {
        Task<IObservable<User>> SignUpWithEmail(string email, string password);
        Task<IObservable<User>> LoginWithEmail(string email, string password);
        Task<IObservable<User>> LoginWithFacebook();
    }
}
