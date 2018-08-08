# WoX UUID generator plugin

**wox-uuid-generator** is a plugin for [WoX](http://www.wox.one) that generates random GUIDs and enables you to copy them to the clipboard

![Example](https://antonio-fasolato.github.io/wox-uuid-generator/example.png)

You can find the WoX plugin pahe [here](http://www.wox.one/plugin/106)

## Features

- Generate version 1 or 4 UUIDs
- Various output formats
- Base64 encoding

## Installation

Download [WoX](http://www.wox.one) then follow its [guide](http://doc.wox.one/en/plugin/install_plugin.html) to download a plugin.

If you want to manually download a release, head to the [releases](https://github.com/antonio-fasolato/wox-uuid-generator/releases) section.

## Usage

Launch WoX (<kbd>alt</kbd>+<kbd>space</kbd> by default) and type `uuid`. 

Various elements will appear with a new random generated UUID. Each element, when selected (<kbd>enter</kbd> or click), will copy to the clipboard the corresponding UUID with the selected format (uppercase, lowercase, with or without braces, with or without hyphens)

The plugins has various options:

- `<any number>` - generate that many UUIDs instead of a single one. The UUIDs will be copied to the clipboard separated by a newline
- `b` - encodes the UUIDs in base64
- `v1` - generates [version 1](https://en.wikipedia.org/wiki/Universally_unique_identifier#Version_1_(date-time_and_MAC_address)) UUIDs

### Examples

```
uuid b 3
```

Generates 3 UUIDs encoded in Base64

```
uuid v1 50
```

Generates 50 version 1 UUIDs

## Build

The plugin has been created in Visual Studio 2017 Community. Simply open the solution and build it, it has no particular dependencies apart from Wox.Plugin
