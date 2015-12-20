module Adacola.XMindToMarkdown.Markdown

open XMindContentXml

type LineType = HeaderLine | ListLine

type Line = {
    Type : LineType
    Level : int
    Topic : Topic
}

let xmindContentToMarkdown startHeaderLevel endHeaderLevel (xmindContent : Content) =
    if startHeaderLevel < 1 || 6 < startHeaderLevel then
        sprintf "startHeaderLevel(%d)は1～6の範囲内でなければなりません" startHeaderLevel |> invalidArg "startHeaderLevel"
    if endHeaderLevel < startHeaderLevel || 6 < endHeaderLevel then
        sprintf "endHeaderLevel(%d)は%d～6の範囲内でなければなりません" endHeaderLevel startHeaderLevel |> invalidArg "endHeaderLevel"

    let topicToString (topic : Topic) =
        // TODO 今は改行を削除しているが、そのうち改行を含められるようにする
        topic.Title.Replace("\r\n", "").Replace("\r", "").Replace("\n", "")
    let headerToString level (topic : Topic) = sprintf "%s %s" (String.replicate level "#") (topicToString topic)
    let listToString level (topic : Topic) = sprintf "%s* %s" (String.replicate (level - 1) "    ") (topicToString topic)
    let lineToString { Type = ty; Level = l; Topic = t } =
        match ty with
        | HeaderLine -> headerToString l t
        | ListLine -> listToString l t
    let linePairToNewline = function
        | { Type = ListLine }, { Type = ListLine } -> ""
        | _ -> "\n"

    let linesToString lines =
        let newLines = ""::(lines |> List.pairwise |> List.map linePairToNewline)
        let lineStrings = lines |> List.map lineToString
        (newLines, lineStrings) ||> Seq.map2 (+) |> String.concat "\n"

    let rec xmindTopicToLines level topics = seq {
        for (topic : Topic) in topics do
            let lineType, lineLevel = if level <= endHeaderLevel then (HeaderLine, level) else (ListLine, level - endHeaderLevel)
            yield { Type = lineType; Level = lineLevel; Topic = topic }
            yield! xmindTopicToLines (level + 1) topic.Children
    }

    [for sheet in xmindContent.Sheets -> sheet.RootTopic] |> xmindTopicToLines startHeaderLevel |> Seq.toList
    |> linesToString
