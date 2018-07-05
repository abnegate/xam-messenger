using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Messenger2.Data
{
    class FirebaseImageStore : IImageStore
    {
        public async Task DeleteImageAsync(string path)
        {
            throw new NotImplementedException();
        }

        public async Task<Stream> GetImageAsync(string path)
        {
            throw new NotImplementedException();
        }

        public async Task PutImageAsync(Stream image, string path)
        {
            throw new NotImplementedException();
        }
    }
}
