namespace Adacola.XMindToMarkdown.Test.XMindContentXml

open NUnit.Framework
open FsUnit
open FsCheck
open Adacola.XMindToMarkdown

[<TestFixture>]
module ParseXml =

    [<Test>]
    let ``サンプルXMLのparseXmlに成功すること`` () =
        let actual = XMindContentXml.ContentXmlProvider.GetSample() |> string |> XMindContentXml.parseXml
        actual.Title |> should equal "シート 1"
        let rootTopic = actual.RootTopic
        rootTopic.ID |> should equal "0cj4hcipk20ffvvq1cp1j90t6u"
        rootTopic.Title |> should equal "root topic"
        rootTopic.Children |> should haveLength 2

[<TestFixture>]
module GetContentXml =
    [<Test>]
    let ``xmindファイルからXMLへの変換に成功すること`` () =
        let actual = XMindContentXml.getContentXml @"sample.xmind"
        let expected = System.IO.File.ReadAllText(@"sample-xmind-content.xml", System.Text.Encoding.UTF8)
        actual |> should equal expected

// TODO テストケース追加