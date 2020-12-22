module App

open Fable.React
open Fable.React.Props
open Elmish
open Elmish.React

let nameStyle = 
  Style [
    FontSize 16
    Cursor "Pointer"
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
    name: string
    nip: string
    regon: string
    address: string
    showDetails: bool
  }

let initialModel: Model = 
  {
    name = "Claudix Paweł Wicher"
    nip = "6121799181"
    regon = "363264887"
    address = "ul. Władysława Zarembowicza 35 / 69, 54-530 Wrocław"
    showDetails = false
  }

type Msg =
  | ToogleDetails

let init () =
  initialModel,
  Cmd.none

let update (msg: Msg) (model: Model) =
  match msg with
  | ToogleDetails ->
    { model with showDetails = not model.showDetails }, Cmd.none


let view (model: Model) dispatch =
  div []
    [
      div [ nameStyle; OnClick (fun e -> dispatch ToogleDetails) ] [ str model.name ]
      br []
      div [ (if model.showDetails then displayInitialStyle else displayNoneStyle) ] [
        div [] [ str ("Numer NIP: " + model.nip) ]
        div [] [ str ("Numer REGON: " + model.regon) ]
        div [] [ str ("Adres: " + model.address) ]
      ]
    ]

Program.mkProgram init update view
|> Program.withConsoleTrace
|> Program.withReactSynchronous "elmish-app"
|> Program.run