using BalancedScorecard.Domain.Model.Indicators.Values;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace BalancedScorecard.Infrastructure.SqlServerDb.JsonConverters
{
    public class IndicatorMeasureConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IIndicatorValue);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {

            var jObject = JObject.Load(reader);
            var singleValue = jObject["value"];
            if (singleValue != null)
            {
                return ReturnSingleValue(singleValue);
            }

            var lowerValue = jObject["lowerValue"];
            var higherValue = jObject["higherValue"];
            if (lowerValue != null && higherValue != null)
            {
                return ReturnDoubleValue(lowerValue, higherValue);
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

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
        }
    }
}
