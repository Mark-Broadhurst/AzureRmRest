module Fake.AzureRm.Rest

open System.Net.Http

type Response =
  | OK of string
  | Error of string * string

let GetClient (token: string) =
  let client = new HttpClient()
  if not (isNull token) then
    client.DefaultRequestHeaders.Add("Authorization", token)
  client

let GetJsonContent text =
  let content = new StringContent(text)
  content.Headers.ContentType.MediaType <- "application/json"
  content

let Get token (uri: string) = async {
  use client = GetClient token
  return! client.GetAsync(uri) |> Async.AwaitTask
}

let GetStream token (uri: string) = async {
  use client = GetClient token
  return!
    client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead)
    |> Async.AwaitTask
}

let Post token data (uri: string) = async {
  use client = GetClient token
  let content = GetJsonContent data
  return! client.PostAsync(uri, content) |> Async.AwaitTask
}

let Put token data (uri: string) = async {
  use client = GetClient token
  let content = GetJsonContent data
  return! client.PutAsync(uri, content) |> Async.AwaitTask
}

let Delete token (uri: string) = async {
  use client = GetClient token
  return! client.DeleteAsync(uri) |> Async.AwaitTask
}

let ParseResponse (response: Async<HttpResponseMessage>) =
  async {
    let! res = response
    let! content =
      res.Content.ReadAsStringAsync()
      |> Async.AwaitTask

    if res.IsSuccessStatusCode then
      return OK content
    else
      return Error(res.ReasonPhrase, content)
  }