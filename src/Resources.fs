module Fake.AzureRm.Resources

open Uri
open Rest
open Newtonsoft.Json

let CreateResourceGroup subId token name location =
  ResourceGroupUri subId name
  |> Put token (
    sprintf """
{
  "location": "%s"
}
"""
      location)
  |> ParseResponse

let DeleteResourceGroup subId token name =
  ResourceGroupUri subId name
  |> Delete token
  |> ParseResponse

let CreateAppServicePlan subId token group name plan location capacity =
  AppServicePlanUri subId group name
  |> Put token (
    sprintf """
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
      capacity
    )
  |> ParseResponse

let DeleteAppServicePlan subId token group name =
  AppServicePlanUri subId group name
  |> Delete token
  |> ParseResponse

let CreateAppService subId token group plan name location =
  AppServiceUri subId group name
  |> Put token (
    sprintf """
{
  "location": "%s",
  "properties": { "serverFarmId": "%s" }
}
"""
      location
      plan
    )
  |> ParseResponse

let SetAppSettings subId token group name (settings: (string * string) list) =
  sprintf
    "https://management.azure.com/subscriptions/%s/resourceGroups/%s/providers/Microsoft.Web/sites/%s/config/appsettings?api-version=2015-08-01"
    subId
    group
    name
  |> Put token (
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
  |> ParseResponse

let CreateSqlServer subscriptionId token resourceGroupName serverName username password location =
  SqlServerUri subscriptionId resourceGroupName serverName
  |> Put token ( sprintf """
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
  |> ParseResponse

let CreateSqlDatabase subscriptionId token resourceGroupName serverName databaseName plan location =
  SqlDatabaseUri subscriptionId resourceGroupName serverName databaseName
  |> Put token (sprintf """
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
  |> ParseResponse
