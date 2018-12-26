# About
This is a JCShell like formatting library.

# Documentation
This library supports following features

## Variables
Variables are resolved Based on the provided dictionary, eg.:
```csharp
            Dictionary<string, string> dict = new Dictionary<string, string>()
            {
                {"x1", "Hello"},
                {"x2", "World"}
            };

            var format = new JcShellFormat("${x1} ${x2}!", dict);
            string tmp = format.Evaluate(); // "Hello World!"
```

## Length encoding for binary data
```csharp
            var format = new JcShellFormat("#(DEADBEEF)");
            string tmp = format.Evaluate(); // "04DEADBEEF"
```

## BER length encoding for binary data
```csharp
            string data = new string('1', 256);
            var format = new JcShellFormat($"%({data})");
            string tmp = format.Evaluate(); // 81801111..11
```

## ASCII to hex conversion
```csharp
            var format = new JcShellFormat("%(|DEADBEEF)");
            string tmp = format.Evaluate(); // "09444541444245454629"
```

## Integer to hex
It uses ';hn' modifier, where n the length of output hex format
```csharp
            Dictionary<string, string> dict = new Dictionary<string, string>()
            {
                {"xyz", "15"}
            };

            var format = new JcShellFormat("${xyz;h4}", dict);
            string tmp = format.Evaluate(); // "000F"
```

## Upper-case
It uses ';uc' modifier to provide the data as upper-case
```csharp
            var jcs = new JcShellFormat("${x1;uc}", new Dictionary<string, string> { { "x1", "WaTsUg" } });
            string tmp = format.Evaluate(); // "WATSUG"
```

## Lower-case
It uses ';lc' modifier to provide the data as lower-case
```csharp
            var jcs = new JcShellFormat("${x1;lc}", new Dictionary<string, string> { { "x1", "WaTsUg" } });
            string tmp = format.Evaluate(); // "watsug"
```

## Length of the data
It uses ';l' modifier to provide the length of the data
```csharp
            var format = new JcShellFormat("${xyz;l}", JcShellFormat.Options.KeyAsValueIfNotResolved);
            string tmp = format.Evaluate(); // "3"
```

## Substring
It uses ';sx(,y)' modifier, where x and y (optional) are indices within the input string
```csharp
            var jcs = new JcShellFormat("${text;s5,7}", new Dictionary<string, string> { { "text", "this is my test" } });
            string tmp = format.Evaluate(); // "is my t"
```


# Releases
**2018.12.26 v1.0.8**
* 'LegacyVariables' option added - variables with '{name}' instead of '${name}' form

**2018.12.21 v1.0.7**
* resolver function instead of a dictionary has been added
* option to treat unresolvable data as a value

**2018.11.26 v0.0.4**
* Initial release

# License information
Available in [licence.txt](licence.txt)