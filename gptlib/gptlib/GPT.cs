using GPT_Lib.Enums;
using GPT_Lib.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GPT_Lib;
public class GPT
{
  /// <summary>
  /// A list of messages are are always prepended with every request sent.
  /// </summary>
  public List<Message> DefaultInstructions { get; } = new List<Message>();
  /// <summary>
  /// The model used in this GPT instance.
  /// </summary>
  private Model Model { get; }

  private HttpClient _httpClient = new HttpClient();

  private const string API_ENDPOINT = "https://api.openai.com/v1/chat/completions";

  /// <summary>
  /// Create a GPT instance with the specified model and API key.
  /// </summary>
  /// <param name="model">The model used by this GPT instance.</param>
  /// <param name="apiKey">The API key for interacting with the OpenAI API.</param>
  public GPT(Model model, string apiKey)
  {
    Model = model;
    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
  }

  public async Task<Response> PostAsync(Request originalRequest)
  {
    // Create a clone of the request object so the injections do not affect this reference.
    Request request = originalRequest.Clone();

    // Inject the model of this GPT instance into the request and prepend the default instructions of this GPT instance.
    request.Model = Model;
    request.Messages.InsertRange(0, DefaultInstructions);

    // Convert the request into json, send it and receive the response.
    string json = JsonConvert.SerializeObject(request);
    HttpResponseMessage httpResponse = await _httpClient.PostAsync(API_ENDPOINT, new StringContent(json, Encoding.UTF8, "application/json"));

    // Read the json from the response, deserialize it into a Response object and return it.
    json = await httpResponse.Content.ReadAsStringAsync();
    return JsonConvert.DeserializeObject<Response>(json)!;
  }
}
