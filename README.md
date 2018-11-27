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
```csharp
            Dictionary<string, string> dict = new Dictionary<string, string>()
            {
                {"xyz", "15"}
            };

            var format = new JcShellFormat("${xyz;h4}", dict);
            string tmp = format.Evaluate(); // "000F"
```


# Releases
**2019.11.26 v0.0.4**
* Initial release

# License information
Available in [licence.txt](licence.txt)