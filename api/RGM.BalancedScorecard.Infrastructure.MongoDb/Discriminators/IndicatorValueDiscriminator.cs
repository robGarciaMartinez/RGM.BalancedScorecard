using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization.Conventions;
using RGM.BalancedScorecard.Domain.Model.Indicators.Values;
using System;
using System.Reflection;

namespace RGM.BalancedScorecard.Infrastructure.MongoDb.Discriminators
{
    public class IndicatorValueDiscriminator : IDiscriminatorConvention
    {
        public string ElementName
        {
            get { return "_t"; }
        }

        public Type GetActualType(IBsonReader bsonReader, Type nominalType)
        {
            if (nominalType != typeof(IIndicatorValue))
                throw new Exception("Cannot use IndicatorValueDiscriminator for type " + nominalType);

            var ret = nominalType;

            var bookmark = bsonReader.GetBookmark();
            bsonReader.ReadStartDocument();
            if (bsonReader.FindElement(ElementName))
            {
                var value = bsonReader.ReadString();
                ret = Type.GetType(value);

                if (ret == null)
                    throw new Exception("Could not find type " + value);

                if (!typeof(IIndicatorValue).IsAssignableFrom(ret))
                    throw new Exception("Database type does not inherit from IIndicatorValue.");
            }

            bsonReader.ReturnToBookmark(bookmark);
            return ret;
        }

        public BsonValue GetDiscriminator(Type nominalType, Type actualType)
        {
            if (!typeof(IIndicatorValue).IsAssignableFrom(actualType))
                throw new Exception("Cannot use IndicatorValueDiscriminator for type " + nominalType);

            return actualType.AssemblyQualifiedName;
        }
    }
}
