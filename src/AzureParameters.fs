[<AutoOpen>]
module AzureRmRest.AzureParameters

type Credentials = { Username: string; Password: string}

type Response =
  | OK of string
  | Error of string * string

type AuthToken = AuthToken of string

type Location = 
    | ``East US``
    | ``East US 2``
    | ``Central US``
    | ``North Central US``
    | ``South Central US``
    | ``West Central US``
    | ``West US``
    | ``West US 2``
    | ``US Gov Virginia``
    | ``US Gov Iowa``
    | ``US DoD East``
    | ``US DoD Central``
    | ``Canada East``
    | ``Canada Central``
    | ``Brazil South``
    | ``US Gov Arizona``
    | ``US Gov Texas``
    | ``North Europe``
    | ``West Europe``
    | ``Germany Central``
    | ``Germany Northeast``
    | ``UK West``
    | ``UK South``
    | ``France Central``
    | ``France South``
    | ``Southeast Asia``
    | ``East Asia``
    | ``Australia East``
    | ``Australia Southeast``
    | ``Central India``
    | ``West India``
    | ``South India``
    | ``Japan East``
    | ``Japan West``
    | ``China East``
    | ``China North``
    | ``Korea Central``
    | ``Korea South``

type WebAppServiceSku =
    | P1
    | P2
    | P3
    | S1
    | S2
    | S3
    | B1
    | B2
    | B3
    | F1
    | D1

type DatabaseSku = 
    | P1
    | P2
    | P4
    | P6
    | P11
    | P15
    | S0
    | S1
    | S2
    | S3
    | B
    