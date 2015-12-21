# XMindToMarkdown

Latest Version : 0.0.1 (Alpha)

## 概要

[XMind](https://jp.xmind.net/) で作成したxmind形式のファイルをMarkdownに変換するツールです。

## Usage

```
XMindToMarkdown [options]

options:

--input [-i] <string>: 入力元のxmindファイルのパス
--output [-o] <string>: 出力先のmarkdownファイルのパス
--start-header-level [-s] <int>: markdownでのヘッダーの開始レベル。1～6の範囲内で指定。省略時は1
--end-header-level [-e] <int>: markdownでのヘッダーの終了レベル。このレベル以降はリストになる。1～6の範囲内で指定。省略時は6
--help [-h|/h|/help|/?]: display this list of options.
```

## 制限

* 無料版のXMindの範囲で可能な機能が入ったファイルしか対応していません。おそらくPro版の機能を含めたファイルを読みこませるとエラーになります。
* Markdownとして出力されるのは以下の要素だけです。他の要素は無視されます。
    * トピック

## 動作確認済みの環境

Windows10 + .NET4.5.2

## その他

* 当ツールを使用して生じた損害について作者は保証を負いかねます。自己責任でお願いします。