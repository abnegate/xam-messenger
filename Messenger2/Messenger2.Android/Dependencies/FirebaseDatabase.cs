using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Messenger2.Data;
using Messenger2.Droid.Dependencies;
using Xamarin.Forms;

[assembly: Dependency(typeof(FirebaseDatabase))]
namespace Messenger2.Droid.Dependencies
{
    public class FirebaseDatabase : IDataStore
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