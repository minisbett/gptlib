﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GPT_Lib.Enums;

public enum Model
{
  /// <summary>
  /// The gpt-3.5-turbo model.
  /// </summary>
  [EnumMember(Value = "gpt-3.5-turbo")] GPT3_5_TURBO,

  /// <summary>
  /// The static 1st march version of the gpt-3.5-turbo model.
  /// </summary>
  [EnumMember(Value = "gpt-3.5-turbo-0301")] GPT3_5_TURBO_0301,

  /// <summary>
  /// The gpt-4 model for the 8K context.
  /// </summary>
  [EnumMember(Value = "gpt-4")] GPT4_8K,

  /// <summary>
  /// The static 14th march version of the gpt-4 model.
  /// </summary>
  [EnumMember(Value = "gpt-4-0314")] GPT4_0314,

  /// <summary>
  /// The gpt-4 model for the 32K context.
  /// </summary>
  [EnumMember(Value = "gpt-4-32k")] GPT4_32K,

  /// <summary>
  /// The static 14th march version of the gpt-4-32k model.
  /// </summary>
  [EnumMember(Value = "gpt-4-32k-0314")] GPT4_32K_0314
}
