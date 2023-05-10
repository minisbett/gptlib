using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPT_Lib.Models;

public class Choice
{
  /// <summary>
  /// The index of the choice.
  /// </summary>
  [JsonProperty("index")]
  public int Index { get; private set; }
  /// <summary>
  /// The message of this choice.
  /// </summary>
  public Message Message { get; private set; }

  /// <summary>
  /// The reason the model decided to finish generating the response.
  /// </summary>
  public string FinishReason { get; private set; }

  public Choice(int index, Message message, string finishReason)
  {
    Index = index;
    Message = message;
    FinishReason = finishReason;
  }
}
