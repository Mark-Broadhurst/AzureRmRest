module internal Fake.AzureRm.Auth

open System.Net.Http
open System.Text
open System.Net
open Newtonsoft.Json.Linq
open Fake.AzureRm.Rest

let GetAuth tenantId clientId clientSecret =
  async {
    use client = new HttpClient()
    let uri = sprintf "https://login.windows.net/%s/oauth2/token" tenantId

    let text =
      sprintf
        "resource=%s&client_id=%s&grant_type=client_credentials&client_secret=%s"
        (WebUtility.UrlEncode("https://management.core.windows.net/"))
        (WebUtility.UrlEncode(clientId))
        (WebUtility.UrlEncode(clientSecret))

    let content = new StringContent(text, Encoding.UTF8, "application/x-www-form-urlencoded")

    let! r =
            client.PostAsync(uri, content)
            |> Async.AwaitTask
            |> parseResponse
    
    match r with
    | OK text ->
      let json = JObject.Parse(text)
      let token = json.["access_token"].Value<string>()
      return Choice1Of2 (sprintf "Bearer %s" token)
    | err ->
      return Choice2Of2 err 
}    

let AsyncChoice choice =
  match choice with
  | Choice1Of2 x -> x
  | Choice2Of2 (OK(text)) ->
    failwith text
  | Choice2Of2 (Error(reason, text)) ->
    failwithf "%s: %s" reason text