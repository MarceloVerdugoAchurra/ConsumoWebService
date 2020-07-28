// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var vehicles = Vehicles.FromJson(jsonString);

namespace QuickTypeV
{
    using System;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Vehicles
    {
        [JsonProperty("set")]
        public long Set { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("data")]
        public Datum[] Data { get; set; }

        [JsonProperty("page")]
        public long Page { get; set; }

        [JsonProperty("pages")]
        public long Pages { get; set; }
    }

    public partial class Datum
    {
        [JsonProperty("info")]
        public Info Info { get; set; }

        [JsonProperty("associations")]
        public Association[] Associations { get; set; }

        [JsonProperty("__updated")]
        public double Updated { get; set; }

        [JsonProperty("associated_at")]
        public double AssociatedAt { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("primary")]
        public long? Primary { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("device")]
        public long? Device { get; set; }

        [JsonProperty("token")]
        public object Token { get; set; }

        [JsonProperty("groups")]
        public long[] Groups { get; set; }

        [JsonProperty("images")]
        public Images Images { get; set; }

        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("properties")]
        public Properties Properties { get; set; }

        [JsonProperty("configuration", NullValueHandling = NullValueHandling.Ignore)]
        public string Configuration { get; set; }
    }

    public partial class Association
    {
        [JsonProperty("vehicle_id")]
        public long VehicleId { get; set; }

        [JsonProperty("device_id")]
        public long DeviceId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("association")]
        public bool AssociationAssociation { get; set; }

        [JsonProperty("time")]
        public double Time { get; set; }
    }

    public partial class Images
    {
        [JsonProperty("photo")]
        public bool Photo { get; set; }

        [JsonProperty("on_icon")]
        public bool OnIcon { get; set; }

        [JsonProperty("idle_icon")]
        public bool IdleIcon { get; set; }

        [JsonProperty("icon")]
        public bool Icon { get; set; }

        [JsonProperty("off_icon")]
        public bool OffIcon { get; set; }
    }

    public partial class Info
    {
        [JsonProperty("range_unit")]
        public RangeUnit? RangeUnit { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("tank_volume")]
        public long? TankVolume { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("make")]
        public string Make { get; set; }

        [JsonProperty("vin")]
        public string Vin { get; set; }

        [JsonProperty("license_plate")]
        public string LicensePlate { get; set; }

        [JsonProperty("alias")]
        public string Alias { get; set; }

        [JsonProperty("range")]
        public long? Range { get; set; }

        [JsonProperty("year")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Year { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("tank_unit")]
        public TankUnit? TankUnit { get; set; }
    }

    public partial class Properties
    {
        [JsonProperty("$range_hour", NullValueHandling = NullValueHandling.Ignore)]
        public long? RangeHour { get; set; }

        [JsonProperty("New properties", NullValueHandling = NullValueHandling.Ignore)]
        public long? NewProperties { get; set; }
    }

    public enum RangeUnit { Km, Mile };

    public enum TankUnit { Gallon, Liter };

    public enum TypeEnum { Vehicle };

    public partial class Vehicles
    {
        public static Vehicles FromJson(string json) => JsonConvert.DeserializeObject<Vehicles>(json, QuickTypeV.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Vehicles self) => JsonConvert.SerializeObject(self, QuickTypeV.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                RangeUnitConverter.Singleton,
                TankUnitConverter.Singleton,
                TypeEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class RangeUnitConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(RangeUnit) || t == typeof(RangeUnit?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "km":
                    return RangeUnit.Km;
                case "mile":
                    return RangeUnit.Mile;
            }
            throw new Exception("Cannot unmarshal type RangeUnit");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (RangeUnit)untypedValue;
            switch (value)
            {
                case RangeUnit.Km:
                    serializer.Serialize(writer, "km");
                    return;
                case RangeUnit.Mile:
                    serializer.Serialize(writer, "mile");
                    return;
            }
            throw new Exception("Cannot marshal type RangeUnit");
        }

        public static readonly RangeUnitConverter Singleton = new RangeUnitConverter();
    }

    internal class TankUnitConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TankUnit) || t == typeof(TankUnit?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "gallon":
                    return TankUnit.Gallon;
                case "liter":
                    return TankUnit.Liter;
            }
            throw new Exception("Cannot unmarshal type TankUnit");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TankUnit)untypedValue;
            switch (value)
            {
                case TankUnit.Gallon:
                    serializer.Serialize(writer, "gallon");
                    return;
                case TankUnit.Liter:
                    serializer.Serialize(writer, "liter");
                    return;
            }
            throw new Exception("Cannot marshal type TankUnit");
        }

        public static readonly TankUnitConverter Singleton = new TankUnitConverter();
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "vehicle")
            {
                return TypeEnum.Vehicle;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            if (value == TypeEnum.Vehicle)
            {
                serializer.Serialize(writer, "vehicle");
                return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }
}

