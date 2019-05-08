using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Messenger2.Data
{
    class FirebaseDatabase : IDataStore
    {
        IDataStore db;

        public FirebaseDatabase() =>
            db = DependencyService.Get<IDataStore>();

        public async Task DeleteNodeAsync(string path) =>
            await db.DeleteNodeAsync(path);

        public IObservable<T> GetNodeAsync<T>(string path) where T : DataNode =>
            db.GetNodeAsync<T>(path);

        public async Task PutNodeAsync<T>(T node, string path) where T : DataNode =>
            await db.PutNodeAsync(node, path);

        public async Task UpdateAsync<T>(T node, string path) where T : DataNode =>
            await db.UpdateAsync(node, path);
    }
}
