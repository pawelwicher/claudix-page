module App

open Fable.React
open Fable.React.Props
open Elmish
open Elmish.React

let nameStyle = 
  Style [
    FontSize 20
    MarginBottom 20
    Cursor "Pointer"
  ]

let infoStyle = 
  Style [
    FontSize 16
    MarginBottom 10
  ]

let displayInitialStyle = 
  Style [
    Display DisplayOptions.Initial
  ]

let displayNoneStyle = 
  Style [
    Display DisplayOptions.None
  ]

type Model =
  { 
    Name: string
    Nip: string
    Regon: string
    Pkd: string
    Address: string
    ShowDetails: bool
  }

let initialModel: Model = 
  {
    Name = "Claudix Paweł Wicher"
    Nip = "6121799181"
    Regon = "363264887"
    Pkd = "62.01.Z, 62.02.Z, 62.09.Z"
    Address = "ul. Władysława Zarembowicza 35 / 69, 54-530 Wrocław"
    ShowDetails = false
  }

type Msg =
  | ToogleDetails

let init () =
  initialModel,
  Cmd.none

let update (msg: Msg) (model: Model) =
  match msg with
  | ToogleDetails ->
    { model with ShowDetails = not model.ShowDetails }, Cmd.none


let view (model: Model) dispatch =
  div []
    [
      div [ nameStyle; OnClick (fun e -> dispatch ToogleDetails) ] [ str model.Name ]
      div [ (if model.ShowDetails then displayInitialStyle else displayNoneStyle) ] [
        div [ infoStyle ] [ str ("NIP: " + model.Nip) ]
        div [ infoStyle ] [ str ("REGON: " + model.Regon) ]
        div [ infoStyle ] [ str ("PKD: " + model.Pkd) ]
        div [ infoStyle ] [ str ("Adres: " + model.Address) ]
      ]
    ]

Program.mkProgram init update view
|> Program.withConsoleTrace
|> Program.withReactSynchronous "elmish-app"
|> Program.run