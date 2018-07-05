using System;
using System.Threading.Tasks;
using Messenger2.Data;
using Messenger2.iOS.Dependencies;
using Xamarin.Forms;

[assembly: Dependency(typeof(FirebaseDatabase))]
namespace Messenger2.iOS.Dependencies
{
    class FirebaseDatabase : IDataStore
    {
        public Task DeleteNodeAsync(string path)
        {
            throw new NotImplementedException();
        }

        public Task<IObservable<T>> GetNodeAsync<T>(string path) where T : DataNode
        {
            throw new NotImplementedException();
        }

        public Task<T> PutNodeAsync<T>(T node, string path) where T : DataNode
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync<T>(T node, string path) where T : DataNode
        {
            throw new NotImplementedException();
        }
    }
}