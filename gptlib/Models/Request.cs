using GPT_Lib.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPT_Lib.Models;

public class Request
{
  /// <summary>
  /// The model used to generate the response.
  /// </summary>
  [JsonProperty("model")]
  [JsonConverter(typeof(StringEnumConverter))]
  internal Model Model { get; set; }

  /// <summary>
  /// The list of messages assembling the conversation.
  /// </summary>
  [JsonProperty("messages")]
  public List<Message> Messages { get; }

  /// <summary>
  /// The sampling temperature. It can range from 0.0 to 2.0 where lower means more focused and deterministic and higher more random. Defaults to 1.0.
  /// </summary>
  [JsonProperty("temperature")]
  public float Temperature
  {
    get => _temperature;
    set
    {
      if (value < 0 || value > 2)
        throw new ArgumentOutOfRangeException("value");
      _temperature = value;
    }
  }

  private float _temperature;

  /// <summary>
  /// The amount of choices that should be generated. Defaults to 1.
  /// </summary>
  [JsonProperty("n")]
  public int Amount { get; set; }

  /// <summary>
  /// The maximum amount of tokens to spend on the request. Defaults to null, which means there is no limit.
  /// </summary>
  [JsonProperty("max_tokens", NullValueHandling = NullValueHandling.Ignore)]
  public int? MaxTokens { get; set; }

  public Request(List<Message> messages = null!, float temperature = 1.0f, int amount = 1, int? maxTokens = null)
  {
    Messages = messages ?? new List<Message>();
    _temperature = temperature;
    Amount = amount;
    MaxTokens = maxTokens;
  }

  public Request(Message message, float temperature = 1.0f, int amount = 1, int? maxTokens = null)
    : this(new List<Message> { message }, temperature, amount, maxTokens)
  { }

  /// <summary>
  /// Create a clone of the request object.
  /// </summary>
  /// <returns></returns>
  public Request Clone()
  {
    return new Request(Messages, Temperature, Amount, MaxTokens);
  }
}
