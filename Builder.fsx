#!/usr/bin/env -S dotnet fsi

// Data-Structure
type Attribute =
    | Attribute of key:string * value:string

let attr key value = Attribute(key,value)
let src src        = attr "src" src
let alt text       = attr "alt" text
let id id          = attr "id" id
let Class _class   = attr "class" _class

type Html =
    | Text of text:string
    | Node of name:string * attributes:List<Attribute> * nodes:List<Html>

let text txt              = Text(txt)
let node name attrs nodes = Node(name,attrs,nodes)

let p   = node "p"
let br  = node "br" [] []
let img = node "img"

// Convert a data-structure to HTML
let rec toHtml html =
    match html with
    | Text txt                -> System.Web.HttpUtility.HtmlEncode txt
    | Node (name,attrs,nodes) ->
        let attrs =
            List.map (fun (Attribute (key,value)) ->
                sprintf "%s=\"%s\"" key (System.Web.HttpUtility.HtmlEncode value)
            ) attrs
            |> String.concat " "

        let nodes = String.concat "" (List.map toHtml nodes)

        let hasAttrs = not (System.String.IsNullOrWhiteSpace attrs)
        let hasNodes = not (System.String.IsNullOrWhiteSpace nodes)

        match hasAttrs,hasNodes with
        | true,true   -> sprintf "<%s %s>%s</%s>" name attrs nodes name
        | false,true  -> sprintf "<%s>%s</%s>" name nodes name
        | true,false  -> sprintf "<%s %s/>" name attrs
        | false,false -> sprintf "<%s/>" name

// Usage
let html =
    p [id "main"] [
        text "Text äöü <img/>"
        br
        img [Class "image"; src "saksjdgkj.png"; alt "Non-existing Image"] []
    ]

printfn "%A" html
printfn ""
printfn "%s" (toHtml html)

// Output:
//
// Node
//   ("p", [Attribute ("id", "main")],
//    [Text "Text äöü <img/>"; Node ("br", [], []);
//     Node
//       ("img",
//        [Attribute ("class", "image"); Attribute ("src", "saksjdgkj.png");
//         Attribute ("alt", "Non-existing Image")], [])])

// <p id="main">Text &#228;&#246;&#252; &lt;img/&gt;<br/><img class="image" src="saksjdgkj.png" alt="Non-existing Image"/></p>

