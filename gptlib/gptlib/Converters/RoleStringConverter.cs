using GPT_Lib.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPT_Lib.Converters;

internal class RoleStringConverter : JsonConverter<Role>
{
  public override Role ReadJson(JsonReader reader, Type objectType, Role existingValue, bool hasExistingValue, JsonSerializer serializer)
  {
    return Enum.Parse<Role>(reader.ReadAsString()!, true);
  }

  public override void WriteJson(JsonWriter writer, Role value, JsonSerializer serializer)
  {
    writer.WriteValue(value.ToString().ToLower());
  }
}
