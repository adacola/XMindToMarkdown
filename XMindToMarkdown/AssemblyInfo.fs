﻿namespace XMindToMarkdown.AssemblyInfo

open System.Reflection
open System.Runtime.CompilerServices
open System.Runtime.InteropServices

// アセンブリに関する一般情報は、以下の属性セットによって
// 制御されます。アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更します。
[<assembly: AssemblyTitle("XMindToMarkdown")>]
[<assembly: AssemblyDescription("")>]
[<assembly: AssemblyConfiguration("")>]
[<assembly: AssemblyCompany("")>]
[<assembly: AssemblyProduct("XMindToMarkdown")>]
[<assembly: AssemblyCopyright("Copyright ©  2015")>]
[<assembly: AssemblyTrademark("")>]
[<assembly: AssemblyCulture("")>]

// ComVisible を false に設定すると、COM コンポーネントがこのアセンブリ内のその型を認識
// できなくなります。COM からこのアセンブリ内の型にアクセスする必要がある場合は、
// その型の ComVisible 属性を true に設定します。
[<assembly: ComVisible(false)>]

// このプロジェクトが COM に公開される場合、次の GUID がタイプ ライブラリの ID になります
[<assembly: Guid("3559c3dc-4793-4372-bdc4-a2ca5c23a226")>]

// アセンブリのバージョン情報は、以下の 4 つの値で構成されます。:
// 
//       メジャー バージョン
//       マイナー バージョン 
//       ビルド番号
//       リビジョン
// 
// すべての値を指定するか、下に示すように '*' を使用してビルドおよびリビジョン番号を
// 既定値にすることができます。:
// [<assembly: AssemblyVersion("1.0.*")>]
[<assembly: AssemblyVersion("0.0.1.0")>]
[<assembly: AssemblyFileVersion("0.0.1.0")>]

#if DEBUG
[<assembly: InternalsVisibleTo("XMindToMarkdownTest")>]
#endif

do
    ()