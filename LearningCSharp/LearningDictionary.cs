using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Collections.ObjectModel;

namespace LearningCSharp
{
    internal class LearningDictionary
    {
        public void TryDictionary()
        {

            var dictionary  = new Dictionary<string, string>();
            dictionary["name"] = "Nick";
            var name = dictionary["name"];

            

            //Thread safety
            var concurrentDictionary = new ConcurrentDictionary<string, string>();
            concurrentDictionary["name"] = "Raj";
            var newName = concurrentDictionary["name"];


            var immutableDictionary = dictionary.ToImmutableDictionary();

            var imute = ImmutableDictionary<string,string>.Empty;


            _ = new ReadOnlyDictionary<string, string>(immutableDictionary);


        }
    }
}
