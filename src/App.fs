module App

open Fable.React
open Fable.React.Props
open Elmish
open Elmish.React

type Model =
  { 
    Name: string
    Nip: string
    Regon: string
    Address: string
  }

let initialModel: Model = 
  {
    Name = "Claudix Paweł Wicher"
    Nip = ""
    Regon = ""
    Address = ""
  }

type Msg =
  | ShowDetails
  | HideDetails

let init () =
  initialModel,
  Cmd.none

let update (msg: Msg) (model: Model) =
  match msg with
  | ShowDetails ->
    {  model with Nip = "NIP 6121799181"; Regon = "REGON 363264887"; Address = "ul. Pochyła, nr 21, lok. 7A, 53-512 Wrocław" }, Cmd.none
  | HideDetails ->
    init ()

let view (model: Model) dispatch =
  div []
    [ 
      span [] [ str model.Name ]
      br []
      span [] [ str model.Nip ]
      br []
      span [] [ str model.Regon ]
      br []
      span [] [ str model.Address ]
      br []
      button  [ OnClick (fun e -> dispatch ShowDetails) ] [ str "show" ]
      br []
      button  [ OnClick (fun e -> dispatch HideDetails) ] [ str "hide" ]
    ]

Program.mkProgram init update view
|> Program.withConsoleTrace
|> Program.withReactSynchronous "elmish-app"
|> Program.run