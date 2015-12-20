namespace Adacola.XMindToMarkdown.Test.Markdown

open NUnit.Framework
open FsUnit
open FsCheck
open Adacola.XMindToMarkdown

[<TestFixture>]
module XmindContentToMarkdown =
    [<Test>]
    let ``XmindContentToMarkdownでmarkdownに変換できること`` () =
        // TODO チェックを後で追加。とりあえず変換結果を標準出力に出して目視確認できるようにしておく
        let contentXml = XMindContentXml.getContentXml @"sample.xmind"
        let sheet = XMindContentXml.parseXml contentXml
        let result = Markdown.xmindContentToMarkdown 1 6 sheet
        printfn "%s" result

// TODO テストケース追加