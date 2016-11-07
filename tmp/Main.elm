module Main exposing (..)

import Html.App as App
import Html exposing (..)
import Html.Attributes exposing (href, class, style)
import Material
import Material.Scheme
import Material.Button as Button
import Material.Options exposing (css)


-- Model


type alias Model =
    { count : Int
    , mdl : Material.Model
    }


model : Model
model =
    { count = 0
    , mdl = Material.model
    }



-- update


type Msg
    = Increment
    | Decrement
    | Reset
    | Mdl (Material.Msg Msg)


update : Msg -> Model -> ( Model, Cmd Msg )
update msg model =
    case msg of
        Increment ->
            ( { model | count = model.count + 1 }, Cmd.none )

        Decrement ->
            ( { model | count = model.count - 1 }, Cmd.none )

        Reset ->
            ( { model | count = 0 }, Cmd.none )

        Mdl msg' ->
            Material.update msg' model



-- View


type alias Mdl =
    Material.Model


view : Model -> Html Msg
view model =
    div
        [ style [ ( "padding", "2rem" ) ] ]
        [ Button.render Mdl
            [ 0 ]
            model.mdl
            [ Button.onClick Decrement
            , css "margin" "0 24px"
            ]
            [ text "Decrenent" ]
        , text (toString model.count)
          {- We construct the instances of the Button component that we need, one
             for the increase button, one for the reset button. First, the increase
             button. The first three arguments are:
               - A Msg constructor (`Mdl`), lifting Mdl messages to the Msg type.
               - An instance id (the `[0]`). Every component that uses the same model
                 collection (model.mdl in this file) must have a distinct instance id.
               - A reference to the elm-mdl model collection (`model.mdl`).
             Notice that we do not have to add fields for the increase and reset buttons
             separately to our model; and we did not have to add to our update messages
             to handle their internal events.
             Mdl components are configured with `Options`, similar to `Html.Attributes`.
             The `Button.onClick Increase` option instructs the button to send the `Increase`
             message when clicked. The `css ...` option adds CSS styling to the button.
             See `Material.Options` for details on options.
          -}
        , Button.render Mdl
            [ 0 ]
            model.mdl
            [ Button.onClick Increment
            , css "margin" "0 24px"
            ]
            [ text "Increment" ]
        , Button.render Mdl
            [ 1 ]
            model.mdl
            [ Button.onClick Reset ]
            [ text "Reset" ]
        ]
        |> Material.Scheme.top



-- Load Google Mdl CSS. You'll likely want to do that not in code as we
-- do here, but rather in your master .html file. See the documentation
-- for the `Material` module for details.


main : Program Never
main =
    App.program
        { init = ( model, Cmd.none )
        , view = view
        , subscriptions = always Sub.none
        , update = update
        }
