module Fake.AzureRm.Resources

open Uri
open Rest
open Newtonsoft.Json

let Restify (uri: System.Uri) httpmethod token json =
    uri
    |> httpmethod token
    |> parseResponse

let RestifyWithContent (uri: System.Uri) httpmethod token json =
    uri
    |> httpmethod token json
    |> parseResponse

let CreateResourceGroup subId token name location =
    let json = (sprintf """
{
  "location": "%s"
}
"""
      location)
    RestifyWithContent (ResourceGroupUri subId name) put token json

let DeleteResourceGroup subId token name =
    Restify (ResourceGroupUri subId name) delete token

let CreateAppServicePlan subId token group name plan location capacity =
    let json = (sprintf """
{
  "location": "%s",
  "Sku": {
    "Name": "%s",
    "Capacity": %d
  }
}
"""
      location
      plan
      capacity)
    RestifyWithContent (AppServicePlanUri subId group name) put token json

let DeleteAppServicePlan subId token group name =
  Restify (AppServicePlanUri subId group name) delete token 

let CreateAppService subId token group plan name location =
  AppServiceUri subId group name
  |> put token (
    sprintf """
{
  "location": "%s",
  "properties": { "serverFarmId": "%s" }
}
"""
      location
      plan
    )
  |> parseResponse

let SetAppSettings subId token group name (settings: (string * string) list) =
  let json = (
    let props =
      settings
      |> List.map (fun (key, value) ->
        sprintf
          "%s: %s"
          (JsonConvert.ToString(key))
          (JsonConvert.ToString(value))
        )
      |> String.concat ",\n    "

    sprintf """
{
  "properties": {
    %s
  }
}
"""
      props
    )
  RestifyWithContent (AppSettings subId group name) put token 

let CreateSqlServer subscriptionId token resourceGroupName serverName username password location =
  let json = (sprintf """
{
  "properties": {
    "version": "12.0",
    "administratorLogin": "%s",
    "administratorLoginPassword": "%s"
  },
  "location": "%s"
}  
"""
      username
      password
      location)
  RestifyWithContent (SqlServerUri subscriptionId resourceGroupName serverName) put token json

let CreateSqlDatabase subscriptionId token resourceGroupName serverName databaseName plan location =
  let json = (sprintf """
{
  "name": "%s",
  "location": "%s",
  "properties":{
    "requestedServiceObjectiveName": "%s"
  }
}
"""
      databaseName
      location
      plan)
  RestifyWithContent (SqlDatabaseUri subscriptionId resourceGroupName serverName databaseName) put token 
