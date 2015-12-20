module Adacola.XMindToMarkdown.Main

open Nessos.Argu
open System
open System.IO

type Arguments =
    | [<Mandatory; AltCommandLine("-i")>] Input of string
    | [<Mandatory; AltCommandLine("-o")>] Output of string
    | [<AltCommandLine("-s")>] Start_Header_Level of int
    | [<AltCommandLine("-e")>] End_Header_Level of int
with
    interface IArgParserTemplate with
        member x.Usage: string = 
            match x with
            | Input(_) -> "入力元のxmindファイルのパス"
            | Output(_) -> "出力先のmarkdownファイルのパス"
            | Start_Header_Level(_) -> "markdownでのヘッダーの開始レベル。1～6の範囲内で指定。省略時は1"
            | End_Header_Level(_) -> "markdownでのヘッダーの終了レベル。このレベル以降はリストになる。1～6の範囲内で指定。省略時は6"

[<EntryPoint>]
let main args =
    let parser = ArgumentParser.Create<Arguments>()
    let parseResult = parser.Parse args
    let input = parseResult.GetResult <@ Input @>
    let output = parseResult.GetResult <@ Output @>
    let startHeaderLevel = parseResult.GetResult(<@ Start_Header_Level @>, 1)
    let endHeaderLevel = parseResult.GetResult(<@ End_Header_Level @>, 6)

    if File.Exists input |> not then printfn "%s ファイルが存在しません" input; 1 else
    
    let contentXml = XMindContentXml.getContentXml input
    let content = XMindContentXml.parseXml contentXml
    let result = Markdown.xmindContentToMarkdown startHeaderLevel endHeaderLevel content

    File.WriteAllText(output, result, Text.UTF8Encoding false)
    0
