using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPT_Lib.Models;

public class TokenUsage
{
  /// <summary>
  /// The amount of tokens spent for the input prompt sent with the request.
  /// </summary>
  [JsonProperty("prompt_tokens")]
  public int Prompt { get; }

  /// <summary>
  /// The amount of tokens spent for generating the output response.
  /// </summary>
  [JsonProperty("completion_tokens")]
  public int Completion { get; }

  /// <summary>
  /// The total tokens spent on this request.
  /// </summary>
  [JsonProperty("total_tokens")]
  public int Total { get; }
}
