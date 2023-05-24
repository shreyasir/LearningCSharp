using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Singleton
{
    public class UploadService
    {
        private UploadService() { }
        private static UploadService? _instance;
        private static readonly object _lock= new object();
        public int Id { get; private set; }

        public static UploadService Instance(int id)
        {
            if (_instance == null)
            {
                lock (_lock)
                { 
                    _instance ??= new UploadService();
                    _instance.Id = id;
                }
            }
            return _instance;
        }

    }
}
