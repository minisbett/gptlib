using GPT_Lib.Converters;
using GPT_Lib.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GPT_Lib.Models;

public class Message
{
  /// <summary>
  /// The role of the entity saying this message.
  /// </summary>
  ///
  [JsonProperty("role")]
  [JsonConverter(typeof(StringEnumConverter))]
  public Role Role { get; }

  /// <summary>
  /// The content of the message.
  /// </summary>
  [JsonProperty("content")]
  public string Content { get; }

  public Message(Role role, string content)
  {
    Role = role;
    Content = content;
  }
}