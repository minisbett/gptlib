using GPT_Lib.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPT_Lib.Converters;

internal class ModelStringConverter : JsonConverter<Model>
{
  private List<(string identifier, Model model)> _modelIdentifierLookupTable = new List<(string identifier, Model model)>()
  {
    ("gpt-3.5-turbo", Model.GPT3_5_TURBO),
    ("gpt-4", Model.GPT4_8K),
    ("gpt-4-32k", Model.GPT4_32K)
  };

  public override Model ReadJson(JsonReader reader, Type objectType, Model existingValue, bool hasExistingValue, JsonSerializer serializer)
  {
    return _modelIdentifierLookupTable.First(x => x.identifier == reader.ReadAsString()!).model;
  }

  public override void WriteJson(JsonWriter writer, Model value, JsonSerializer serializer)
  {
    writer.WriteValue(_modelIdentifierLookupTable.First(x => x.model == value).identifier);
  }
}
