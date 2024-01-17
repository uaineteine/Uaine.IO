using Newtonsoft.Json;

namespace Uaine.IO
{
    public static class ArraySerialiser
    {
        // Serialize method to convert an array to a JSON string
        public static string[] SerializeToJson<T>(T[] items)
        {
            string[] serializedArray = new string[items.Length];

            for (int i = 0; i < items.Length; i++)
            {
                // Serialize each item individually
                serializedArray[i] = JsonConvert.SerializeObject(items[i]);
            }
            return serializedArray;
        }

        // Deserialize method to create an array from a JSON string
        public static T[] DeserializeFromJson<T>(string[] json)
        {
            T[] deserializedArray = new T[json.Length];

            for (int i = 0; i < deserializedArray.Length; i++)
            {
                // Deserialize each item individually
                deserializedArray[i] = JsonConvert.DeserializeObject<T>(json[i]);
            }
            return deserializedArray;
        }
    }
}
