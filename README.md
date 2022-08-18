# Open:ClickBank

This is a project designed to provide developers with an easy to use and accurate OpenAPI specification for the [ClickBank APIs](https://support.clickbank.com/hc/en-us/sections/206287868-ClickBank-APIs). All endpoints, command and descriptions are faithfully ported into the specification. This allows developers to use client code generators to seamlessly consume the API into whatever language they happen to use. This also creates a NuGet package to aid .NET developers with the consumption of the API.

## Usage

* First, register the ClickBankService using dependency injection.
  * if there are multiple credentials" `services.AddScoped<IClickBankService, ClickBankService>();`
  * if there is only one set of credentials: `services.AddScoped<IClickBankService>(svc => new ClickBankService(new OpenClickBankConfig("", "")));`
* Inject the service into a class.
* Update the configuration if it was not assigned in the injection configuration (if required).
  * `_clickBankService.OpenClickBankConfig = new OpenClickBankConfig(devKey, clerkKey);`
* Under the main service is every *current* version of each endpoint. For example:
  * Get the debug string: `_clickBankService.Debugs.GetDebugAsync(cancellationToken);`
  * Notice that the API section references `Shipping`, this is pointed to the most current version of `shipping2` and will be updated to `shipping3` once production ready. `_clickBankService.Shipping.GetShippingNoticeAsync(receipt, cancellationToken)`

## Developer Notes

As a developer working with this spec, there are some considerations that are not fully documented in the source.

* The authorization may look like a `Basic` type but it is not. It is similar to an API Key type with the word `authorization` as the name and the `<Developer API Key>:<Clerk API Key>` as the value. This **does not** use the `Bearer` keyword.
* The rate limiting specifies a maximum of 25,000 requests/day/account and 10 requests/second/IP address. The 25,000 can be misleading. This is shared across all integrations for all stores/sites for an account. This means there is a rogue application consuming all requests for the day on an account, it can block all other applications. So the `403 [Forbidden]` error may not be in control of the developer.
* The rate limit exceeded error is `403 [Forbidden]` not `429 [Too Many Requests]`.
* Error codes are in a string format, not JSON/XML.
* Some items that are documented as arrays can also come back as objects. There is no way to know all of these instances, so just plan on all arrays behaving as such.
* Nullable items are not simply nullable, they are *nillable* (from XML days) where an object can be returned instead of a string, date, or number. Developers may need to account for this.
  * One of the ways to work around this issue for enums is to return a default value instead of the *nil* object. Every enum has a `nil` value for this reason even though it is not a valid value.
* Orders myst be created manually. Please use the following link to read about creating a [pay link](https://support.clickbank.com/hc/en-us/articles/360036580432-How-do-I-create-a-secure-payment-link-#:~:text=A%20payment%20link%20is%20the,it%20to%20their%20Pitch%20Page.)

### Tools

* The [Open:ClickBank Scraper](/tools/OpenClickBank.Scraper/readme.md) gathers as much data as possible from existing documentation from ClickBank proper.
* The [Open:ClickBank Builder](/tools/OpenClickBank.Builder/readme.md) creates the OpenAPI spec from code.
* The [Open:ClickBank Client Generator](/tools/OpenClickBank.ClientGenerator/readme.md) creates the .NET client code and also contains the OpenAPI YAML file.

### Source

* The [Open:ClickBank](/src/OpenClickBank/readme.md) is the package that is deployed to NuGet.

### Tests

* The [Open:ClickBank Tests](/tests/OpenClickBankTests/readme.md) contains unit and integration testing for Open:ClickBank.

## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".

Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## License

Distributed under the MIT License. See `LICENSE.txt` for more information.

## Brought to you by

![Ocelli](https://codecooper.com/wp-content/uploads/2022/05/Ocelli-2C-horiz-tag.png)
