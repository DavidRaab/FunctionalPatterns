#!/usr/bin/env -S dotnet fsi

// Data-Structure
type Attribute =
    | Attribute of key:string * value:string

type Html =
    | Text of text:string
    | Node of name:string * attributes:List<Attribute> * nodes:List<Html>

// Functions
let attr key value        = Attribute(key,value)
let node name attrs nodes = Node(name,attrs,nodes)
let text txt              = Text(txt)

let p  = node "p"
let br = node "br" [] []

let img src nodes =
    node "img" [attr "src" src] nodes

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
    p [] [
        text "Text äöü <img/>"
        br
        img "saksjdgkj.png" []
    ]

printfn "%A" html
printfn ""
printfn "%s" (toHtml html)

// Output:
//
// Node
//   ("p", [],
//    [Text "Text äöü <img/>"; Node ("br", [], []);
//     Node ("img", [Attribute ("src", "saksjdgkj.png")], [])])
//
// <p>Text &#228;&#246;&#252; &lt;img/&gt;<br/><img src="saksjdgkj.png"/></p>
