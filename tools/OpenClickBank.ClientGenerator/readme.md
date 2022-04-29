# Open: ClickBank ClientGenerator

*After* the [Builder](/tools/OpenClickBank.Builder/readme.md) application is build, the `open-clickbank.yaml` file is updated. This app is a custom client code generator for this particular OpenAPI spec for .NET. The only reason a custom solution was required was that some of the ClickBank endpoints return `$` as a property name. All off-the-shelf solutions remove the `$` (as well as other characters) when creating properties for the models. The only way to override this behavior is to create a custom implementation.

The application must be executed to generate the new `ClickBankClient.cs` file. The file will be saved at the root of the [OpenClickBank](/src/OpenClickBank/readme.md) project.
