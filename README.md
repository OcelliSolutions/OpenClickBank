# Open: ClickBank

This is a project designed to provide developers with an easy to use and accurate OpenAPI specification for the [ClickBank APIs](https://support.clickbank.com/hc/en-us/sections/206287868-ClickBank-APIs). All endpoints, command and descriptions are faithfully ported into the specification. This allows developers to use client code generators to seamlessly consume the API into whatever language they happen to use. This also creates a NuGet package to aid .NET developers with the consumption of the API.

## Developer Notes

As you work with this spec, there are some considerations that are not fully documented in the source.

* The authorization may look like a `Basic` type but it is not. It is similar to an API Key type with the word `authorization` as the name and the `<Developer API Key>:<Clerk API Key>` as the value. This **does not** use the `Bearer` keyword.
* The rate limiting specifies a maximum of 25,000 requests/day/account and 10 requests/second/IP address. The 25,000 can be misleading. This is shared across all integrations for all stores/sites for an account. This means there is a rogue application consuming all requests for the day on an account, it can block all other applications. So the `403 [Forbidden]` error may not be your fault.
* The rate limit exceeded error is `403 [Forbidden]` not `429 [Too Many Requests]`.
* Error codes are in a string format, not JSON/XML.
* Some items that are documented as arrays can also come back as objects. There is no way to know all of these instances, so just plan on all arrays behaving as such.
* Nullable items are not simply nullable, they are *nillable* (from XML days) where an object can be returned instead of a string, date, or number. If your language works with anyOf or oneOf, then you are fine. If not, then you will be required to manage this feature manually.

## Contributing

If you would like to contribute to the OpenClickBank project, here are some tips and guidelines to help you get started.

### Tools

* The [Scraper](/tools/OpenClickBank.Scraper/readme.md) gathers as much data as possible from existing documentation from ClickBank proper.
* The [Builder](/tools/OpenClickBank.Builder/readme.md) creates the OpenAPI spec from code.
* The [ClientGenerator](/tools/OpenClickBank.ClientGenerator/readme.md) creates the .NET client code and also contains the OpenAPI YAML file.

### Source

* The [OpenClickBank](/src/OpenClickBank/readme.md) is the package that is deployed to NuGet.

## TODO

* [ ] For all properties that are `nillable`, the property should be a oneOf instead of just the object.
* [ ] Convert ENUM properties back to enum instead of string. This can only be done after the `nillable` issue is resolved.
