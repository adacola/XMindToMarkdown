module Adacola.XMindToMarkdown.XMindContentXml

open FSharp.Data
open System.IO
open System.IO.Compression

type internal ContentXmlProvider = XmlProvider<"sample-xmind-content.xml", Global = true>

type Topic = {
    ID : string
    Title : string
    Children : Topic list
}

type Sheet = {
    Title : string
    RootTopic : Topic
}

let parseXml contentXml =
    let rec parseTopic (topic : ContentXmlProvider.Topic) =
        let children =
            topic.Children |> Option.toList
            |> List.collect (fun t -> t.Topics |> Seq.filter (fun x -> x.Type = "attached") |> Seq.collect (fun x -> x.Topics) |> Seq.toList)
            |> List.map parseTopic
        { ID = topic.Id; Title = topic.Title.String |> Option.get; Children = children }

    let xml = ContentXmlProvider.Parse contentXml
    let title = xml.Sheet.Title.String |> Option.get
    let rootTopic = xml.Sheet.Topic |> parseTopic
    { Title = title; RootTopic = rootTopic }

let getContentXml xmindFilePath =
    use zipArchive = ZipFile.OpenRead xmindFilePath
    let entry = zipArchive.GetEntry @"content.xml"
    use stream = new StreamReader(entry.Open(), System.Text.Encoding.UTF8)
    stream.ReadToEnd()
    