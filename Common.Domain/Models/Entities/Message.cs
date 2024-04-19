using Newtonsoft.Json;

namespace Common.Domain.Models.Entities
{
    public class Message
    {
        private string _serializedData;

        public Message(object data)
        {
            this.Data = data;
        }

        public int Id { get; }

        public Type? Type { get; private set; }

        public bool Published { get; private set; }

        public DateTime Timestamp { get; }

        public void MarkAsPublished() => this.Published = true;

        public object? Data 
        {
            get => JsonConvert.DeserializeObject(
                this._serializedData,
                this.Type,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

            set
            {
                this.Type = value?.GetType();
                this._serializedData = JsonConvert.SerializeObject(
                    value,
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });
            }
        }
    }
}
