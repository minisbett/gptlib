using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GPT_Lib.Enums;

/// <summary>
/// The role of the entity saying the message.
/// </summary>
public enum Role
{
  /// <summary>
  /// The user that is talking to the GPT model.
  /// </summary>
  [EnumMember(Value = "user")] User,

  /// <summary>
  /// The GPT model.
  /// </summary>
  [EnumMember(Value = "assistant")] Assistant,

  /// <summary>
  /// A system instruction for the GPT model by the developer.
  /// </summary>
  [EnumMember(Value = "system")] System
}
