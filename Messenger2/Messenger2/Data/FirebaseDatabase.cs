using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Streaming;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Threading.Tasks;

namespace Messenger2.Data
{
    class FirebaseDatabase : IDataStore
    {
        FirebaseClient fbDatabase;

        public FirebaseDatabase() =>
            fbDatabase = new FirebaseClient("https://blahblah");

        public async Task DeleteNodeAsync(string path) =>
            await fbDatabase.Child(path)
                            .DeleteAsync();

        public IObservable<T> GetNodeAsync<T>(string path) where T : DataNode =>
           fbDatabase.Child(path)
                     .AsObservable<T>();


        public async Task PutNodeAsync<T>(T node, string path) where T : DataNode =>
            await fbDatabase.Child(path)
                            .PutAsync<T>(node);

        public async Task UpdateAsync<T>(T node, string path) where T : DataNode =>
            await fbDatabase.Child(path)
                            .PatchAsync<T>(node);
    }
}
