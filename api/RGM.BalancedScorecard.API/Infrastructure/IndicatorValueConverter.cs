namespace RGM.BalancedScorecard.API.Infrastructure
{
    using System;
    using System.Linq;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using Domain.Model.Indicators.Values;

    public class IndicatorValueConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IIndicatorValue);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            if (jObject.Properties().Any(p => p.Name.Equals("value")))
            {
                return this.ReturnSingleValue(jObject["value"]);
            }

            if (jObject.Properties().Any(p => p.Name.Equals("lowervalue")) && jObject.Properties().Any(p => p.Name.Equals("highervalue")))
            {
                return this.ReturnDoubleValue(jObject["lowervalue"], jObject["highervalue"]);
            }

            throw new ArgumentException("Indicator measure does not contain the expected values");
        }

        private object ReturnSingleValue(JToken singleValueToken)
        {
            switch (singleValueToken.Type)
            {
                case JTokenType.Integer:
                    return new SingleValue<int>(singleValueToken.Value<int>());
                case JTokenType.Float:
                    return new SingleValue<decimal>(singleValueToken.Value<decimal>());
                case JTokenType.Boolean:
                    return new SingleValue<bool>(singleValueToken.Value<bool>());
                default:
                    throw new ArgumentException("Indicator measure value is not of the expected type");
            }
        }

        private object ReturnDoubleValue(JToken lowerValueToken, JToken higherValueToken)
        {
            switch (lowerValueToken.Type)
            {
                case JTokenType.Integer:
                    return new DoubleValue<int>(lowerValueToken.Value<int>(), higherValueToken.Value<int>());
                case JTokenType.Float:
                    return new DoubleValue<decimal>(lowerValueToken.Value<decimal>(), higherValueToken.Value<decimal>());
                case JTokenType.Boolean:
                    return new DoubleValue<bool>(lowerValueToken.Value<bool>(), higherValueToken.Value<bool>());
                default:
                    throw new ArgumentException("Indicator measure value is not of the expected type");
            }
        }
    }
}
